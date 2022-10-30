using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttons : MonoBehaviour
{
    [SerializeField] int buttonFunction;
    [SerializeField] int buttontype;
    GameObject _placement;
    [SerializeField] Image image;
    [SerializeField] Material materials;
    // Start is called before the first frame update
    void Start()
    {
        _placement = GameObject.Find("placement");
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonFunction == 1)
        {
            if (_placement.GetComponent<placement>().tower[buttontype].transform.GetChild(0).GetComponent<towers>().cost > _placement.GetComponent<placement>().money)
            {
                image.color = new Color(0.7f,0.7f,0.7f,0.7f);
            }
            else
            {
                image.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
    public void place()
    {
        _placement.GetComponent<placement>().selectedtower = buttontype;
        _placement.GetComponent<placement>().selected = true;
        _placement.GetComponent<placement>().selectedtowerupgrade = null;
    }
    public void towerupgrades()
    {
        if (buttontype == 0)
        {
            _placement.GetComponent<placement>().upgradebutton = true;
        }
        if(buttontype == 1)
        {
            if(_placement.GetComponent<placement>().selectedtowerupgrade.GetComponent<towers>().strongest == "strongest")
            {
                _placement.GetComponent<placement>().selectedtowerupgrade.GetComponent<towers>().strongest = "weakest";
            }
            else if (_placement.GetComponent<placement>().selectedtowerupgrade.GetComponent<towers>().strongest == "weakest")
            {
                _placement.GetComponent<placement>().selectedtowerupgrade.GetComponent<towers>().strongest = "first";
            }
            else if (_placement.GetComponent<placement>().selectedtowerupgrade.GetComponent<towers>().strongest == "first")
            {
                _placement.GetComponent<placement>().selectedtowerupgrade.GetComponent<towers>().strongest = "strongest";
            }
        }
    }
}
