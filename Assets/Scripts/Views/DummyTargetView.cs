using UnityEngine;

namespace Views
{
    public class DummyTargetView : MonoBehaviour
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}