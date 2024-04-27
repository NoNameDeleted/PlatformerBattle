using UnityEngine;

public class EnemyViewer : MonoBehaviour
{
    [SerializeField] private Patroler _patrol;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;

    private readonly int _getHit = Animator.StringToHash("GetHit");

    private void OnEnable()
    {
        _patrol.DirectionChange += Flip;
        _enemy.GetDamage += GetHit;
    }

    private void OnDisable()
    {
        _patrol.DirectionChange -= Flip;
        _enemy.GetDamage -= GetHit;
    }

    private void Flip(float direction)
    {
        _sprite.flipX = direction < 0f;
    }

    private void GetHit()
    {
        _animator.SetTrigger(_getHit);
    }
}
