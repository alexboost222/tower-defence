using Models;
using UnityEngine;

namespace Views
{
    [DisallowMultipleComponent]
    public class TransformableView : MonoBehaviour
    {
        protected Transformable Transformable;

        internal virtual void Init(Transformable transformable) => Transformable = transformable;

        private void LateUpdate()
        {
            Transform myTransform = transform;
            myTransform.position = Transformable.Position;
            myTransform.rotation = Transformable.Rotation;
        }
    }
}