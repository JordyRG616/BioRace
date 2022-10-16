using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FreqText : MonoBehaviour
{
    public BioFeedRandom bio;
    private TextMeshProUGUI textMesh;
    private float frequency;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        frequency = bio.biofeedValue;
        textMesh.text = frequency.ToString();
    }
}
