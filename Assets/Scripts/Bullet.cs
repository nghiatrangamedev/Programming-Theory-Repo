using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _bulletSpeed = 30.0f;
    float _destroyPosForEnemy = 250.0f;
    float _destroyPosForPlayer = 100.0f;

    PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement();

        if (transform.position.x >= _destroyPosForEnemy || transform.position.x <= _destroyPosForPlayer)
        {
            DestroyOutBound();
        }
    }

    // ABSTRACTION
    void BulletMovement()
    {
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);
    }

    void DestroyOutBound()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            playerController.PlayerHeal -= 5;
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
