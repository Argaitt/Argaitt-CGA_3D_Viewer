using System.Numerics;

namespace Laba1.Models
{
    public class ObjectInfo
    {
        public Vector4[] Vertices { get; set; }

        public Vector4[] TextureVertices { get; set; }

        public Vector4[] NormalVectors { get; set; }

        public Polygon[] Polygons { get; set; }
    }
}
