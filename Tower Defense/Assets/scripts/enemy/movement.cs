using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float hp = 10f;
    public float speed = 1f;
    public float livetime;
    public Rigidbody rb;
    
    float widthground = 1;
    bool newground;
    float newgroundtimer;
    float newgroundtime;
    Quaternion newgroundrotation;
    private HP _HP;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.Find("spawn").transform.position;
        _HP = GameObject.Find("HPbalk").GetComponent<HP>();
        
        rb = GetComponent<Rigidbody>();
        newgroundtime = (widthground / 2) / speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        livetime = Time.time * speed;
        transform.position += transform.forward * speed * Time.deltaTime;
        if (newground)
        {
            newgroundtimer += Time.deltaTime;
            if (newgroundtimer > newgroundtime)
            {
                transform.rotation = new Quaternion(rb.rotation.x,newgroundrotation.y,rb.rotation.z, newgroundrotation.w);
                newground = false;
                newgroundtimer = 0;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            newground = true;
            newgroundrotation = collision.transform.rotation;
            
            //transform.rotation = new Quaternion(collision.transform.rotation.x, collision.transform.rotation.y, collision.transform.rotation.z, collision.transform.rotation.w);
        }
        if (collision.collider.tag == "end")
        {
            _HP.hp -= hp;
            hp = 0;
            Destroy(gameObject);
        }
    }
}
