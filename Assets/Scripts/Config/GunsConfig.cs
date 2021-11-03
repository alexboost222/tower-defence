using Models.Guns;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "GunsConfig", menuName = "ScriptableObjects/GameConfig/GunsConfig", order = 1)]
    public class GunsConfig : ScriptableObject, IGunsFactoryConfig
    {
        [SerializeField] private float machineGunFireDelay;

        [SerializeField] private float machineGunFireRange;

        public float MachineGunFireDelay => machineGunFireDelay;
        
        public float MachineGunFireRange => machineGunFireRange;
    }
}