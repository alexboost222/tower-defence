using Config;
using Models.Guns;
using Models.Projectiles;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TMPTesting
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ComposeFactory))]
    public class GrayboxLevel : MonoBehaviour
    {
        [SerializeField] private ProjectilesConfig projectilesConfig;
        [SerializeField] private GunsConfig gunsConfig;

        private ComposeFactory _composeFactory;

        private ProjectilesFactory _projectilesFactory;
        private GunsFactory _gunsFactory;

        public void HandleCreateGun(InputAction.CallbackContext callbackContext)
        {
            if(!callbackContext.performed) return;
            
            CreateGunInRandomPosition();
        }
        
        private void CreateGunInRandomPosition()
        {
            Vector3 gunPosition = new Vector3(Random.Range(-10f, 10f), 1, Random.Range(-10f, 10f));
            Gun model = new Gun(gunPosition, _projectilesFactory.CreateBullet);
            _composeFactory.CreateMachineGunCompose(model, _composeFactory.CreateBulletCompose);
        }

        private void Awake()
        {
            _composeFactory = GetComponent<ComposeFactory>();

            _projectilesFactory = new ProjectilesFactory();
            _projectilesFactory.ApplyConfig(projectilesConfig);

            _gunsFactory = new GunsFactory();
            _gunsFactory.ApplyConfig(gunsConfig);
        }
    }
}