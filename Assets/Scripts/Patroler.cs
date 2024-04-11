using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 1f;

    public event Action<float> DirectionChange;

    private int _currentWaypoint;

    private void Update()
    {
        if (transform.position.x == _waypoints[_currentWaypoint].position.x)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

            float direction = _waypoints[_currentWaypoint].position.x - transform.position.x;
            DirectionChange?.Invoke(direction);
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
