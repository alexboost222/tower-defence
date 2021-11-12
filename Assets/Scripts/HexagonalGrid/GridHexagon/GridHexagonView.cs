using Geometry;
using UnityEngine;

namespace HexagonalGrid.GridHexagon
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class GridHexagonView : MonoBehaviour
    {
        [SerializeField] private Material defaultMaterial;
        
        [SerializeField] private Material highlightedMaterial;
        
        private MeshFilter _meshFilter;
        private MeshRenderer _meshRenderer;
        
        public Vector3 LocalPosition
        {
            set => transform.localPosition = value;
        }

        public void ApplyMeshData(MeshData meshData)
        {
            if (_meshFilter.mesh == null) _meshFilter.mesh = new Mesh();
            else _meshFilter.mesh.Clear();

            Mesh mesh = _meshFilter.mesh;

            mesh.vertices = meshData.Vertices;
            mesh.triangles = meshData.Triangles;
            mesh.normals = meshData.Normals;
            mesh.uv = meshData.UV;
        }

        public void Destroy() => Destroy(gameObject);

        public void ApplyDefaultState() => _meshRenderer.material = defaultMaterial;

        public void ApplyHighlightedState() => _meshRenderer.material = highlightedMaterial;

        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}