using System.Collections.Generic;
using System.Linq;
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

        private void OnModelMapChanged() => ApplyMesh(_model.GetMeshData());

        private void ApplyMesh(
            (IReadOnlyCollection<Vector3> vertices, IReadOnlyCollection<int>triangles, IReadOnlyCollection<Vector3>
                normals) meshData)
        {
            if (_meshFilter.mesh == null) _meshFilter.mesh = new Mesh();
            else _meshFilter.mesh.Clear();

            (IReadOnlyCollection<Vector3> vertices, IReadOnlyCollection<int> triangles,
                IReadOnlyCollection<Vector3> normals) = meshData;

            _meshFilter.mesh.vertices = vertices.ToArray();
            _meshFilter.mesh.triangles = triangles.ToArray();
            _meshFilter.mesh.normals = normals.ToArray();
        }
    }
}