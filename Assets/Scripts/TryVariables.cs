using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryVariables : MonoBehaviour
{

    //Variables 
    public int timeToGetTheBullet = 2;
    public int timeToPushTheBulletIn = 4;
    public int timeToCloseTheSlider = 78;
    public int timeToLoad = 5;
    public int timeToRelease = 65;

    public int timeNeeded;

    public string sentence = "Time for complete Reload: ";


    // Start is called before the first frame update
    void Start()
    {
        timeNeeded = (timeToGetTheBullet + timeToPushTheBulletIn + timeToCloseTheSlider + timeToLoad + timeToRelease) / 3;
        Debug.Log(timeNeeded);
        Debug.Log(sentence + timeNeeded);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
