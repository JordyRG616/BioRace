using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XController : MonoBehaviour
{
    [SerializeField] private Transform cube;
    [SerializeField] private float speed;
    [SerializeField] private float limit;
    private float _p = 0.5f;
    private float position
    {
        get => _p;

        set
        {
            if (value < 0) _p = 0;
            else if (value > 1) _p = 1;
            else _p = value;
        }
    }


    private void Update()
    {
        position += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var pos = Mathf.Lerp(-limit, limit, position);
        cube.localPosition = new Vector3(cube.localPosition.x, pos);
    }
}
