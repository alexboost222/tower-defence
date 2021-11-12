using UnityEngine;

namespace HexGrid
{
    public readonly struct MeshData
    {
        public readonly Vector3[] Vertices;
        public readonly int[] Triangles;
        public readonly Vector3[] Normals;
        public readonly Vector2[] UV;

        public MeshData(Vector3[] vertices, int[] triangles, Vector3[] normals, Vector2[] uv)
        {
            Vertices = vertices;
            Triangles = triangles;
            Normals = normals;
            UV = uv;
        }
    }
}