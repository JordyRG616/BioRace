using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XController : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] private Transform model;
    [SerializeField] private float topSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float restituitionForce;
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
    private float _speed = 0;
    private float speed
    {
        get => _speed;
        set
        {
            if (value < -topSpeed) _speed = -topSpeed;
            else if (value > topSpeed) _speed = topSpeed;
            else _speed = value;
        }
    }

    private void Update()
    {
        position += CurrentSpeed() * Time.deltaTime;
        var pos = Mathf.Lerp(-limit, limit, position);
        car.localPosition = new Vector3(car.localPosition.x, pos);
        var _angle = modelAngleTilt * CurrentSpeed();
        var angle = Mathf.SmoothDampAngle(model.localEulerAngles.y, _angle, ref currentVelocity, .1f);
        model.localRotation = Quaternion.Euler(model.localEulerAngles.x, angle, model.localEulerAngles.z);
    }

    private float CurrentSpeed()
    {
        var direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            speed += direction * acceleration;
        }
        else if(Mathf.Abs(speed) > 0)
        {
            speed += -Mathf.Sign(speed) * restituitionForce;
        }

        return speed;
    }

    private float TurnDirection()
    {
        var offset = new Vector2(Screen.currentResolution.width, Screen.currentResolution.width) / 2;
        var pos = (Vector2)Input.mousePosition - offset;

        if (Mathf.Abs(pos.x) < boundaries) return 0;

        return Mathf.Sign(pos.x) / 2;
    }
}
