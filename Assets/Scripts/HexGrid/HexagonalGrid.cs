using System;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

namespace HexGrid
{
    [DisallowMultipleComponent]
    public class HexagonalGrid : MonoBehaviour
    {
        public event Action<IReadOnlyCollection<Hex>> MapChanged;
        
        [SerializeField] [OnEditorChangedCall("OnEditorRadiusChanged")]
        private int radius;

        [SerializeField] [OnEditorChangedCall("OnEditorHexSizeChanged")]
        private float hexSize;

        private HashSet<Hex> _map = new HashSet<Hex>();

        public int Radius
        {
            get => radius;
            set
            {
                if (radius == value) return;
                
                radius = value;
                _map = GenerateMap(radius);
                MapChanged?.Invoke(_map);
            }
        }
        
        public float HexSize
        {
            get => hexSize;
            set => hexSize = value;
        }

        public Vector3 Position => transform.position;

        public Quaternion Rotation => transform.rotation;

        public IReadOnlyCollection<Hex> Map => _map;

        private void OnEditorRadiusChanged() => Radius = radius;

        private void OnEditorHexSizeChanged() => HexSize = hexSize;

        private static HashSet<Hex> GenerateMap(int mapRadius)
        {
            HashSet<Hex> map = new HashSet<Hex>();

            for (int q = -mapRadius; q <= mapRadius; q++)
            {
                int r1 = Math.Max(-mapRadius, -q - mapRadius);
                int r2 = Math.Min(mapRadius, -q + mapRadius);
                
                for (int r = r1; r <= r2; r++) map.Add(new Hex(q, r));
            }

            return map;
        }
    }
}