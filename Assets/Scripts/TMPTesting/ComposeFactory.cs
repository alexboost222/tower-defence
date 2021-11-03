using System;
using MVPPassiveView.Models.Guns;
using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Presenters;
using MVPPassiveView.Views;
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

        public GunView CreateMachineGunCompose(Gun model, Action<ProjectileBase> shotFiredHandler)
        {
            MachineGunCompose machineGunCompose = Instantiate(machineGunComposeTemplate);
            machineGunCompose.Init(model, shotFiredHandler);
            return machineGunCompose.View;
        }
    }
}