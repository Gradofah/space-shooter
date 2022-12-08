using UnityEngine;

namespace Core.Game.EnemyEntity.EnemyBehaviour.DirectionBehaviour
{
    public interface IDirectionBehaviour
    {
        void ChangeDirection(ref Vector3 currentDirection, ref Rigidbody2D rigidbody, ref Collision2D collision,
            ref float speed);
    }
}