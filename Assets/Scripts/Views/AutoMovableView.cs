using Models;
using UnityEngine;

namespace Views
{
    public class AutoMovableView : TransformableView
    {
        internal virtual void Init(AutoMovable autoMovable) => Transformable = autoMovable;

        private AutoMovable AutoMovable => (AutoMovable) Transformable;

        private void StartMoving() => AutoMovable.IsMoving = true;

        private void StopMoving() => AutoMovable.IsMoving = false;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space)) StartMoving();
            else StopMoving();

            AutoMovable?.Tick(Time.deltaTime);
        }
    }
}