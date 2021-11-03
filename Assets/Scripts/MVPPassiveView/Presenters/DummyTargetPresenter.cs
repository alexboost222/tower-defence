using MVPPassiveView.Models.ProjectileTargets;
using MVPPassiveView.Views;

namespace MVPPassiveView.Presenters
{
    public class DummyTargetPresenter : PresenterBase
    {
        private readonly DummyTarget _model;
        private readonly DummyTargetView _view;

        public DummyTargetPresenter(DummyTarget model, DummyTargetView view) : base(model, view)
        {
            _model = model;
            _view = view;

            _view.Position = _model.Position;
        }
    }
}