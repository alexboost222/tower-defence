using Models.Guns;
using Views;

namespace Presenters
{
    public class GunPresenter
    {
        private Gun _model;
        private GunView _view;

        public GunPresenter(Gun model, GunView view)
        {
            _model = model;
            _view = view;

            _view.UpdateHappened += OnViewUpdateHappened;
        }

        private void OnViewUpdateHappened(float obj)
        {
            throw new System.NotImplementedException();
        }
    }
}