using UnityEngine;

namespace MVPPassiveView.Views
{
    [DisallowMultipleComponent]
    public abstract class MonoBehaviourView : MonoBehaviour, IView
    {
        public bool IsDestroyed { get; private set; }

        public void HandleDestroyed()
        {
            if (IsDestroyed) return;

            IsDestroyed = true;
            HandleDestroyedInternal();
            Destroy(gameObject);
        }

        protected virtual void HandleDestroyedInternal()
        {
        }
    }
}