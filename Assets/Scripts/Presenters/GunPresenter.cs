using System;
using Models.Guns;
using Models.Projectiles;
using Models.ProjectileTargets;
using Views;

namespace Presenters
{
    public class GunPresenter
    {
        private readonly Gun _model;
        private readonly GunView _view;
        private readonly Action<ProjectileBase> _shotFiredHandler;

        public GunPresenter(Gun model, GunView view, Action<ProjectileBase> shotFiredHandler)
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