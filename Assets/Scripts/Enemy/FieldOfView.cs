using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public event Action<Vector2> PlayerSeen;
    public event Action PlayerLeft;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerSeen?.Invoke(player.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayerLeft?.Invoke();  
        }
    }
}
