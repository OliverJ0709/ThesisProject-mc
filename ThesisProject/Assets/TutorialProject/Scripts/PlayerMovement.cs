using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody characterRB;
    [SerializeField] Vector3 movementInput;
    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementSpeed;
   
    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    
    // Update is called once per frame
    void Update()
    {
        movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
        movementVector.y = 0;

        characterRB.velocity = (movementVector * movementSpeed * Time.fixedDeltaTime);
    }

    void OnMovement(InputValue input)
    {
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }

    void StopMovement(InputValue input) 
    {
        movementVector = Vector3.zero;
    }
}
