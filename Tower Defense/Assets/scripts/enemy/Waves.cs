using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Magifence/Wave")]
public class Waves : ScriptableObject
{
    public GameObject[] wave1Enemies;
    public int[] wave1Amounts;
    public GameObject[] wave2Enemies;
    public int[] wave2Amounts;
}