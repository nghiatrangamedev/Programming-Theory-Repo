using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            PlayerMovement();
        }
    }

    // ABSTRACTION

    void PlayerMovement()
    {
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }
}
