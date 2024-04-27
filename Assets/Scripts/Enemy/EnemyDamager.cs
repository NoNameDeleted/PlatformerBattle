using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int _damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage, transform.position);
        }
    }
}
