using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class koopbuttons : MonoBehaviour
{
    [SerializeField] GameObject _placement;
    [SerializeField] int buttonnumber;
    [SerializeField] TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        _placement = GameObject.Find("placement");
        text.text = _placement.GetComponent<placement>().tower[buttonnumber].transform.GetChild(0).GetComponent<towers>().cost + "\n" + _placement.GetComponent<placement>().tower[buttonnumber].name;
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
