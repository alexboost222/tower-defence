using UnityEngine;

namespace Models.Guns
{
    public class Gun
    {
        public Gun(Vector3 position) => Position = position;
        
        public float FireRate { get; set; }
        
        public float FireRange { get; set; }
        
        public IProjectileTarget Target { get; set; }
        
        public Vector3 Position { get; }
    }
}