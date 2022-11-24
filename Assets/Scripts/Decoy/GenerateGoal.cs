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

        posX = Random.Range(minSpawnPositionXZ, maxSpawnPositionXZ);
        posZ = Random.Range(minSpawnPositionXZ, maxSpawnPositionXZ);
       
        if (isNegative() == true){
            posX = posX - posX*2;
        }

        if (isNegative() == true){
            posZ = posZ - posZ*2;
        }

        transform.Translate(Mathf.Floor(posX), 0, Mathf.Floor(posZ));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isNegative(){
        if (Random.Range(0, 11) < 5){
            return true;
        }else {
            return false;
        }
    }
}
