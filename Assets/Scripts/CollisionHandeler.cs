using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
   void OnCollisionEnter(Collision other) 
   {
        switch(other.gameObject.tag)//Variable to compare
        {
            case "Friendly"://this is the tag
                Debug.Log("You are on the launch pad");//this is what to do there can be multipule conditions
                break;//this means stop there is no more to do dont do any of the other cases as this one is satisfied
            case "Finish":
                Debug.Log("You have landed");
                break;    
            default://this means if none ofthe other cases are satisfied then do this
            ReLoadLevel();
            break;
        }
   }

    void ReLoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;//this is the variable and can be placed in the brackets for load scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}
