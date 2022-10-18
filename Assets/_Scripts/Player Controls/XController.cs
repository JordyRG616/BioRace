using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XController : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] private Transform model;
    [SerializeField] private Transform Anchor;
    [SerializeField] private float topSpeed, fallSpeed, outOfControlFactor, timeToRegainControl, timer;
    [SerializeField] private float acceleration;
    [SerializeField] private float restituitionForce;
    [SerializeField] private float roadLimit;
    [SerializeField] private float limit;
    [SerializeField] private float boundaries;
    [SerializeField] private float modelAngleTilt;
    [Header("GameOver UI")]
    [SerializeField] private GameObject gameOverPanel;
    [Header("Audio")]
    public AudioSource engine, curve;
    private float sign;
    private float skrt;
    private float counter;
    private bool outOfControl;
    public bool falling, onRoad;
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
        if (falling) return;
        position += (CurrentSpeed()) * Time.deltaTime;
        var pos = Mathf.Lerp(-limit, limit, position);
        car.localPosition = new Vector3(car.localPosition.x, pos);
        var _angle = modelAngleTilt * CurrentSpeed();
        var angle = Mathf.SmoothDampAngle(model.localEulerAngles.y, _angle, ref currentVelocity, .1f);
        model.localRotation = Quaternion.Euler(model.localEulerAngles.x, angle, model.localEulerAngles.z);
        onRoad = IsOnRoad(pos);
        if(!IsOnRoad(pos))
        {
            StartCoroutine(Fall());
        }
    }

    private float Skrt()
    {
        if (!outOfControl) return 0;
        //counter -= Time.deltaTime / 2;

        skrt = outOfControlFactor * sign;

        //if(counter <= 0)
        //{
        //    skrt = Random.Range(outOfControlFactor / 2, outOfControlFactor);
        //    skrt *= sign;
        //    counter = timer;
        //}

        return skrt;
    }

    public void LoseControl()
    {
        outOfControl = true;
        sign = Mathf.Sign(Random.Range(-1f, 1f));
        Invoke("RegainControl", timeToRegainControl);
    }

    private void RegainControl()
    {
        outOfControl = false;
    }

    private IEnumerator Fall()
    {
        float step = 0;
        var wait = new WaitForSeconds(0.01f);
        falling = true;

        while (step < 1)
        {
            car.localPosition += Vector3.right * step * fallSpeed;
            step += 0.01f;
            yield return wait;
        }

        GameOver();
    }

    public void GameOver()
    {
        falling = true;
        Time.timeScale = 0.1f;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    private float CurrentSpeed()
    {
        var direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            speed += direction * acceleration;
            curve.volume = .45f;
        }
        else if(Mathf.Abs(speed) >= 0)
        {
            speed += -Mathf.Sign(speed) * restituitionForce;
            curve.volume = 0;
        }

        return speed + Skrt();
    }

    private float TurnDirection()
    {
        var offset = new Vector2(Screen.currentResolution.width, Screen.currentResolution.width) / 2;
        var pos = (Vector2)Input.mousePosition - offset;

        if (Mathf.Abs(pos.x) < boundaries) return 0;

        return Mathf.Sign(pos.x) / 2;
    }

    private bool IsOnRoad(float pos)
    {
        return Mathf.Abs(pos) < roadLimit;
    }
}
