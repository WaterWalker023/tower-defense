using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    public Waves waves;
    [SerializeField] int wave = 0;
    public List<Waves> wavesList;
    float waveDuration;
    void Start()
    {
        waveDuration = waves.waveDuration;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) || waveDuration < 0)
        {
            waves = wavesList[wave];
            StartCoroutine(wavestart());
            wave++;
            waveDuration = waves.waveDuration;
        }
        waveDuration -= Time.deltaTime;
        timer.text = ((int)waveDuration).ToString();


    }
    IEnumerator wavestart()
    {
        for (int i = 0; i < waves.waveEnemies.Length; i++)
        {
            for (int j = 0; j < waves.waveAmounts[i]; j++)
            {
                Instantiate(waves.waveEnemies[i], this.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(waves.waveRate);
            }
            Debug.Log("part done");

        }
        
        Debug.Log("wave done");
    }
}