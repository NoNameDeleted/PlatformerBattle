using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class Vampirizm : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private float _durationTime = 6f;
    [SerializeField] private ContactFilter2D _enemyFilter;

    private readonly string Fire2 = nameof(Fire2);

    private Collider2D _collider;
    private SpriteRenderer _redArea;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _redArea = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(Fire2) & _redArea.enabled == false)
        {
            StartCoroutine(VampireHealth());
        }
    }

    private IEnumerator VampireHealth()
    {
        float timeLeft = _durationTime;
        float latency = 0.1f;
        WaitForSeconds wait = new WaitForSeconds(latency);
        Collider2D[] colliders = new Collider2D[10];
        Health closestHealth = null;

        _redArea.enabled = true;

        while (timeLeft > latency)
        {
            int collidersAmount = _collider.OverlapCollider(_enemyFilter, colliders);

            if (collidersAmount > 0) 
            {
                float closestDistace = float.PositiveInfinity;

                for (int i = 0; i < collidersAmount; i++)
                {
                    float distanse = Vector2.Distance(colliders[i].transform.position, transform.position);

                    if (distanse < closestDistace)
                    {
                        closestDistace = distanse;
                        closestHealth = colliders[i].GetComponent<Health>();
                    }
                }

                if (closestHealth != null)
                {
                    if (closestHealth.LoseHealth())
                        _playerHealth.RestoreHealth();
                }
            }

            timeLeft -= latency;
            yield return wait;
        }

        _redArea.enabled = false;
    }
}
