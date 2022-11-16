using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDecoy : MonoBehaviour
{

    public GameObject Roboter;
    // Start is called before the first frame update

    AudioSource audioData;

    // public AudioClip decoySFX;
    // public AudioSource _audiSource;


    private void OnTriggerEnter(Collider other){
        Debug.Log(gameObject.name + " touched this " + other.name + " object");

        if(other.name == Roboter.name){
            Debug.Log("Decoy eingesammelt");

            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Debug.Log("started");

            Destroy(gameObject, 1);

            
        }
        
    }
}
