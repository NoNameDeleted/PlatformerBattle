using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnersContainer;
    [SerializeField] private Coin _coin;

    private Transform[] _spawnpoints;

    private void Start()
    {
        _spawnpoints = new Transform[_spawnersContainer.childCount];

        for (int i = 0; i < _spawnersContainer.childCount; i++)
        {
            _spawnpoints[i] = _spawnersContainer.GetChild(i);
        }

        foreach (Transform coinLocation in _spawnpoints)
        {
            Coin coin = Instantiate(_coin, coinLocation.position, Quaternion.identity);
            coin.gameObject.SetActive(true);
        }
    }
}
