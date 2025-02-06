using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] int jumpForce;
    [SerializeField] int jumpDistance;
    bool jumpPressed;
    [SerializeField] Rigidbody characterRB;
    


    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Jump();
        
    }

    void Jump()
    {
        if (jumpPressed)
        {
            characterRB.AddForce(Vector3.up * jumpForce);
            if (characterRB.position.y > jumpDistance)
            {
                jumpPressed = false;
            }
        }
    }
    void OnJump()
    {
        if (characterRB.velocity.y <= 0)
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }

    }
}
