using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody characterRB;
    [SerializeField] Vector3 movementInput;
    [SerializeField] Vector3 movementVector;
    [SerializeField] public float movementSpeed;
    bool sprinting;
    


    // Start is called before the first frame update
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
        sprinting = false;
        
    }

    
    // Update is called once per frame
    void Update()
    {
        movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
        movementVector.y = 0;

        //springer snabbare ifall sprinting är true
        if (sprinting) 
        {
            
            characterRB.velocity = (movementVector * movementSpeed * 2 * Time.fixedDeltaTime);
        }
        else
        {
            characterRB.velocity = (movementVector * movementSpeed * Time.fixedDeltaTime);
        }
        
        
    }

    void OnMovement(InputValue input)
    {
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }

    void StopMovement(InputValue input) 
    {
        movementVector = Vector3.zero;
    }

    //kollar ifall shiftknappen är nere då blir sprinting true
    void OnSprint() 
    {
        sprinting = true;
        Debug.Log("sprinting");
    }
    //ifall man släpper shiftknappen är sprinting false
    void OnSprintStop() 
    {
        sprinting = false;
        Debug.Log("not sprinting");
    }
   


    
}
