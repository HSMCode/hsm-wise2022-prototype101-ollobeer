using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGoal : MonoBehaviour
{

    public static float minSpawnPositionXZ = 5f;
    public static float maxSpawnPositionXZ = 30f;

    public float posX;
    public float posZ;


    // Start is called before the first frame update
    void Start()
    {
        //randomly generates a postive position for X and Z
        posX = Random.Range(minSpawnPositionXZ, maxSpawnPositionXZ);
        posZ = Random.Range(minSpawnPositionXZ, maxSpawnPositionXZ);

        //Randomly turns the Numbers negative
        posX = randomlyTurnNegative(posX);
        posZ = randomlyTurnNegative(posZ);
       
        // if (isNegative() == true){
        //     posX = posX - posX*2;
        // }

        // if (isNegative() == true){
        //     posZ = posZ - posZ*2;
        // }

        //sets the startposition for 
        transform.Translate(Mathf.Floor(posX), 0, Mathf.Floor(posZ));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float randomlyTurnNegative (float pos){
        if (isNegative() == true){
            pos = pos - pos*2;
            return pos;
        }else {
            return pos;
        }
    }

    public bool isNegative(){
        if (Random.Range(0, 11) < 5){
            return true;
        }else {
            return false;
        }
    }
}
