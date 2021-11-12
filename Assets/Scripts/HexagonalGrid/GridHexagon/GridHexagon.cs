using System;
using UnityEngine;

namespace HexagonalGrid.GridHexagon
{
    public class GridHexagon
    {
        public enum GridHexagonState
        {
            Default,
            Highlighted
        }

        public event Action StateChanged; 

        private readonly HexagonInSpace _hexagonInSpace;

        private GridHexagonState _state;

        public GridHexagon(int q, int r, float size, GridHexagonState state)
        {
            _hexagonInSpace = new HexagonInSpace(q, r, size);
            _state = state;
        }

        public Vector3 LocalPosition => _hexagonInSpace.LocalPosition;

        public float Size => _hexagonInSpace.Size;

        public GridHexagonState State
        {
            get => _state;
            set
            {
                if (_state == value) return;

                _state = value;
                StateChanged?.Invoke();
            }
        }

        public Vector3 GetCornerLocalPosition(int cornerNumber) => _hexagonInSpace.GetCornerLocalPosition(cornerNumber);
    }
}