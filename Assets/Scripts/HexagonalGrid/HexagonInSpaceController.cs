using Geometry;

namespace HexagonalGrid
{
    public class HexagonInSpaceController
    {
        private readonly HexagonInSpace _model;
        private readonly HexagonInSpaceView _view;

        public HexagonInSpaceController(HexagonInSpace model, HexagonInSpaceView view)
        {
            _model = model;
            _view = view;

            _view.LocalPosition = _model.LocalPosition;
            _view.ApplyMeshData(_model.GetMeshData());
        }

        public void Destroy() => _view.Destroy();
    }
}