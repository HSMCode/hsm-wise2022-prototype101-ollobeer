using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float forwardInput;
    public float speed = 10;
    public float turnSpeed = 200;
    public Vector3 force;

    private Animator _playerAnim;
    private Rigidbody _palyerRb;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _palyerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);


        _playerAnim.SetFloat("Run", forwardInput);

        if (forwardInput != 0 || horizontalInput != 0){
            _playerAnim.SetBool("Walk", true);
        }else {
            _playerAnim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            _palyerRb.AddForce(force, ForceMode.Impulse);
            _playerAnim.SetTrigger("Jump");
        }
        
    }
}
