using UnityEngine;

namespace Models.MoveStrategy
{
    public class CircularMovement : IMoveStrategy
    {
        public Vector3 Normal { get; set; } = Vector3.up;
        public float Radius { get; set; } = 1f;
        
        public (Vector3 movement, Vector3 direction) Move(float speed, Vector3 direction, float deltaTime)
        {
            float angularSpeed = speed / Radius;
            Vector3 newDirection = (Quaternion.AngleAxis(angularSpeed * deltaTime * 180 / Mathf.PI, Normal) * direction).normalized;
            return (speed * deltaTime * newDirection, newDirection);
        }
    }
}