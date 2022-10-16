using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLightsMech : MonoBehaviour
{
    public BioFeedRandom bio;
    Light headLight;

    void Start()
    {
        headLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bio.biofeedValue);

        headLight.intensity = map(bio.biofeedValue, 60f, 160f, 1000f, 10f);
        headLight.range = map(bio.biofeedValue, 60f, 160f, 500f, 5f);
        headLight.innerSpotAngle = map(bio.biofeedValue, 60f, 160f, 80f, 0f);
        headLight.spotAngle = map(bio.biofeedValue, 60f, 160f, 100f, 10f);
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

}