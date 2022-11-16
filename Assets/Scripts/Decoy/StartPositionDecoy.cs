using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionDecoy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Random.Range(-20, 20), 0, Random.Range(-20, 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
