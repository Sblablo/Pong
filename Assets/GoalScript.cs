using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public bool isLeft;
    public Score scoreScript;
    public BallScript ball;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (isLeft)
            {
                scoreScript.AddScore("Right");
                ball.StartForceNext("Left");
            }
            else
            {
                scoreScript.AddScore("Left");
                ball.StartForceNext("Right");
            }
            audio.Play();
        }
    }
}
