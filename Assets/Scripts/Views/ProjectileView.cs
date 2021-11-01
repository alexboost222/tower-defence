using System;
using UnityEngine;

namespace Views
{
    public class ProjectileView : MonoBehaviour
    {
        public event Action<float> UpdateHappened;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void HandleReachedTarget() => Debug.Log("Reached target", this);

        private void Update() => UpdateHappened?.Invoke(Time.deltaTime);
    }
}