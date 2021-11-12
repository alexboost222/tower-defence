using UnityEngine;

namespace HexagonalGrid
{
    public readonly struct HexagonInSpace
    {
        private readonly Hexagon.Hexagon _hexagon;
        
        public HexagonInSpace(int q, int r, float size)
        {
            _hexagon = new Hexagon.Hexagon(q, r);
            Size = size;
            LocalPosition = CalculateLocalPosition(q, r, size);
        }
        
        public float Size { get; }
        public Vector3 LocalPosition { get; }

        public Vector3 GetCornerLocalPosition(int cornerNumber)
        {
            int angleInDegrees = 60 * cornerNumber;
            float angleInRadians = Mathf.PI / 180 * angleInDegrees;
            return new Vector3(Size * Mathf.Cos(angleInRadians), 0, Size * Mathf.Sin(angleInRadians));
        }

        private static Vector3 CalculateLocalPosition(int q, int r, float size)
        {
            float sqrtThree = Mathf.Sqrt(3);

            return new Vector3(size * (1.5f * q), 0, size * sqrtThree * (0.5f * q + r));
        }
    }
}