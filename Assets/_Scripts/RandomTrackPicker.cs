using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrackPicker : MonoBehaviour
{
    public List<AudioClip> clips;
    public AudioSource source;


    private void Start()
    {
        var index = Random.Range(0, clips.Count);
        var clip = clips[index];

        source.clip = clip;
        source.Play();
    }
}
