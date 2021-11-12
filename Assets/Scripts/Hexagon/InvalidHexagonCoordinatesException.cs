using System;
using System.Runtime.Serialization;

namespace Hexagon
{
    [Serializable]
    public class InvalidHexagonCoordinatesException : Exception
    {
        public InvalidHexagonCoordinatesException(int q, int r, int s) : base($"Q={q} + R={r} + S={s} is not zero.")
        {
            Q = q;
            R = r;
            S = s;
        }

        public InvalidHexagonCoordinatesException(int q, int r, int s, string message) : base(message)
        {
            Q = q;
            R = r;
            S = s;
        }

        public InvalidHexagonCoordinatesException(int q, int r, int s, string message, Exception innerException)
            : base(message, innerException)
        {
            Q = q;
            R = r;
            S = s;
        }
        
        protected InvalidHexagonCoordinatesException() : base()
        {
        }

        protected InvalidHexagonCoordinatesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public int Q { get; }

        public int R { get; }

        public int S { get; }
    }
}