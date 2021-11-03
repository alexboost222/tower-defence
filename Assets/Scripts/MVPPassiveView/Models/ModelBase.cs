using System;

namespace MVPPassiveView.Models
{
    public abstract class ModelBase
    {
        internal event Action Destroyed;

        public bool IsDestroyed { get; private set; }

        public void Destroy()
        {
            if (IsDestroyed) return;

            IsDestroyed = true;
            DestroyInternal();
            Destroyed?.Invoke();
        }

        protected virtual void DestroyInternal()
        {
        }
    }
}