using System;
using MVPPassiveView.Models;
using MVPPassiveView.Views;

namespace MVPPassiveView.Presenters
{
    public abstract class PresenterBase
    {
        public event Action Destroyed;

        protected readonly ModelBase Model;
        protected readonly IView View;

        protected PresenterBase(ModelBase model, IView view)
        {
            Model = model;
            View = view;

            Model.Destroyed += OnModelDestroyed;
        }

        protected virtual void OnModelDestroyedInternal()
        {
        }

        private void OnModelDestroyed()
        {
            Model.Destroyed -= OnModelDestroyed;
            
            OnModelDestroyedInternal();
            View.HandleDestroyed();

            Destroyed?.Invoke();
        }
    }
}