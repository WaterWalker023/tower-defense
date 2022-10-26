using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{
    public float hp = 10f;
    [SerializeField] float speed = 1f;
    [SerializeField] float timetonext;
    public float livetime;
    float starttime;
    [SerializeField] Rigidbody rb;
    [SerializeField] float lastframehp;
    bool dead;
    float widthground = 1;
    bool newground;
    float newgroundtimer;
    float newgroundtime;
    Quaternion newgroundrotation;
    private HP _HP;
    public placement money;
    [SerializeField] enemycounder _textenemycounter;
    public float maxhp;


    // Start is called before the first frame update
    void Start()
    {
        maxhp = hp;
        lastframehp = hp;
        starttime = Time.time;
        transform.position = GameObject.Find("spawn").transform.position;
        _HP = GameObject.Find("HP").GetComponent<HP>();
        money = GameObject.Find("placement").GetComponent<placement>();
        _textenemycounter = GameObject.Find("textenemycountercounder").GetComponent<enemycounder>();
        _textenemycounter.textenemycounter++;
        rb = GetComponent<Rigidbody>();
        newgroundtime = (widthground / 2) / speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        livetime = (Time.time - starttime) * speed;
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
    private void Update()
    {
        if (hp <= 0 && !dead)
        {
            hp = 0;
            transform.position = new Vector3(500, 0, 0);
            Destroy(gameObject, 0.5f);
            dead = true;
            _textenemycounter.textenemycounter--;
        }
        if (lastframehp > hp)
        {
            money.GetComponent<placement>().money += (lastframehp - hp);
            lastframehp = hp;
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
            transform.position = new Vector3(500, 0, 0);
            Destroy(gameObject, 0.5f);
            dead = true;
            _textenemycounter.textenemycounter--;
        }
    }

}