using System.Collections.Generic;
using UnityEngine;

namespace HexGrid
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshRenderer))]
    public class HexagonalGridView : MonoBehaviour
    {
        [SerializeField] private HexagonalGrid model;
        
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            
            OnModelMapChanged(model.Map);
            
            model.MapChanged += OnModelMapChanged;
        }

        private void OnDestroy() => model.MapChanged -= OnModelMapChanged;

        private void OnModelMapChanged(IReadOnlyCollection<Hex> newMap)
        {
            List<Vector3> vertices = new List<Vector3>();

            foreach (Hex hex in newMap)
            {
                
            }
        }
    }
}