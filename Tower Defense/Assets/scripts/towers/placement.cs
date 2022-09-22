using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask layermask;
    public float money;
    [SerializeField] List<GameObject> tower;
    [SerializeField] List<GameObject> obstacles;
    int selectedtower = 0;
    bool selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray place = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(place, out RaycastHit raycasthit, float.MaxValue, layermask))
        {
            transform.position = raycasthit.point;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && obstacles.Count == 0 && selected)
        { 
            if (tower[selectedtower].GetComponent<towers>().cost <= money)
            {
                money -= tower[selectedtower].GetComponent<towers>().cost;
                Debug.Log("click");
                Instantiate(tower[selectedtower], new Vector3(transform.position.x, 0.257f, transform.position.z), Quaternion.identity);
                selected = false;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && obstacles.Count != 0)
        {
            Debug.Log("NOPE");
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedtower = 0;
            selected = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedtower = 1;
            selected = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedtower = 2;
            selected = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedtower = 3;
            selected = true;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "tower")
        {
            obstacles.Add(collision.gameObject);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "tower")
        {
            obstacles.Remove(collision.gameObject);
        }
    }
}
