namespace HexagonalGrid
{
    public class HexagonalGridController
    {
        private readonly HexagonalGrid _model;
        private readonly HexagonalGridView _view;

        public HexagonalGridController(HexagonalGrid model, HexagonalGridView view)
        {
            _model = model;
            _view = view;
            _view.ApplyHighlightedModeCalled += OnApplyHighlightedModeCalled;
        }

        private void OnApplyHighlightedModeCalled() => _model.ApplyGlobalState(GridHexagon.GridHexagon.GridHexagonState.Highlighted);
    }
}