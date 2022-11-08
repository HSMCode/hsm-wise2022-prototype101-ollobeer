using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDecoy : MonoBehaviour
{

    public GameObject Roboter;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
        Debug.Log(gameObject.name + " touched this " + other.name + " object");

        
        if(other.name == Roboter.name){
            Debug.Log("Decoy eingesammelt");
        }
        
    }
}
