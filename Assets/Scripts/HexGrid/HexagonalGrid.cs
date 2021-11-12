using System;
using System.Collections.Generic;
using Helpers;
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

        public float HexSize => hexSize;

        public (IReadOnlyCollection<Vector3> vertices, IReadOnlyCollection<int>triangles, IReadOnlyCollection<Vector3> normals) GetMeshData()
        {
            Vector3[] vertices = new Vector3[_map.Count * 7];
            int[] triangles = new int[_map.Count * 18];
            Vector3[] normals = new Vector3[_map.Count * 7];

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

                for (int cornerNumber = 0; cornerNumber < 6; ++cornerNumber)
                    vertices[verticesCounter + cornerNumber + 1] = GetCorner(xCenter, yCenter, HexSize, cornerNumber);

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

            return (vertices, triangles, normals);

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