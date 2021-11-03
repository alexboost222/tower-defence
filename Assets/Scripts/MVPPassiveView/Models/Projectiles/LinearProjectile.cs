using MVPPassiveView.Models.ProjectileTargets;
using UnityEngine;

namespace MVPPassiveView.Models.Projectiles
{
    public class LinearProjectile : ProjectileBase
    {
        public LinearProjectile(IProjectileTarget target, float velocity, Vector3 position) : base(target, velocity, position)
        {
        }

        protected override void UpdateInternal(float deltaTime)
        {
            float distanceToTarget = Vector3.Distance(Position, Target.Position);

            float distanceDuringUpdate = Velocity * deltaTime;

            if (distanceToTarget <= distanceDuringUpdate)
            {
                Position = Target.Position;
                return;
            }

            Position += (Target.Position - Position).normalized * distanceDuringUpdate;
        }
    }
}