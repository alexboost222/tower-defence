using Models.ProjectileTargets;
using UnityEngine;

namespace Models.Projectiles
{
    public class LinearProjectile : ProjectileBase
    {
        public LinearProjectile(IProjectileTarget target, float velocity, Vector3 position) : base(target, velocity, position)
        {
        }

        public override void UpdatePosition(float deltaTime)
        {
            float distanceToTarget = Vector3.Distance(Position, Target.Position);

            float distanceDuringUpdate = Velocity * deltaTime;

            if (distanceToTarget <= distanceDuringUpdate)
            {
                Position = Target.Position;
                return;
            }

            Position += (Target.Position - Position).normalized * Velocity;
        }
    }
}