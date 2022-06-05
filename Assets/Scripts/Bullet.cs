using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _bulletSpeed = 20.0f;
    // Update is called once per frame
    void Update()
    {
        BulletMovement();
    }

    // ABSTRACTION
    void BulletMovement()
    {
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);
    }
}
