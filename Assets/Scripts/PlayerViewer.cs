using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewer : MonoBehaviour
{
    [SerializeField] private Mover _movement;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;

    private readonly int _move = Animator.StringToHash("Move");
    private readonly int _stand = Animator.StringToHash("Stand");

    private void OnEnable()
    {
        _movement.DirectionChange += Flip;
        _movement.StopMoving += Stand;
    }

    private void OnDisable()
    {
        _movement.DirectionChange -= Flip;
        _movement.StopMoving -= Stand;
    }

    private void Flip(float direction)
    {
        _sprite.flipX = direction < 0f;
        _animator.SetTrigger(_move);
    }

    private void Stand()
    {
        _animator.SetTrigger(_stand);
    }
}

