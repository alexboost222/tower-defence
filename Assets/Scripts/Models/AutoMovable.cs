using Models.MoveStrategy;
using UnityEngine;

namespace Models
{
    public class AutoMovable : Transformable
    {
        public bool IsMoving { get; set; }
        public Vector3 Direction { get; set; } = Vector3.forward;
        public float Speed { get; set; } = 1f;

        public IMoveStrategy MoveStrategy { get; set; } = new CircularMovement();

        public void Tick(float deltaTime)
        {
            if (!IsMoving) return;

            (Vector3 movement, Vector3 direction) = MoveStrategy.Move(Speed, Direction, deltaTime);
            Position += movement;
            Direction = direction.normalized;
        }
    }
}