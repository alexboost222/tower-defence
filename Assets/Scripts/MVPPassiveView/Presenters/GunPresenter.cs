using System;
using MVPPassiveView.Models.Guns;
using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Models.ProjectileTargets;
using MVPPassiveView.Views;

namespace MVPPassiveView.Presenters
{
    public class GunPresenter : PresenterBase
    {
        private readonly Gun _model;
        private readonly GunView _view;
        private readonly Action<ProjectileBase> _shotFiredHandler;

        public GunPresenter(Gun model, GunView view, Action<ProjectileBase> shotFiredHandler) : base(model, view)
        {
            _model = model;
            _view = view;
            _shotFiredHandler = shotFiredHandler;

            _model.ShotFired += OnModelShotFired;

            _view.Position = _model.Position;
            _view.UpdateHappened += OnViewUpdateHappened;
            _view.TargetSet += OnViewTargetSet;
        }

        private void OnViewTargetSet(IProjectileTarget target) => _model.Target = target;

        private void OnModelShotFired(ProjectileBase projectileModel) => _shotFiredHandler(projectileModel);

        private void OnViewUpdateHappened(float deltaTime) => _model.Update(deltaTime);
    }
}