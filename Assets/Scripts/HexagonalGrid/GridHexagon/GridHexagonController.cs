using System;
using Geometry;

namespace HexagonalGrid.GridHexagon
{
    public class GridHexagonController
    {
        private readonly GridHexagon _model;
        private readonly GridHexagonView _view;

        public GridHexagonController(GridHexagon model, GridHexagonView view)
        {
            _model = model;
            _model.StateChanged += OnModelStateChanged;
            
            _view = view;
            _view.LocalPosition = _model.LocalPosition;
            _view.ApplyMeshData(_model.GetMeshData());
            ApplyModelStateToView();
        }

        public void Destroy()
        {
            _model.StateChanged -= OnModelStateChanged;
            _view.Destroy();
        }

        public void ApplyState(GridHexagon.GridHexagonState state) => _model.State = state;

        private void OnModelStateChanged() => ApplyModelStateToView();

        private void ApplyModelStateToView()
        {
            switch (_model.State)
            {
                case GridHexagon.GridHexagonState.Default:
                    _view.ApplyDefaultState();
                    break;
                case GridHexagon.GridHexagonState.Highlighted:
                    _view.ApplyHighlightedState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}