using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour
{

    public float step = 1f;
    public float roStep = 90f;

    public float scale = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("w")){
            transform.Translate(0, 0, step);
        }

        if (Input.GetKeyDown("s")){
            transform.Translate(0, 0, -step);
        }

        if (Input.GetKeyDown("a")){
            transform.Translate(-step, 0 ,0);
        }

        if (Input.GetKeyDown("d")){
            transform.Translate(step, 0, 0);
        }

        //toate on the y to the right
        if (Input.GetKeyDown("e")) {
            transform.Rotate(0, roStep, 0);
        }

        //toate on the y to the left
        if (Input.GetKeyDown("q")) {
            transform.Rotate(0, -roStep, 0);
        }

        /*
        //change Scale
        if (Input.GetKeyDown("+")){
            transform.loacalScale(scale);
        }

        if (Input.GetKeyDown("-")){
            transform.localScale(-scale);
        }
        */

    }
}
