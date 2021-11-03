using UnityEngine;

namespace MVPPassiveView.Models.ProjectileTargets
{
    public class DummyTarget : ModelBase, IProjectileTarget
    {
        public DummyTarget(Vector3 position) => Position = position;
        
        public Vector3 Position { get; }
    }
}