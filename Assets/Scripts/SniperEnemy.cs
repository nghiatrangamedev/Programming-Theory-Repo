using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class SniperEnemy : Enemy
{
    [SerializeField] GameObject _bullet;

    Vector3 _bulletPosition;
    float _sniperEnemySpeed = 15.0f;
    bool _isShooting = false;

    // Update is called once per frame
    void Update()
    {
        // INHERITANCE
        LookAtPlayer(_playerPos);
        EnemyMovement(_sniperEnemySpeed);
        Shoot();
    }

    // POLYMORPHISM
    protected override void EnemyMovement(float speed)
    {
        if (transform.position.x < 140)
        {
            base.EnemyMovement(speed);
        }
    }

    // ABSTRACTION
    void Shoot()
    {
        if (!_isShooting && transform.position.x >= 140)
        {
            _isShooting = true;
            _bulletPosition = transform.position + Vector3.forward;
            Instantiate(_bullet, _bulletPosition, transform.rotation);
            StartCoroutine(ShootingRate());
        }
            
    }

    IEnumerator ShootingRate()
    {
        yield return new WaitForSeconds(1);
        _isShooting = false;
    }

}
