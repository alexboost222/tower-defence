using Geometry;
using UnityEngine;

namespace HexagonalGrid
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [DisallowMultipleComponent]
    public class HexagonInSpaceView : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        
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

        private void Awake() => _meshFilter = GetComponent<MeshFilter>();
    }
}