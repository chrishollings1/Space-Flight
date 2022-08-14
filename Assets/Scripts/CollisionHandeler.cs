using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandeler : MonoBehaviour
{
   void OnCollisionEnter(Collision other) 
   {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You are on the launch pad");
                break;
            case "Finish":
                Debug.Log("You have landed");
                break;    
            default:
            Debug.Log("Sorry you died");
            break;
        }
   }
}
