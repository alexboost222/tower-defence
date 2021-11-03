using UnityEngine;

namespace MVPPassiveView.Views
{
    public class DummyTargetView : MonoBehaviourView
    {
        public Vector3 Position
        {
            get => transform.position;
            set
            {
                if (!IsDestroyed) transform.position = value;
            }
        }
    }
}