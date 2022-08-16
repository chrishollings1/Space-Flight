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

    AudioSource audioSource;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)//Variable to compare
        {
            case "Friendly"://this is the tag
                Debug.Log("You are on the launch pad");//this is what to do there can be multipule conditions
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
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delay);
    }

    void StartCrashSequence()
    {
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
