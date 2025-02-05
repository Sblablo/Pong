using System;
using UnityEngine;
using Random = UnityEngine.Random;
using FirstGearGames.SmoothCameraShaker;

public class BallScript : MonoBehaviour
{
    public float startspeed = 300f;
    private Rigidbody rbody;
    private AudioSource audio;
    private ParticleSystem particles;
    private Renderer renderer;

    public AudioClip bounceWall;
    public AudioClip bouncePaddle;

    public ShakeData shakeData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rbody = GetComponent<Rigidbody>();
        particles = GetComponent<ParticleSystem>();
        renderer = GetComponent<Renderer>();
        StartForce();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(0f, 1f, 0f);
        Quaternion posRotation = Quaternion.Euler(45f, 0f, 0f);
        Vector3 posVector = posRotation * up;
        
        Quaternion negRotation = Quaternion.Euler(-45f, 0f, 0f);
        Vector3 negVector = negRotation * up;
        
        
        Debug.DrawRay(transform.position, posVector * 2f, Color.red);
        Debug.DrawRay(transform.position, negVector * 2f, Color.blue);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"made contact with {other.gameObject.name}");

        if (other.gameObject.CompareTag("Player"))
        {
            float speed = other.relativeVelocity.magnitude;
            float newSpeed = speed * 1.5f;

            Vector3 newVelocity = other.relativeVelocity;
            newVelocity = newVelocity.normalized * newSpeed;
        
            rbody.linearVelocity = newVelocity;
            
            audio.resource = bouncePaddle;
            audio.Play();
            if (renderer.material.GetColor("_BaseColor") != Color.red)
                renderer.material.SetColor("_BaseColor", Color.red);
            else
            {
                renderer.material.SetColor("_BaseColor", Color.blue);
            }
        }
        else
        {
            audio.resource = bounceWall;
            audio.Play();
        }

        float angle = Mathf.Atan2(rbody.linearVelocity.x, rbody.linearVelocity.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, -angle, 0);
        particles.Play();
        CameraShakerHandler.Shake(shakeData);
    }

    private void StartForce()
    {
        transform.position = new Vector3(10.12f, 0, 0);
        rbody.linearVelocity = Vector3.zero;
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        rbody.AddForce(new Vector3(x, 0, z) * startspeed);
    }

    public void StartForceNext(string direction)
    {
        transform.position = new Vector3(10.12f, 0, 0);
        rbody.linearVelocity = Vector3.zero;
        float x;
        float z = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        if (direction == "Left")
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
        
        rbody.AddForce(new Vector3(x, 0, z) * startspeed);
    }
}
