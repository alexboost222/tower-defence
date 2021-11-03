using System;
using UnityEngine;

namespace MVPPassiveView.Views
{
    public class ProjectileView : MonoBehaviourView
    {
        public event Action<float> UpdateHappened;

        public Vector3 Position
        {
            get => transform.position;
            set
            {
                if (!IsDestroyed) transform.position = value;
            }
        }

        public void HandleReachedTarget() => Debug.Log("Reached target", this);

        private void Update()
        {
            if (!IsDestroyed) UpdateHappened?.Invoke(Time.deltaTime);
        }
    }
}