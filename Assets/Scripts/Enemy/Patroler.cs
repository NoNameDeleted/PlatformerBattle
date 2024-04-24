using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 1f;

    [SerializeField]  private FieldOfView _fieldOfView;

    public event Action<float> DirectionChange;

    private int _currentWaypoint;
    private Vector2 _currentTarget;

    private void OnEnable()
    {
        _fieldOfView.PlayerSeen += OnPlayerSeen;
        _fieldOfView.PlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        _fieldOfView.PlayerSeen -= OnPlayerSeen;
        _fieldOfView.PlayerLeft -= OnPlayerLeft;
    }

    private void Start()
    {
        _currentTarget = _waypoints[_currentWaypoint].position;
    }

    private void Update()
    {
        if (transform.position.x == _waypoints[_currentWaypoint].position.x)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;

            _currentTarget = _waypoints[_currentWaypoint].position;
            DirectionChange?.Invoke(_currentTarget.x - transform.position.x);
        }

        transform.position = Vector2.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
    }

    private void OnPlayerSeen(Vector2 playerPosition)
    {
        _currentTarget = playerPosition;
        DirectionChange?.Invoke(_currentTarget.x - transform.position.x);
    }

    private void OnPlayerLeft()
    {
        _currentTarget = _waypoints[_currentWaypoint].position;
        DirectionChange?.Invoke(_currentTarget.x - transform.position.x);
    }
}
