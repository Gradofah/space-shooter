using UnityEngine;

namespace Core.Game.EnemyEntity.EnemyBehaviour.DirectionBehaviour
{
    public class OffsetReflectDirectionBehaviour : IDirectionBehaviour
    {
        public void ChangeDirection(ref Vector3 currentDirection, ref Rigidbody2D rigidbody, ref Collision2D collision, 
            ref float speed)
        {
            Vector3 randomOffset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized;
            currentDirection = Vector3.Reflect(currentDirection, collision.GetContact(0).normal);
            rigidbody.velocity = (currentDirection.normalized + randomOffset) * speed;
        }
    }
}