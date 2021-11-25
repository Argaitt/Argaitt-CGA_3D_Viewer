namespace Laba1.Models
{
    public class Polygon
    {
        public Polygon(int minVertexCount = 3)
        {
            VertexIndices = new int?[minVertexCount];
            TextureIndices = new int?[minVertexCount];
            NormalIndices = new int?[minVertexCount];
        }

        public int?[] VertexIndices { get; set; }

        public int?[] TextureIndices { get; set; }

        public int?[] NormalIndices { get; set; }
    }
}
