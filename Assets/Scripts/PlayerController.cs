using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject _bullet;


    float horizontalInput;
    float speed = 20.0f;
    float playerHeal = 100.0f;

    bool _isShooting = false;

    Vector3 _bulletPosition;

    // / ENCAPSULATION

    public float PlayerHeal
    {
        get
        {
            if (playerHeal > 100.0f)
            {
                playerHeal = 100.0f;
            }

            else if (playerHeal < 0)
            {
                playerHeal = 0;
            }
            return playerHeal;
        }

        set
        {
            playerHeal = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            PlayerMovement();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        Debug.Log(PlayerHeal);
    }

    // ABSTRACTION

    void PlayerMovement()
    {
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }

    void Shoot()
    {
        if (!_isShooting)
        {
            _isShooting = true;
            _bulletPosition = transform.position - new Vector3 (5, 0, 0);
            Instantiate(_bullet, _bulletPosition, transform.rotation);
            StartCoroutine(ShootingRate());
        }
    }

    IEnumerator ShootingRate()
    {
        yield return new WaitForSeconds(1);
        _isShooting = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealItem"))
        {
            Destroy(other.gameObject);
            PlayerHeal += 50;
            Debug.Log(PlayerHeal);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("You are on ground");
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            PlayerHeal -= 10;
        }
    }

}
