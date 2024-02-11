using Chaos.Common.Synchronization;
using Chaos.Extensions.Common;
using Chaos.Extensions.Geometry;
using Chaos.Geometry.Abstractions;
using Chaos.Geometry.Abstractions.Definitions;
using Chaos.Geometry.EqualityComparers;
using Ouroboros.Model;

namespace Ouroboros.Services.Pathfinding;

public sealed class Pathfinder
{
    private readonly int Height;
    private readonly int[] NeighborIndexes;
    private readonly PathNode[,] PathNodes;
    private readonly PriorityQueue<PathNode, int> PriortyQueue;
    private readonly AutoReleasingMonitor Sync;
    private readonly int Width;
    
    public Pathfinder(Map map, HashSet<IPoint>? blacklistedPoints = null)
    {
        blacklistedPoints ??= new HashSet<IPoint>(PointEqualityComparer.Instance);
        
        Width = map.Width;
        Height = map.Height;
        PathNodes = new PathNode[Width, Height];
        PriortyQueue = new PriorityQueue<PathNode, int>(ushort.MaxValue);

        NeighborIndexes = Enumerable.Range(0, 4)
                                    .Shuffle()
                                    .ToArray();
        Sync = new AutoReleasingMonitor();

        //create nodes, assign walls
        for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
                PathNodes[x, y] = new PathNode(x, y);

        foreach (var tile in map.Tiles.Flatten())
            if (tile.IsWall)
                PathNodes[tile.X, tile.Y].IsWall = true;
        
        foreach(var pt in blacklistedPoints)
            PathNodes[pt.X, pt.Y].IsBlackListed = true;
        
        //assign node neighbors
        foreach (var pathNode in PathNodes.Flatten())
            foreach (var point in pathNode.GenerateCardinalPoints())
                if (WithinGrid(point))
                {
                    var relation = (int)point.DirectionalRelationTo(pathNode);
                    pathNode.Neighbors[relation] = PathNodes[point.X, point.Y];
                }
    }
    
    public Stack<IPoint> FindPath(
        IPoint start,
        IPoint end,
        PathfinderOptions options)
    {
        //if the end is blacklisted, we're never going to find a path to it
        //return empty path
        if(PathNodes[end.X, end.Y].IsBlackListed)
            return new Stack<IPoint>();
        
        //if we're standing on the end already
        //return empty path
        if (PointEqualityComparer.Instance.Equals(start, end))
            return new Stack<IPoint>();

        //if we're standing next to the end
        //return a path with the end as the only point
        if (start.DistanceFrom(end) == 1)
            return new Stack<IPoint>([end]);

        using var @lock = Sync.Enter();
        
        //reset queue
        PriortyQueue.Clear();
        
        //prepare nodes
        foreach (var node in PathNodes.Flatten())
        {
            node.Reset();
            
            if (options.MaxRadius.HasValue && (start.DistanceFrom(node) > options.MaxRadius.Value))
                node.Closed = true;

            if (options.BlockedPoints.Contains(node))
                node.IsBlocked = true;
        }

        var path = InnerFindPath(start, end, options.IgnoreWalls);
        
        return path;
    }
    
    public Direction FindRandomDirection(IPoint start, PathfinderOptions options)
    {
        var points = start.GenerateCardinalPoints()
                          .Shuffle();

        foreach (var point in points)
        {
            if (!WithinGrid(point))
                continue;
            
            var node = PathNodes[point.X, point.Y];

            if (node.IsWall || node.IsBlackListed || node.IsBlocked)
                continue;
            
            return point.DirectionalRelationTo(start);
        }
        
        return Direction.Invalid;
    }
    
    private IEnumerable<IPoint> GetParentChain(PathNode pathNode)
    {
        while (pathNode.Parent != null)
        {
            yield return pathNode;

            pathNode = pathNode.Parent;
        }
    }

    private Stack<IPoint> InnerFindPath(IPoint start, IPoint end, bool ignoreWalls)
    {
        var startNode = PathNodes[start.X, start.Y];
        var endNode = PathNodes[end.X, end.Y];
        PriortyQueue.Enqueue(startNode, 0);

        while (PriortyQueue.Count > 0)
        {
            var node = PriortyQueue.Dequeue();

            //dont consider closed nodes
            if (node.Closed)
                continue;

            //for each undiscovered walkable neighbor, set it's parent and add it to the queue
            for (var i = 0; i < 4; i++)
            {
                //get the neighbor
                var neighbor = node.Neighbors[NeighborIndexes[i]];

                //dont consider closed nodes
                //dont reconsider opened nodes
                if ((neighbor == null) || neighbor.Closed || neighbor.Open)
                    continue;

                //if we locate the end, set parent and break out
                //we're ok with this even if the end is inside a wall or blocked
                if (neighbor.Equals(endNode))
                {
                    neighbor.Parent = node;

                    return new Stack<IPoint>(GetParentChain(endNode));
                }
                
                //don't add walls unless ignoring walls
                //dont add blocked nodes
                if (!neighbor.IsWalkable(ignoreWalls))
                    continue;

                neighbor.Parent = node;
                PriortyQueue.Enqueue(neighbor, neighbor.DistanceFrom(start) + neighbor.DistanceFrom(end));
                neighbor.Open = true;
            }

            node.Closed = true;
            node.Open = false;
        }

        return new Stack<IPoint>(GetParentChain(endNode));
    }

    private bool WithinGrid<TPoint>(TPoint point) where TPoint: IPoint
        => (point.X >= 0) && (point.X < Width) && (point.Y >= 0) && (point.Y < Height);
}