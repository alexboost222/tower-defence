using System;
using System.Collections.Generic;

namespace HexGrid
{
    public struct Hex
    {
        public enum HexDirection
        {
            North = 0,
            NorthEast = 1,
            SouthEast = 2,
            South = 3,
            SouthWest = 4,
            NorthWest = 5
        }
        
        public readonly int Q;
        
        public readonly int R;
        
        public readonly int S;

        public readonly int Length;

        private static readonly Dictionary<HexDirection, Hex> OffsetByDirection = new Dictionary<HexDirection, Hex>
        {
            {HexDirection.North, new Hex(0, -1, 1)},
            {HexDirection.NorthEast, new Hex(1, -1, 0)},
            {HexDirection.SouthEast, new Hex(1, 0, -1)},
            {HexDirection.South, new Hex(0, 1, -1)},
            {HexDirection.SouthWest, new Hex(-1, 1, 0)},
            {HexDirection.NorthWest, new Hex(-1, 0, 1)}
        };
        
        public Hex(int q, int r, int s)
        {
            if (q + r + s != 0) throw new InvalidHexCoordinatesException(q, r, s);

            Q = q;
            R = r;
            S = s;
            Length = CalculateLength(Q, R, S);
        }

        public Hex(int q, int r)
        {
            Q = q;
            R = r;
            S = -(R + Q);
            Length = CalculateLength(Q, R, S);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Hex other)) return false;

            return this == other;
        }

        public override int GetHashCode() => (Q * 106039 + R) & 0xffff;

        public static bool operator ==(Hex a, Hex b) => a.Q == b.Q && a.R == b.R && a.S == b.S;

        public static bool operator !=(Hex a, Hex b) => !(a == b);

        public static Hex operator +(Hex a, Hex b) => new Hex(a.Q + b.Q, a.R + b.R, a.S + b.S);
        
        public static Hex operator -(Hex a, Hex b) => new Hex(a.Q - b.Q, a.R - b.R, a.S - b.S);
        
        public static Hex operator *(Hex a, Hex b) => new Hex(a.Q * b.Q, a.R * b.R, a.S * b.S);

        public static int Distance(Hex a, Hex b) => (a - b).Length;

        public static Hex GetNeighbor(Hex hex, HexDirection direction) => hex + OffsetByDirection[direction];
        
        private static int CalculateLength(int q, int r, int s) => (Math.Abs(q) + Math.Abs(r) + Math.Abs(s)) / 2;
    }
}