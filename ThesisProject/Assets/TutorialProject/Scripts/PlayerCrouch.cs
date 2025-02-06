using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] CapsuleCollider playerCollider;
    
    bool crouching;
    // Start is called before the first frame update
    void Start()
    {
        crouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (crouching)
        {
            playerCollider.height = playerCollider.height / 2;
            playerMovement.movementSpeed = playerMovement.movementSpeed / 2;

        }
        else 
        {
            playerCollider.height = 2;
        }
    }

    void OnCrouch() 
    {
        crouching = true;
    }
    void OnCrouchStop()
    {
        crouching = false;
    }
}
