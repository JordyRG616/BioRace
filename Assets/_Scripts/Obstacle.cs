using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject cube, piramid, particles;

    private void Start()
    {
        var rdm = Random.Range(0, 1f);
        if (rdm < 0.5f)
        {
            cube.SetActive(true);
            piramid.SetActive(false);
        }
        else
        {
            cube.SetActive(false);
            piramid.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent.GetComponent<XController>().LoseControl();
            FindObjectOfType<LifeSystem>().TakeDamage(1);
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
