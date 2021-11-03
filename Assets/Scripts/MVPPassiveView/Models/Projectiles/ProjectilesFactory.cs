using MVPPassiveView.Models.ProjectileTargets;
using UnityEngine;

namespace MVPPassiveView.Models.Projectiles
{
    public class ProjectilesFactory
    {
        public float BulletVelocity { get; set; }

        public void ApplyConfig(IProjectilesFactoryConfig config)
        {
            BulletVelocity = config.BulletVelocity;
        }

        public ProjectileBase CreateBullet(IProjectileTarget target, Vector3 position) =>
            new LinearProjectile(target, BulletVelocity, position);
    }
}