using UnityEngine;

namespace HexGrid
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(HexagonalGrid))]
    public class HexagonalGridView : MonoBehaviour
    {
        private MeshFilter _meshFilter;

        private HexagonalGrid _model;

        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();

            _model = GetComponent<HexagonalGrid>();

            OnModelMapChanged();

            _model.MapChanged += OnModelMapChanged;
        }

        private void OnDestroy() => _model.MapChanged -= OnModelMapChanged;

        private void OnModelMapChanged() => ApplyMeshData(_model.GetMeshData());

        private void ApplyMeshData(MeshData meshData)
        {
            if (_meshFilter.mesh == null) _meshFilter.mesh = new Mesh();
            else _meshFilter.mesh.Clear();

            Mesh mesh = _meshFilter.mesh;
            
            mesh.vertices = meshData.Vertices;
            mesh.triangles = meshData.Triangles;
            mesh.normals = meshData.Normals;
            mesh.uv = meshData.UV;
        }
    }
}