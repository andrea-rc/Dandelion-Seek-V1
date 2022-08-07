using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    CharacterController characterController;

    public float walk ;
    public float run ;
    public float jump ;
    public float gravity ;

    private Vector3 move = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            
                move = transform.TransformDirection(move) * run;
                else
                    move = transform.TransformDirection(move) * walk;
            if (Input.GetKey(KeyCode.Space))
                move.y = jump;
            
            
        }

        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
        
    }
}
