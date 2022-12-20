using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{

    private UpdateScoreTimer _UpdateScore;


    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;

        _UpdateScore = GameObject.Find("UpdateScoreTimer").GetComponent<UpdateScoreTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void addOne()
   {
        counter++;
        Debug.Log("Destroyed Enemies in EnemiesCounter: " + counter);

        _UpdateScore.addOne();
   }
}
