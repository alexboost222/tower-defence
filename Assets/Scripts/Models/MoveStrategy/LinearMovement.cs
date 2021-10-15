using UnityEngine;

namespace Models.MoveStrategy
{
    public class LinearMovement : IMoveStrategy
    {
        public (Vector3 movement, Vector3 direction) Move(float speed, Vector3 direction, float deltaTime) =>
            (speed * deltaTime * direction, direction);
    }
}