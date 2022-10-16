using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioFeedRandom : MonoBehaviour
{
    public int biofeedValue;
    private float interpolationPeriod = 1f;
    
    [HideInInspector]
    public int baseValue;
    private float time = 0.0f;
    
    private void Start()
    {
        baseValue = 60;
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            biofeedValue = (int)(baseValue + Mathf.Round(Random.Range(0f, 5f)));
             
        }
    }
}

