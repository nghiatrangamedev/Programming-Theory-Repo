using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform _playerPos;
    float _enemySpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        _playerPos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer(_playerPos);
        EnemyMovement(_enemySpeed);
    }

    // ABSTRACTION
    protected virtual void  EnemyMovement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    protected void LookAtPlayer(Transform playerPos)
    {
        transform.LookAt(playerPos);
    }
}
