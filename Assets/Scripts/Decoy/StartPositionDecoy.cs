using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionDecoy : MonoBehaviour
{

    public GameObject DecoyCube;
    public GameObject DecoyCube1;
    public GameObject DecoyCube2;
    


    public float spawnPositioX;
    public float spawnPositioZ;

    public float maxSpawnPositioX = 30f;
    public float maxSpawnPositioZ = 30f;

    public float startDelay = 0f;
    public float spawnInterval = 7f;

    public int spawnAmount = 4;
    // Start is called before the first frame update
    void Start()
    {
        //spawnDecoys();

        InvokeRepeating("spawnDecoys", startDelay, spawnInterval);
        
        //transform.Translate(Random.Range(-20, 20), 0, Random.Range(-20, 20));
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnDecoys(){
        for (int i = 0; i < 7; i++){

            spawnPositioX = Mathf.Floor(Random.Range(0f, maxSpawnPositioX));
            spawnPositioZ = Mathf.Floor(Random.Range(0f, maxSpawnPositioZ));


            Vector3 spawnPosition = new Vector3(Random.Range(-spawnPositioX, spawnPositioX), 0, Random.Range(-spawnPositioZ, spawnPositioZ));
            
            int wishDecoy = Random.Range(0,3); 

            if (wishDecoy == 0){
                Instantiate(DecoyCube, spawnPosition, transform.rotation);
            }else if (wishDecoy == 1) {
                Instantiate(DecoyCube1, spawnPosition, transform.rotation);
            }else {
                Instantiate(DecoyCube2, spawnPosition, transform.rotation);
            }
        }
    }
}
