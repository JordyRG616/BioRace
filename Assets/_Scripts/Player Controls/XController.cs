using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XController : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] private Transform model;
    [SerializeField] private float speed;
    [SerializeField] private float limit;
    [SerializeField] private float boundaries;
    [SerializeField] private float modelAngleTilt;
    private float _p = 0.5f;
    private float currentVelocity;
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
        car.localPosition = new Vector3(car.localPosition.x, pos);
        var _angle = modelAngleTilt * Input.GetAxis("Horizontal");
        var angle = Mathf.SmoothDampAngle(model.localEulerAngles.y, _angle, ref currentVelocity, .1f);
        model.localRotation = Quaternion.Euler(model.localEulerAngles.x, angle, model.localEulerAngles.z);
    }

    private float TurnDirection()
    {
        var offset = new Vector2(Screen.currentResolution.width, Screen.currentResolution.width) / 2;
        var pos = (Vector2)Input.mousePosition - offset;

        if (Mathf.Abs(pos.x) < boundaries) return 0;

        return Mathf.Sign(pos.x) / 2;
    }
}
