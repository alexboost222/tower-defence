using System;
using System.Runtime.Serialization;

namespace HexGrid
{
    [Serializable]
    public class InvalidHexCoordinatesException : Exception
    {
        public InvalidHexCoordinatesException(int q, int r, int s) : base($"Q={q} + R={r} + S={s} is not zero.")
        {
            Q = q;
            R = r;
            S = s;
        }

        public InvalidHexCoordinatesException(int q, int r, int s, string message) : base(message)
        {
            Q = q;
            R = r;
            S = s;
        }

        public InvalidHexCoordinatesException(int q, int r, int s, string message, Exception innerException)
            : base(message, innerException)
        {
            Q = q;
            R = r;
            S = s;
        }
        
        protected InvalidHexCoordinatesException() : base()
        {
        }

        protected InvalidHexCoordinatesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int Q { get; }

        public int R { get; }

        public int S { get; }
    }
}