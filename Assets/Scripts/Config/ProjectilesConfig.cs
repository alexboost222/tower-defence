using Models.Projectiles;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "ProjectilesConfig", menuName = "ScriptableObjects/GameConfig/ProjectilesConfig", order = 2)]
    public class ProjectilesConfig : ScriptableObject, IProjectilesFactoryConfig
    {
        [SerializeField] private float bulletVelocity;

        public float BulletVelocity => bulletVelocity;
    }
}