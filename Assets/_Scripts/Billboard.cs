using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera theCam;
    private float yRotation;
    [SerializeField] private bool useLocal = false;

    void Start()
    {
        theCam = Camera.main;
        SpriteFaceCamera();


    }

    // Update is called once per frame
    private void Update()
    {
        SpriteFaceCamera();
    }

    public void SpriteFaceCamera()
    {
        if (!useLocal) {
            transform.rotation = theCam.transform.rotation;
        }
        else {
            transform.localRotation = theCam.transform.rotation;
        }
        //transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y - 180, 0f);
    }


}
