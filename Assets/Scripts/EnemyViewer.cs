using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewer : MonoBehaviour
{
    [SerializeField] private Patroler _patrol;
    [SerializeField] private SpriteRenderer _sprite;

    private void OnEnable()
    {
        _patrol.DirectionChange += Flip;
    }

    private void OnDisable()
    {
        _patrol.DirectionChange -= Flip;
    }

    private void Flip(float direction)
    {
        _sprite.flipX = direction < 0f;
    }
}
