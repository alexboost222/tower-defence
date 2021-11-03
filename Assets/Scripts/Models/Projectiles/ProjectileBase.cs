using System;
using Models.ProjectileTargets;
using UnityEngine;

namespace Models.Projectiles
{
    public abstract class ProjectileBase
    {
        protected readonly IProjectileTarget Target;
        protected readonly float Velocity;

        private Vector3 _position;

        public event Action<Vector3> PositionChanged;
        public event Action ReachedTarget;

        public ProjectileBase(IProjectileTarget target, float velocity, Vector3 position)
        {
            Target = target;
            Velocity = velocity;
            Position = position;
        }

        public Vector3 Position
        {
            get => _position;
            protected set
            {
                _position = value;
                PositionChanged?.Invoke(value);
                
                if (value == Target.Position) ReachedTarget?.Invoke();
            }
        }

        public abstract void UpdatePosition(float deltaTime);
    }
}