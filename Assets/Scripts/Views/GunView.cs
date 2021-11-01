using System;
using UnityEngine;

namespace Views
{
    public class GunView : MonoBehaviour
    {
        public event Action<float> UpdateHappened;
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}