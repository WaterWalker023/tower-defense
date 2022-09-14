using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");
        Vector3 move = transform.right * movex + transform.forward * movez;
        characterController.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        else
            speed = 6f;


    }
}
