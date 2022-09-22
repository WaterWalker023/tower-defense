using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public float textMoney;
    public placement money;
    [SerializeField] TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        money = GameObject.Find("placement").GetComponent<placement>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "$ " + money.money;
    }
}
