using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cantplace : MonoBehaviour
{
    public bool error;
    float alphatime;
    float alpha;
    [SerializeField] TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (error)
        {
            alphatime = 5;
            error = false;
        }
        else
        {
            alphatime -= Time.deltaTime;
            alpha = alphatime / 5;
        }
        text.color = new Color(0.96f, 0.18f, 0.18f, alpha);
    }
}
