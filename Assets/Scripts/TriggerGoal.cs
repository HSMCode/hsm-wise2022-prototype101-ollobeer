using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    public GameObject Roboter;
    private void OnTriggerEnter(Collider other){
        Debug.Log(gameObject.name + " hat das Ziel: " + other.name + "erreicht");

        if(other.name == Roboter.name){
            Debug.Log("Victory");
        }
    }
}
