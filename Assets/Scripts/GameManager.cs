using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] _enemies;
    [SerializeField] GameObject _player;
    PlayerController _playerController;

    float _posX = 80.0f;
    float _posY = 5.0f;
    float _rangeZ = 140.0f;

    int _randomIndex;
    Vector3 _enemyPos;

    float _startTime = 2.0f;
    float _repateTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = _player.GetComponent<PlayerController>();
        InvokeRepeating("SpawnEnemy", _startTime, _repateTime);
    }

    private void Update()
    {
        if (_playerController.PlayerHeal == 0)
        {
            GameOver();
        }
    }

    // ABSTRACTION
    void RandomPos()
    {
        _enemyPos = new Vector3 (_posX, _posY, Random.Range(-_rangeZ, _rangeZ));
    }

    void RandomIndex()
    {
        _randomIndex = Random.Range(0, _enemies.Length);
    }

    void SpawnEnemy()
    {
        RandomPos();
        RandomIndex();
        Instantiate(_enemies[_randomIndex], _enemyPos, _enemies[_randomIndex].transform.rotation);
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Destroy(_player);
    }
}
