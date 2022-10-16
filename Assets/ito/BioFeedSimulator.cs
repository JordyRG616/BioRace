using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioFeedSimulator : MonoBehaviour
{
    
    public int biofeedValue = 60;
    public float decimalValue = 60f;
    public int i = 5;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (biofeedValue > 140)
        {
            i = -i;
        }
        decimalValue += i * Time.deltaTime;
        biofeedValue = Mathf.RoundToInt(decimalValue);

        if (biofeedValue < 60)
        {
            i = -i;
        }

    }
}
