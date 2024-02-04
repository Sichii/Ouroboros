using System.Collections;
using Chaos.Common.Definitions;
using Chaos.Geometry;
using Chaos.Geometry.Abstractions;

namespace Ouroboros.Model;

public record Tile
{
    public short Background { get; init; }
    public short LeftForeground { get; init; }
    public short RightForeground { get; init; }

    //TODO: Implement sotp
    public bool IsWall => false;
}

public class Map : IRectangle
{
    public ushort Id { get; init; }
    public MapFlags Flags { get; set; }
    public required string Name { get; set; }
    public Tile[,] Tiles { get; init; } = new Tile[0, 0];
    public bool CanUseSkills { get; set; } = true;
    public bool CanUseSpells { get; set; } = true;
    
    #region IRectangle
    /// <inheritdoc />
    public IEnumerator<IPoint> GetEnumerator() => Vertices.GetEnumerator();

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    /// <inheritdoc />
    public IReadOnlyList<IPoint> Vertices
        => new List<IPoint>
        {
            new Point(Left, Top),
            new Point(Right, Top),
            new Point(Right, Bottom),
            new Point(Left, Bottom)
        };

    /// <inheritdoc />
    public int Area => Width * Height;

    /// <inheritdoc />
    public int Bottom { get; init; }

    /// <inheritdoc />
    public int Height { get; init; }

    /// <inheritdoc />
    public int Left { get; init; }

    /// <inheritdoc />
    public int Right { get; init; }

    /// <inheritdoc />
    public int Top { get; init; }

    /// <inheritdoc />
    public int Width { get; init; }
    #endregion
}