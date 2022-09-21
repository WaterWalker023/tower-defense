using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Magifence/Wave")]
public class Waves : ScriptableObject
{
    public GameObject[] waveEnemies;
    public int[] waveAmounts;
}