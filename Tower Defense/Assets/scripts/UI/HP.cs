using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float hp = 100;
    public Slider hpbar;
    private int maxHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        hpbar.maxValue = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = hp;
    }
}
