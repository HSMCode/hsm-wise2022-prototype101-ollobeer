using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    public GameObject Roboter;

    AudioSource audioData;
    ParticleSystem particle;


    private void OnTriggerEnter(Collider other){
        Debug.Log(gameObject.name + " hat das Ziel: " + other.name + "erreicht");

        if(other.name == Roboter.name){
            Debug.Log("Victory");
            
            //Sound
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Debug.Log("Audio played");

            //Particle
            particle = GetComponent<ParticleSystem>();
            particle.Play();
            Debug.Log("start particle");
        }
    }

    
}
