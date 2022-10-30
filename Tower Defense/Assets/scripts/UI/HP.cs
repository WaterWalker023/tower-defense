using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public float hp = 100;
    [SerializeField] TMP_Text text; 
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + hp;
        if (hp <= 0)
        {
            SceneManager.LoadScene("death");
        }
    }
}
