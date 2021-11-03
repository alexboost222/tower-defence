using Models.ProjectileTargets;
using Views;

namespace Presenters
{
    public class DummyTargetPresenter
    {
        private readonly DummyTarget _model;
        private readonly DummyTargetView _view;

        public DummyTargetPresenter(DummyTarget model, DummyTargetView view)
        {
            _model = model;
            _view = view;

            _view.Position = _model.Position;
        }
    }
}