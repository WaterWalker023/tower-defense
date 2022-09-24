using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towers : MonoBehaviour
{
    public bool strongest;
    [SerializeField] float damage;
    public float cost;
    [SerializeField] float shootdelay;
    public GameObject upgradeto;
    float reloaddelay;
    string type;
    float livetime;
    float hp;
    GameObject targetenemy;
    [SerializeField] List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        type = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count != 0)
        {
            if (shootdelay < reloaddelay)
            {
                livetime = 0;
                hp = 0;
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (!strongest)
                    {
                        if (enemies[i].GetComponent<movement>().livetime > livetime)
                        {
                            livetime = enemies[i].GetComponent<movement>().livetime;
                            targetenemy = enemies[i];
                        }
                    }
                
                    if (strongest)
                    {
                        if(enemies[i].GetComponent<movement>().hp == hp && enemies[i].GetComponent<movement>().livetime > livetime)
                            {
                                targetenemy = enemies[i];  
                                hp = enemies[i].GetComponent<movement>().hp;
                                livetime = enemies[i].GetComponent<movement>().livetime;
                            }
                        if(enemies[i].GetComponent<movement>().hp > hp)
                            {
                                targetenemy = enemies[i];
                                hp = enemies[i].GetComponent<movement>().hp;
                                livetime = enemies[i].GetComponent<movement>().livetime;
                            }
                    }

            }

            targetenemy.GetComponent<movement>().hp += -damage;
            targetenemy = null;
            reloaddelay = 0;
           

            }
        }
        reloaddelay += Time.deltaTime;
         
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "enemie")
        {
            enemies.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "enemie")
        {
            enemies.Remove(collision.gameObject);
        }
    }
}
