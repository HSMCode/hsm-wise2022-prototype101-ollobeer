using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject enemy; 
    public float spawnPositionX = 10f;
    public float spawnPositionZ = 10f;
    public int spawnAmount= 1;

    public float startDelay = 0f;
    public float spawnInterval=7f;
    

    // Start is called before the first frame update
    void Start()
    {
        //SpawningEnemyParam(1);

        InvokeRepeating("SpawningEnemyParam", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawningEnemyParam()
    {
        for (int i = 0; i< spawnAmount; i++)
        {
            // generate random spawn position between the defined values
            Vector3 spawnPosition = new Vector3 (Mathf.Floor(Random.Range(-spawnPositionX,spawnPositionX)),5,Mathf.Floor(Random.Range(-spawnPositionZ,spawnPositionZ)));
            
            // instantiate Enemy
            Instantiate (enemy, spawnPosition, transform.rotation);
        }
    }
}
