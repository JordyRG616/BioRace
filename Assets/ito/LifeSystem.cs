using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public BioFeedRandom bio;
    public GameObject[] circles;
    private int life;
    private bool dead;

    private void Start()
    {
        life = circles.Length;
    }
    // Update is called once per frame
    void Update()
    {
        if (dead == true)
        {
            Debug.Log("DEAD");
        }
    }

    public void TakeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(circles[life].gameObject);
            bio.baseValue += 30;

            if (life < 1)
            {
                dead = true;
            }
        }

        
    }
}
