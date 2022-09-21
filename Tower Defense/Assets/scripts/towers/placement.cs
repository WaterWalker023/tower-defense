using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placement : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask layermask;
    [SerializeField] List<GameObject> tower;
    int selectedtower = 0;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("click");
            Instantiate(tower[selectedtower], new Vector3(transform.position.x, 0.257f, transform.position.z), Quaternion.identity);
        }
    }
}
