using System.Collections;
using System.IO;
using System.Text;
using Chaos.Common.Definitions;
using Chaos.Extensions.Geometry;
using Chaos.Geometry;
using Chaos.Geometry.Abstractions;
using Chaos.IO.Memory;

namespace Ouroboros.Model;

public sealed record Tile : IPoint
{
    public short Background { get; init; }
    public short LeftForeground { get; init; }
    public short RightForeground { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
    public bool IsWall { get; init; }
}

public sealed class Map : IRectangle
{
    private static readonly byte[] SOTP;
    public short Id { get; init; }
    public MapFlags Flags { get; set; }
    public string Name { get; set; }
    public Tile[,] Tiles { get; init; }
    public bool CanUseSkills { get; set; } = true;
    public bool CanUseSpells { get; set; } = true;

    static Map() => SOTP = new byte[ushort.MaxValue];

    public Map(
        short id,
        string name,
        int width,
        int height,
        MapFlags? flags = null)
    {
        Id = id;
        Name = name;
        Width = width;
        Height = height;
        Right = width - 1;
        Bottom = height - 1;
        Tiles = new Tile[width, height];
        Flags = flags ?? MapFlags.None;
    }

    public void SetPartialData(ushort yIndex, byte[] data)
    {
        var reader = new SpanReader(Encoding.Default, data);
        
        for (var x = 0; x < Width; x++)
        {
            var bg = reader.ReadInt16();
            var lf = reader.ReadInt16();
            var rf = reader.ReadInt16();

            Tiles[x, yIndex] = new Tile
            {
                X = x,
                Y = yIndex,
                Background = bg,
                LeftForeground = lf,
                RightForeground = rf,
                IsWall = ((lf > 0) && ((SOTP[lf - 1] & 15) == 15)) || ((rf > 0) && ((SOTP[rf - 1] & 15) == 15))
            };
        }
    }
    
    public bool TrySetData(string path)
    {
        if (!File.Exists(path))
            return false;
        
        var data = File.ReadAllBytes(path);
        SetData(data);

        return true;
    }
    
    public void SetData(byte[] data)
    {
        var reader = new SpanReader(Encoding.Default, data);
        
        for (var y = 0; y < Height; y++)
            for (var x = 0; x < Width; x++)
            {
                var bg = reader.ReadInt16();
                var lf = reader.ReadInt16();
                var rf = reader.ReadInt16();

                Tiles[x, y] = new Tile
                {
                    X = x,
                    Y = y,
                    Background = bg,
                    LeftForeground = lf,
                    RightForeground = rf
                };
            }
    }

    public bool IsWall(IPoint point) => !this.Contains(point) || Tiles[point.X, point.Y].IsWall;
    
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