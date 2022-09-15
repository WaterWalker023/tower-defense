using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Waves waves;
    [SerializeField] int wave = 0;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            wave++;
            if (wave == 1)
            {
                StartCoroutine(wave1());
            }
            else if (wave == 2)
            {
                StartCoroutine(wave2());
            }
        }
    }
    IEnumerator wave1()
    {
        for (int i = 0; i < waves.wave1Enemies.Length; i++)
        {
            for (int j = 0; j < waves.wave1Amounts[i]; j++)
            {
                Instantiate(waves.wave1Enemies[i], this.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            Debug.Log("part done");
        }
        
        Debug.Log("wave done");  
    }
    IEnumerator wave2()
    {
        for (int i = 0; i < waves.wave2Enemies.Length; i++)
        {
            for (int j = 0; j < waves.wave2Amounts[i]; j++)
            {
                Instantiate(waves.wave1Enemies[i], this.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            Debug.Log("part done");
        }

        Debug.Log("wave done");
    }
}