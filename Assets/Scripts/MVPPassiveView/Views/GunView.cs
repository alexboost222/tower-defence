using System;
using MVPPassiveView.Models.ProjectileTargets;
using UnityEngine;

namespace MVPPassiveView.Views
{
    public class GunView : MonoBehaviourView
    {
        public event Action<float> UpdateHappened;
        public event Action<IProjectileTarget> TargetSet; 
        
        public Vector3 Position
        {
            get => transform.position;
            set
            {
                if (!IsDestroyed) transform.position = value;
            }
        }

        public IProjectileTarget Target
        {
            set
            {
                if (!IsDestroyed) TargetSet?.Invoke(value);
            }
        }

        private void Update()
        {
            if (!IsDestroyed) UpdateHappened?.Invoke(Time.deltaTime);
        }
    }
}