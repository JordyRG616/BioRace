using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public Vector3 target;
    public float velocity = 5f;
    public GameObject fxExplosao;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, target, velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("pista"))
        {
            GameObject smallExplosion = Instantiate(fxExplosao.gameObject, transform.position, transform.rotation);
            smallExplosion.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}

