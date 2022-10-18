using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public BioFeedRandom bio;
    public GameObject[] circles;
    private int life;
    private bool dead;
    public AudioSource source;

    private void Start()
    {
        life = circles.Length;
        Time.timeScale = 1; 
    }
    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            FindObjectOfType<XController>().GameOver();
        }
    }

    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(circles[life].gameObject);
            bio.baseValue += 30;
            source.Play();

            if (life < 1)
            {
                dead = true;
            }
        }

        
    }
}
