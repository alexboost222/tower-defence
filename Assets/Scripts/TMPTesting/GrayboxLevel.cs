using System.Collections.Generic;
using Config;
using MVPPassiveView.Models.Guns;
using MVPPassiveView.Models.Projectiles;
using MVPPassiveView.Models.ProjectileTargets;
using MVPPassiveView.Presenters;
using MVPPassiveView.Views;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ComposeFactory))]
    [RequireComponent(typeof(SimpleTargetPointer))]
    public class GrayboxLevel : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfig projectilesConfig;
        [SerializeField] private GunsConfig gunsConfig;

        private ComposeFactory _composeFactory;
        private SimpleTargetPointer _targetPointer;

        private ProjectilesFactory _projectilesFactory;
        private GunsFactory _gunsFactory;

        private readonly List<GunView> _gunViews = new List<GunView>();

        public void HandleCreateGun(InputAction.CallbackContext callbackContext)
        {
            if(!callbackContext.performed) return;
            
            CreateGunInRandomPosition();
        }
        
        private void CreateGunInRandomPosition()
        {
            Vector3 gunPosition = new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-10f, 10f));
            Gun model = _gunsFactory.CreateMachineGun(gunPosition, _projectilesFactory.CreateBullet);
            _gunViews.Add(_composeFactory.CreateMachineGunCompose(model, _composeFactory.CreateBulletCompose));
        }

        private void Awake()
        {
            _composeFactory = GetComponent<ComposeFactory>();
            
            _targetPointer = GetComponent<SimpleTargetPointer>();
            _targetPointer.TargetPointed += OnTargetPointed;

            _projectilesFactory = new ProjectilesFactory();
            _projectilesFactory.ApplyConfig(projectilesConfig);

            _gunsFactory = new GunsFactory();
            _gunsFactory.ApplyConfig(gunsConfig);
        }

        private void OnTargetPointed(IProjectileTarget target)
        {
            foreach (GunView gunView in _gunViews) gunView.Target = target;
        }
    }
}