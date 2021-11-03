using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Views;
using UnityEngine;

namespace MVPPassiveView.Presenters
{
    public class ProjectilePresenter: PresenterBase
    {
        private readonly ProjectileBase _model;
        private readonly ProjectileView _view;

        public ProjectilePresenter(ProjectileBase model, ProjectileView view) : base(model, view)
        {
            _model = model;

            _model.PositionChanged += OnPositionChanged;
            _model.ReachedTarget += OnReachedTarget;
            
            _view = view;

            _view.Position = model.Position;
            _view.UpdateHappened += OnViewUpdateHappened;
        }

        private void OnPositionChanged(Vector3 position) => _view.Position = position;

        private void OnReachedTarget()
        {
            _view.HandleReachedTarget();
            _model.Destroy();
        }

        private void OnViewUpdateHappened(float deltaTime) => _model.Update(deltaTime);
    }
}