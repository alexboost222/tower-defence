using System;
using Models.Guns;
using Models.Projectiles;
using Models.ProjectileTargets;
using UnityEngine;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    public class ComposeFactory : MonoBehaviour
    {
        [SerializeField] private BulletCompose bulletComposeTemplate;
        [SerializeField] private MachineGunCompose machineGunComposeTemplate;

        public void CreateBulletCompose(ProjectileBase model)
        {
            BulletCompose bulletCompose = Instantiate(bulletComposeTemplate);

            bulletCompose.Init(model);
        }

        public void CreateMachineGunCompose(Gun model, Action<ProjectileBase> shotFiredHandler)
        {
            MachineGunCompose machineGunCompose = Instantiate(machineGunComposeTemplate);
            machineGunCompose.Init(model, shotFiredHandler);
        }
    }
}