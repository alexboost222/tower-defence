using UnityEngine;

namespace Models.MoveStrategy
{
    public interface IMoveStrategy
    {
        (Vector3 movement, Vector3 direction) Move(float speed, Vector3 direction, float deltaTime);
    }
}