using System;
using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Models.ProjectileTargets;
using UnityEngine;

namespace MVPPassiveView.Models.Guns
{
    public class Gun : ModelBase
    {
        public event Action<ProjectileBase> ShotFired;

        private float _timeToNextShot;

        private readonly Func<IProjectileTarget, Vector3, ProjectileBase> _projectileGenerator;

        public Gun(Vector3 position, Func<IProjectileTarget, Vector3, ProjectileBase> projectileGenerator)
        {
            Position = position;
            _projectileGenerator = projectileGenerator;
        }

        public float FireDelay { get; set; }

        public float FireRange { get; set; }

        public IProjectileTarget Target { get; set; }

        public Vector3 Position { get; }

        public void Update(float deltaTime)
        {
            if (!IsDestroyed) UpdateInternal(deltaTime);
        }

        private void UpdateInternal(float deltaTime)
        {
            _timeToNextShot -= deltaTime;

            if (CheckIfReadyToShoot()) Shoot();
        }

        private bool CheckIfReadyToShoot() => !IsDestroyed && _timeToNextShot <= 0 && Target != null &&
                                              Vector3.Distance(Position, Target.Position) <= FireRange;

        private void Shoot()
        {
            if (IsDestroyed) return;
            
            ShotFired?.Invoke(_projectileGenerator(Target, Position));
            _timeToNextShot = FireDelay;
        }
    }
}