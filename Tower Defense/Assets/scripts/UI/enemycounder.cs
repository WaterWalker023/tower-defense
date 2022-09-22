using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemycounder : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public int textenemycounter;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = "" +  textenemycounter;
        //if (textenemycounter == 0)
        //{
        //    text.text = "N";
        //}
    }
}
