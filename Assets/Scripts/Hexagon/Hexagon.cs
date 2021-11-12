using System;
using System.Collections.Generic;

namespace Hexagon
{
    public readonly struct Hexagon
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

        private static readonly Dictionary<HexDirection, Hexagon> OffsetByDirection = new Dictionary<HexDirection, Hexagon>
        {
            {HexDirection.North, new Hexagon(0, -1, 1)},
            {HexDirection.NorthEast, new Hexagon(1, -1, 0)},
            {HexDirection.SouthEast, new Hexagon(1, 0, -1)},
            {HexDirection.South, new Hexagon(0, 1, -1)},
            {HexDirection.SouthWest, new Hexagon(-1, 1, 0)},
            {HexDirection.NorthWest, new Hexagon(-1, 0, 1)}
        };
        
        public Hexagon(int q, int r, int s)
        {
            if (q + r + s != 0) throw new InvalidHexagonCoordinatesException(q, r, s);

            Q = q;
            R = r;
            S = s;
            Length = CalculateLength(Q, R, S);
        }

        public Hexagon(int q, int r)
        {
            Q = q;
            R = r;
            S = -(R + Q);
            Length = CalculateLength(Q, R, S);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Hexagon other)) return false;

            return this == other;
        }

        public override int GetHashCode() => (Q * 106039 + R) & 0xffff;

        public static bool operator ==(Hexagon a, Hexagon b) => a.Q == b.Q && a.R == b.R && a.S == b.S;

        public static bool operator !=(Hexagon a, Hexagon b) => !(a == b);

        public static Hexagon operator +(Hexagon a, Hexagon b) => new Hexagon(a.Q + b.Q, a.R + b.R, a.S + b.S);
        
        public static Hexagon operator -(Hexagon a, Hexagon b) => new Hexagon(a.Q - b.Q, a.R - b.R, a.S - b.S);
        
        public static Hexagon operator *(Hexagon a, Hexagon b) => new Hexagon(a.Q * b.Q, a.R * b.R, a.S * b.S);

        public static int Distance(Hexagon a, Hexagon b) => (a - b).Length;

        public static Hexagon GetNeighbor(Hexagon hexagon, HexDirection direction) => hexagon + OffsetByDirection[direction];
        
        private static int CalculateLength(int q, int r, int s) => (Math.Abs(q) + Math.Abs(r) + Math.Abs(s)) / 2;
    }
}