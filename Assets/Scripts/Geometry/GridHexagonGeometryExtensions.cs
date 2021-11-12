using System.Collections.Generic;
using HexagonalGrid;
using HexagonalGrid.GridHexagon;
using UnityEngine;

namespace Geometry
{
    public static class GridHexagonGeometryExtensions
    {
        private static readonly Dictionary<int, Vector2> UVTemplate = new Dictionary<int, Vector2>
        {
            {0, new Vector2(0.50f, 0.50f)},
            {1, new Vector2(1.00f, 0.50f)},
            {2, new Vector2(0.75f, 0.00f)},
            {3, new Vector2(0.25f, 0.00f)},
            {4, new Vector2(0.00f, 0.50f)},
            {5, new Vector2(0.25f, 1.00f)},
            {6, new Vector2(0.75f, 1.00f)}
        };

        public static MeshData GetMeshData(this GridHexagon gridHexagon)
        {
            Vector3[] vertices = new Vector3[7];
            int[] triangles = new int[18];
            Vector3[] normals = new Vector3[vertices.Length];
            Vector2[] uv = new Vector2[vertices.Length];

            // Generating normals always facing up in local coordinate system
            for (int normalIndex = 0; normalIndex < normals.Length; ++normalIndex)
                normals[normalIndex] = Vector3.up;

            // Zero vertex ia a center of the hexagon and perfectly alligned with it's coordinate system zero 
            vertices[0] = Vector3.zero;
            uv[0] = UVTemplate[0];

            for (int cornerNumber = 0; cornerNumber < 6; ++cornerNumber)
            {
                int vertexNumber = cornerNumber + 1;
                vertices[vertexNumber] = gridHexagon.GetCornerLocalPosition(cornerNumber);
                uv[vertexNumber] = UVTemplate[vertexNumber % 7];
            }

            int trianglesCounter = 0;

            for (int triangleNumber = 0; triangleNumber < 5; ++triangleNumber)
            {
                triangles[trianglesCounter++] = 0;
                triangles[trianglesCounter++] = triangleNumber + 2;
                triangles[trianglesCounter++] = triangleNumber + 1;
            }

            triangles[trianglesCounter++] = 0;
            triangles[trianglesCounter++] = 1;
            triangles[trianglesCounter] = 6;

            return new MeshData(vertices, triangles, normals, uv);
        }
    }
}