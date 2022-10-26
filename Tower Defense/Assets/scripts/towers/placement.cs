using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class placement : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask layermask;
    public float money;
    public GameObject selectedtowerupgrade;
    [SerializeField] GameObject upgrade;
    public List<GameObject> tower;
    [SerializeField] List<GameObject> obstacles;
    [SerializeField] Slider enemieslider;
    [SerializeField] GameObject enemiesbar;
    [SerializeField] GameObject upgrademenu;
    public bool upgradebutton;

    public int selectedtower = 0;
    public bool selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray place = _camera.ScreenPointToRay(Input.mousePosition);
        /*if (GraphicRaycaster(place, out RaycastHit test, float.MaxValue, layermask))
        {
            Debug.Log("tst");
        }*/
        if (Physics.Raycast(place, out RaycastHit raycasthit, float.MaxValue, layermask))  
        {
            transform.position = raycasthit.point;

            enemiesbar.SetActive(false);
            if (raycasthit.collider.tag == "enemie")
            {
                enemiesbar.SetActive(true);
                enemiesbar.transform.position = _camera.WorldToScreenPoint(raycasthit.point);
                enemieslider.maxValue = raycasthit.transform.gameObject.GetComponent<movement>().maxhp;
                enemieslider.value = raycasthit.transform.gameObject.GetComponent<movement>().hp;
                
            }
        
            if (Input.GetKeyDown(KeyCode.Mouse0) && !selected && raycasthit.collider.tag == "tower" && !EventSystem.current.IsPointerOverGameObject())
            {
                if (selectedtowerupgrade) {selectedtowerupgrade.GetComponent<MeshRenderer>().forceRenderingOff = true;}
                selectedtowerupgrade = raycasthit.transform.parent.gameObject;
                selectedtowerupgrade.GetComponent<MeshRenderer>().forceRenderingOff = false;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && obstacles.Count == 0 && selected && raycasthit.collider.tag == "greengrass" && !EventSystem.current.IsPointerOverGameObject())
            { 
                if (tower[selectedtower].transform.GetChild(0).GetComponent<towers>().cost <= money)
                {

                    money -= tower[selectedtower].transform.GetChild(0).GetComponent<towers>().cost;
                    
                    selectedtowerupgrade = Instantiate(tower[selectedtower], new Vector3(transform.position.x, 0.257f, transform.position.z), Quaternion.identity);
                    selectedtowerupgrade = selectedtowerupgrade.transform.GetChild(0).gameObject;
                    selected = false;
                }
            
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && obstacles.Count != 0 && !EventSystem.current.IsPointerOverGameObject() && !(raycasthit.collider.tag == "tower"))
            {
                GameObject.Find("cantplacehere").GetComponent<cantplace>().error = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.U) || upgradebutton)
        {
            upgradebutton = false;
            Debug.Log("1");
            if (selectedtowerupgrade.GetComponent<towers>().upgradeto.transform.GetChild(0).GetComponent<towers>().cost <= money)
            {
                upgrade = Instantiate(selectedtowerupgrade.GetComponent<towers>().upgradeto, new Vector3(selectedtowerupgrade.transform.position.x, selectedtowerupgrade.transform.position.y, selectedtowerupgrade.transform.position.z), Quaternion.identity);
                upgrade.transform.GetChild(0).GetComponent<towers>().strongest = selectedtowerupgrade.GetComponent<towers>().strongest;
                money -= selectedtowerupgrade.GetComponent<towers>().upgradeto.transform.GetChild(0).GetComponent<towers>().cost;
                Destroy(selectedtowerupgrade.transform.parent.gameObject);
                upgrade.transform.GetChild(0).GetComponent<MeshRenderer>().forceRenderingOff = false;
                selectedtowerupgrade = upgrade.transform.GetChild(0).gameObject;
                upgrade = null;
                Debug.Log("2");
            }
            
        }
        upgrademenu.SetActive(false);
        if (selectedtowerupgrade)
        {

            upgrademenu.SetActive(true);
            upgrademenu.gameObject.transform.Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = selectedtowerupgrade.gameObject.name.Replace("(Clone)", "");
            if (selectedtowerupgrade != null)
                upgrademenu.gameObject.transform.Find("furthest").gameObject.transform.Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = selectedtowerupgrade.GetComponent<towers>().strongest;
            upgrademenu.gameObject.transform.Find("upgrade").gameObject.transform.Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = selectedtowerupgrade.GetComponent<towers>().upgradeto.transform.GetChild(0).GetComponent<towers>().cost + "";
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedtower = 0;
            selected = true;
            if (selectedtowerupgrade != null)
            { 
                selectedtowerupgrade.GetComponent<MeshRenderer>().forceRenderingOff = true;
                selectedtowerupgrade = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedtower = 1;
            selected = true;
            if (selectedtowerupgrade != null)
            {
                selectedtowerupgrade.GetComponent<MeshRenderer>().forceRenderingOff = true;
                selectedtowerupgrade = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedtower = 2;
            selected = true;
            if (selectedtowerupgrade != null)
            {
                selectedtowerupgrade.GetComponent<MeshRenderer>().forceRenderingOff = true;
                selectedtowerupgrade = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedtower = 3;
            selected = true;
            if (selectedtowerupgrade != null)
            {
                selectedtowerupgrade.GetComponent<MeshRenderer>().forceRenderingOff = true;
                selectedtowerupgrade = null;
            }
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
