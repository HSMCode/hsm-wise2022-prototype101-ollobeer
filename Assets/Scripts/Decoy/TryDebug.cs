using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryDebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is a log message.");
        Debug.LogWarning("This is a warning message!");
        Debug.LogError("This is an error message!");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            Debug.Log("This is a log message.");
        }else if (Input.GetKeyDown("2")) {
            Debug.LogWarning("This is a warning message!");
        }else if (Input.GetKeyDown("3")) {
            Debug.LogError("This is an error message!");
        }
        
        
        
    }
}
