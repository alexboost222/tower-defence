using System;
using UnityEngine;

namespace HexagonalGrid
{
    [DisallowMultipleComponent]
    public class HexagonalGridView : MonoBehaviour
    {
        public event Action ApplyHighlightedModeCalled;
        
        public void ApplyHighlightedMode() => ApplyHighlightedModeCalled?.Invoke();
    }
}