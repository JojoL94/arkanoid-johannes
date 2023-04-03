using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpMode : MonoBehaviour
{
    public Material gluedMat;
    public Material noPowerUpMat;
    private bool glue = false;
    private bool grow = false;
    public GameObject ball;
    // Update is called once per frame
    public float timeRemaining = 20f;

    bool timerIsRunning = false;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - 1, transform.localScale.y, transform.localScale.z);
                timeRemaining = 20f;
                timerIsRunning = false;
            }
        }
    }
    public void PowerUpOn(int powerUpMode)
    {
        if (powerUpMode == 1)
        {
            ball.GetComponent<Ball>().Glued();
            glue = true;
            GetComponent<MeshRenderer> ().material = gluedMat;
        } else if (powerUpMode == 2)
        {
            grow = true;
            transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y, transform.localScale.z);
            if (timerIsRunning)
            {
                timeRemaining = timeRemaining + 20f;
            }
            else
            {
                timerIsRunning = true;
            }
        }
    }

    public bool Glue
    {
        set
        {
            glue = false;
            GetComponent<MeshRenderer> ().material = noPowerUpMat;
        }
    }
}
