using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spawnPosition = 10f;
    [SerializeField] private float _spawnInterval = 2f;

    private float _timer;
    private bool _gameStopped;

    private void Start()
    {
        Locator.Instance.Player.PlayerTouched += GameStopped;

        SpawnPipe();
    }

    private void GameStopped()
    {
        _gameStopped = true;
    }

    private void Update()
    {

        if (_gameStopped)
            return;

        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            SpawnPipe();
            _timer = 0f;
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = Instantiate(_pipePrefab);
        pipe.transform.position = new Vector3(_spawnPosition, 0f, 0f);
    }
}