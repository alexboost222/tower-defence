using Models.Projectiles;
using UnityEngine;
using Views;

namespace Presenters
{
    public class ProjectilePresenter
    {
        private readonly ProjectileBase _model;
        private readonly ProjectileView _view;

        public ProjectilePresenter(ProjectileBase model, ProjectileView view)
        {
            _model = model;

            _model.PositionChanged += OnPositionChanged;
            _model.ReachedTarget += OnReachedTarget;
            
            _view = view;

            _view.UpdateHappened += OnViewUpdateHappened;

            _view.Position = model.Position;
        }

        private void OnPositionChanged(Vector3 position) => _view.Position = position;

        private void OnReachedTarget() => _view.HandleReachedTarget();

        private void OnViewUpdateHappened(float deltaTime) => _model.UpdatePosition(deltaTime);
    }
}