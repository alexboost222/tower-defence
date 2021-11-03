using System;
using Models.Projectiles;
using Models.ProjectileTargets;
using UnityEngine;

namespace Models.Guns
{
    public class GunsFactory
    {
        public float MachineGunFireDelay { get; set; }

        public float MachineGunFireRange { get; set; }

        public void ApplyConfig(IGunsFactoryConfig config)
        {
            MachineGunFireDelay = config.MachineGunFireDelay;

            MachineGunFireRange = config.MachineGunFireRange;
        }

        public Gun CreateMachineGun(Vector3 position, Func<IProjectileTarget, Vector3, ProjectileBase> projectileGenerator)
        {
            return new Gun(position, projectileGenerator)
            {
                FireDelay = MachineGunFireDelay,
                FireRange = MachineGunFireRange
            };
        }
    }
}