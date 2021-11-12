using System;
using System.Collections.Generic;
using UnityEngine;

namespace HexGrid
{
    [DisallowMultipleComponent]
    public class HexagonalGrid : MonoBehaviour
    {
        public event Action MapChanged;

        [SerializeField]
        private int radius;

        [SerializeField]
        private float hexSize;

        private HashSet<Hex> _map = new HashSet<Hex>();

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

        public float HexSize => hexSize;

        public MeshData GetMeshData()
        {
            Vector3[] vertices = new Vector3[_map.Count * 7];
            int[] triangles = new int[_map.Count * 18];
            Vector3[] normals = new Vector3[vertices.Length];
            Vector2[] uv = new Vector2[vertices.Length];

            for(int normalIndex = 0; normalIndex < normals.Length; ++normalIndex)
                normals[normalIndex] = Vector3.up;

            float sqrtThree = Mathf.Sqrt(3);

            int verticesCounter = 0;
            int trianglesCounter = 0;

            foreach (Hex hex in _map)
            {
                float xCenter = HexSize * (1.5f * hex.Q);
                float yCenter = HexSize * (sqrtThree * 0.5f * hex.Q + sqrtThree * hex.R);

                vertices[verticesCounter] = new Vector3(xCenter, 0, yCenter);
                uv[verticesCounter] = UVTemplate[verticesCounter % 7];

                for (int cornerNumber = 0; cornerNumber < 6; ++cornerNumber)
                {
                    int vertexNumber = verticesCounter + cornerNumber + 1;
                    vertices[vertexNumber] = GetCorner(xCenter, yCenter, HexSize, cornerNumber);
                    uv[vertexNumber] = UVTemplate[vertexNumber % 7];
                }

                for (int triangleNumber = 0; triangleNumber < 5; ++triangleNumber)
                {
                    triangles[trianglesCounter++] = verticesCounter;
                    triangles[trianglesCounter++] = verticesCounter + 2 + triangleNumber;
                    triangles[trianglesCounter++] = verticesCounter + 1 + triangleNumber;
                }
                
                triangles[trianglesCounter++] = verticesCounter;
                triangles[trianglesCounter++] = verticesCounter + 1;
                triangles[trianglesCounter++] = verticesCounter + 6;

                verticesCounter += 7;
            }

            return new MeshData(vertices, triangles, normals, uv);

            static Vector3 GetCorner(float xCenter, float yCenter, float size, int cornerNumber)
            {
                int angleInDegrees = 60 * cornerNumber;
                float angleInRadians = Mathf.PI / 180 * angleInDegrees;
                return new Vector3(xCenter + size * Mathf.Cos(angleInRadians), 0, yCenter + size * Mathf.Sin(angleInRadians));
            }
        }

        private void Awake() => GenerateNewMap();

        private void HandleRadiusUpdate() => GenerateNewMap();

        private void GenerateNewMap()
        {
            _map = GenerateMap(radius);
            MapChanged?.Invoke();
        }

        private static HashSet<Hex> GenerateMap(int mapRadius)
        {
            HashSet<Hex> map = new HashSet<Hex>();

            int internalMapRadius = mapRadius - 1;

            for (int q = -internalMapRadius; q <= internalMapRadius; q++)
            {
                int r1 = Math.Max(-internalMapRadius, -q - internalMapRadius);
                int r2 = Math.Min(internalMapRadius, -q + internalMapRadius);

                for (int r = r1; r <= r2; r++) map.Add(new Hex(q, r));
            }

            return map;
        }
    }
}