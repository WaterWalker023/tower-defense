using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public CharacterController characterController;
    [SerializeField] float speed = 12f;
    [SerializeField] float runspeed = 12f;
    [SerializeField] float normalspeed = 6f;
    bool speedup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!speedup)
            {
                Time.timeScale = 3f;
                speedup = true;
            }
            else
            {
                Time.timeScale = 1f;
                speedup = false;
            }
        }
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");
        Vector3 move = transform.right * movex + transform.forward * movez;
        characterController.Move(move * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift)/* || Input.GetButton(buttonName: "8")*/)
            speed = runspeed / Time.timeScale;
        else
            speed = normalspeed / Time.timeScale;
        //Time.timeScale = 0;


 
        
            

    }
}
