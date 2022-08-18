using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransitioning = false;//this sets bool state that the game is being played

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) {return;}//this starts the if statemnt which means if you are not in transition then do these things

        switch(other.gameObject.tag)//Variable to compare
        {
            case "Friendly"://this is the tag
                
                break;//this means stop there is no more to do dont do any of the other cases as this one is satisfied
            case "Finish":
                StartSuccessSequence();
                break;    
            default://this means if none ofthe other cases are satisfied then do this
                StartCrashSequence();
            break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;//this set the bool to true 
        successParticles.Play();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        crashParticles.Play();
        audioSource.PlayOneShot(crash);
        
        GetComponent<Movement>().enabled = false;
        Invoke("ReLoadLevel", delay);
        
    }

    void ReLoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//this is the variable and can be placed in the brackets for load scene
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//this is the variable and can be placed in the brackets for load scene
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
