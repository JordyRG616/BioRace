using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioFeedRandom : MonoBehaviour
{
    public float biofeedValue;
    private float time = 0.0f;
    public float interpolationPeriod = 1f;

    private void Start()
    {
        biofeedValue = 60f;
    }
    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            biofeedValue = Mathf.Round(Random.Range(0f, 5f));
             
        }
    }
}

