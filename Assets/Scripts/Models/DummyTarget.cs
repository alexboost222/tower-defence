using UnityEngine;

namespace Models
{
    public class DummyTarget : IProjectileTarget
    {
        public DummyTarget(Vector3 position) => Position = position;
        
        public Vector3 Position { get; }
    }
}