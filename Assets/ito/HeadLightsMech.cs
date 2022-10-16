using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLightsMech : MonoBehaviour
{
    public BioFeedSimulator bio;

    Light headLight;
    void Start()
    {
        headLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        headLight.intensity = map(((float)bio.biofeedValue), 60f, 140f, 1000f, 2f);
        headLight.range = map(((float)bio.biofeedValue), 60f, 140f, 70f, 10f);
        headLight.innerSpotAngle = map(((float)bio.biofeedValue), 60f, 140f, 50f, 5f);
        headLight.spotAngle = map(((float)bio.biofeedValue), 60f, 140f, 60f, 15f);
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }

}