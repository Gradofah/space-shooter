using UnityEngine;

namespace Core.Game.EnemyEntity.EnemyBehaviour.DirectionBehaviour
{
    public class ReflectDirectionBehaviour : IDirectionBehaviour
    {
        public void ChangeDirection(ref Vector3 currentDirection, ref Rigidbody2D rigidbody, ref Collision2D collision, 
            ref float speed)
        {
            currentDirection = Vector3.Reflect(currentDirection, collision.GetContact(0).normal);
            rigidbody.velocity = currentDirection.normalized * speed;
        }
    }
}