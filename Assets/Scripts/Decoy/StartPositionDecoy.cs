using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionDecoy : MonoBehaviour
{

    public GameObject DecoyCube;

    public float spawnPositioX = 15f;
    public float spawnPositioZ = 15f;

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
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnPositioX, spawnPositioX), 0, Random.Range(-spawnPositioZ, spawnPositioZ));

            Instantiate(DecoyCube, spawnPosition, transform.rotation);
        }
    }
}
