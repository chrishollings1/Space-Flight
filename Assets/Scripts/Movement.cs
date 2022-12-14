using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thruster = 100f;
    [SerializeField] float rotationThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainParticles;
    [SerializeField] ParticleSystem leftParticles;
    [SerializeField] ParticleSystem leftParticles1;
    [SerializeField] ParticleSystem rightParticles;
    [SerializeField] ParticleSystem rightParticles1;

    Rigidbody rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

     void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftRotation();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RightRotation();
        }
        else
        {
            StopEffects();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thruster * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainParticles.isPlaying)
        {
            mainParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        mainParticles.Stop();
    }
    
    void LeftRotation()
    {
        ApplyRotation(rotationThrust);
        if (!rightParticles.isPlaying && !rightParticles1.isPlaying)
        {
            rightParticles.Play();
            rightParticles1.Play();
        }
    }

    void RightRotation()
    {
        ApplyRotation(-rotationThrust);
        if (!leftParticles.isPlaying && !leftParticles1.isPlaying)
        {
            leftParticles.Play();
            leftParticles1.Play();
        }
    }

    void StopEffects()
    {
        rightParticles.Stop();
        rightParticles1.Stop();
        leftParticles.Stop();
        leftParticles1.Stop();
    }
    
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freeze rotation so we can manualy rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreeze rotation so the physics can takeover
    }
}
