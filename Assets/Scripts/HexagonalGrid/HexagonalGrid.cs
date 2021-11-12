using System;
using System.Collections.Generic;
using HexagonalGrid.TMP;
using UnityEngine;

namespace HexagonalGrid
{
    [DisallowMultipleComponent]
    public class HexagonalGrid : MonoBehaviour
    {
        [SerializeField] private int radius;

        [SerializeField] private float hexagonSize;

        [SerializeField] private HexagonInSpaceView viewTemplate;

        private readonly List<HexagonInSpaceController> _map = new List<HexagonInSpaceController>();

        private void Awake() => GenerateNewMap();

        private void GenerateNewMap()
        {
            foreach (HexagonInSpaceController controller in _map) controller.Destroy();
            
            _map.Clear();
            
            _map.AddRange(GenerateMap());
        }

        private IEnumerable<HexagonInSpaceController> GenerateMap()
        {
            List<HexagonInSpaceController> map = new List<HexagonInSpaceController>();

            int internalMapRadius = radius- 1;

            for (int q = -internalMapRadius; q <= internalMapRadius; q++)
            {
                int r1 = Math.Max(-internalMapRadius, -q - internalMapRadius);
                int r2 = Math.Min(internalMapRadius, -q + internalMapRadius);

                for (int r = r1; r <= r2; r++)
                {
                    HexagonInSpace model = new HexagonInSpace(q, r, hexagonSize);
                    HexagonInSpaceView view = Instantiate(viewTemplate, transform);
                    map.Add(new HexagonInSpaceController(model, view));
                }
            }

            return map;
        }
    }
}