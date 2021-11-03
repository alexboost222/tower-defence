using System;
using Models.ProjectileTargets;
using UnityEngine;

namespace Views
{
    public class GunView : MonoBehaviour
    {
        public event Action<float> UpdateHappened;
        public event Action<IProjectileTarget> TargetSet; 
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public IProjectileTarget Target
        {
            set => TargetSet?.Invoke(value);
        }

        private void Update() => UpdateHappened?.Invoke(Time.deltaTime);
    }
}