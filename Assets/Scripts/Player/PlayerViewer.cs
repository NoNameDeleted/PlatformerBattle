using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerViewer : MonoBehaviour
{
    [SerializeField] private Mover _movement;
    [SerializeField] private CutAttacker _cutAttacker;
    [SerializeField] private Player _player;

    private SpriteRenderer _sprite;
    private Animator _animator;

    private readonly int _move = Animator.StringToHash("Move");
    private readonly int _stand = Animator.StringToHash("Stand");
    private readonly int _attack = Animator.StringToHash("Attack");
    private readonly int _getHit = Animator.StringToHash("GetHit");

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _movement.DirectionChange += Flip;
        _movement.StopMoving += Stand;
        _cutAttacker.StartAttack += Attack;
        _player.GetDamage += OnGetHit;
    }

    private void OnDisable()
    {
        _movement.DirectionChange -= Flip;
        _movement.StopMoving -= Stand;
        _cutAttacker.StartAttack -= Attack;
        _player.GetDamage -= OnGetHit;
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

    private void Attack()
    {
        _animator.SetTrigger(_attack);
    }

    private void OnGetHit(Vector3 hitPosition)
    {
        _animator.SetTrigger(_getHit);
    }
}

