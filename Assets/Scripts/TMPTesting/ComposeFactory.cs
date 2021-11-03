using System;
using MVPPassiveView.Models.Guns;
using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Models.ProjectileTargets;
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
        [SerializeField] private DummyTargetCompose dummyTargetComposeTemplate;

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

        public void CreateDummyTargetCompose(DummyTarget model)
        {
            DummyTargetCompose dummyTargetCompose = Instantiate(dummyTargetComposeTemplate);
            dummyTargetCompose.Init(model);
        }
    }
}