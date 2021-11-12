using System;
using System.Collections.Generic;
using HexagonalGrid.GridHexagon;

namespace HexagonalGrid
{
    public class HexagonalGrid
    {
        private readonly List<GridHexagonController> _map = new List<GridHexagonController>();
        
        private int _radius;
        
        private float _hexagonSize;

        public int Radius
        {
            get => _radius;
            set
            {
                if (_radius == value) return;

                _radius = value;
                GenerateNewMap();
            }
        }

        public float HexagonSize
        {
            get => _hexagonSize;
            set
            {
                if (_hexagonSize == value) return;

                _hexagonSize = value;
                GenerateNewMap();
            }
        }

        public void ApplyGlobalState(GridHexagon.GridHexagon.GridHexagonState state)
        {
            foreach (GridHexagonController gridHexagonController in _map)
            {
                gridHexagonController.ApplyState(state);
            }
        }

        private void GenerateNewMap()
        {
            ClearMap();

            _map.AddRange(GenerateMap());
        }

        private void ClearMap()
        {
            foreach (GridHexagonController controller in _map) controller.Destroy();

            _map.Clear();
        }

        private IEnumerable<GridHexagonController> GenerateMap()
        {
            List<GridHexagonController> map = new List<GridHexagonController>();

            int internalMapRadius = _radius - 1;

            for (int q = -internalMapRadius; q <= internalMapRadius; q++)
            {
                int r1 = Math.Max(-internalMapRadius, -q - internalMapRadius);
                int r2 = Math.Min(internalMapRadius, -q + internalMapRadius);

                for (int r = r1; r <= r2; r++)
                {
                    map.Add(GridHexagonFactory.Instance.Create(q, r, _hexagonSize,
                        GridHexagon.GridHexagon.GridHexagonState.Default));
                }
            }

            return map;
        }
    }
}