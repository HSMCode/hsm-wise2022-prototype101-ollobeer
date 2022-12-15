using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{

    //  public Transform Player;
    //  int MoveSpeed = 4;

    public Transform target;
    public Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(Player);
        // transform.position += transform.forward * MoveSpeed * Time.deltaTime;


        transform.LookAt(target);
        transform.Translate(Vector3.forward*5*Time.deltaTime);
    }
}
