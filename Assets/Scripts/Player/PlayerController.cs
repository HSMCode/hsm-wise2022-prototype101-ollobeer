using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject Ground;

    public float horizontalInput;
    public float forwardInput;
    public float speed = 10;
    public float turnSpeed = 200;
    public float gravityScale;
    public bool isGrounded = true;
    public bool isJumping = false;
    public bool isFalling = false;

    public float force;
    public float gravityModifier;
    public float forceDown = 9.8f;

    private Animator _playerAnim;
    private Rigidbody _palyerRb;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _palyerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded){ 
            
            isGrounded = false;
            isJumping = true;
            if (isJumping){
                _playerAnim.SetTrigger("Jump");
            }
        }else {
            _playerAnim.SetTrigger("Jump");
        }

        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
            isFalling = true;

            if(isFalling){
                _playerAnim.SetBool("Fall", true);
            }
        }
        
    }

    void FixedUpdate(){
        if(isJumping){
            _palyerRb.AddForce(Vector3.up *force, ForceMode.Force);
        }
        if (isFalling || isGrounded){
            _palyerRb.AddForce(Vector3.down * forceDown * _palyerRb.mass);
        }
    }

    private void OnCollisionEnter(Collision collision){

        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;

            if(isFalling){
                _playerAnim.SetBool("Fall", false);
                isFalling = false;
            }
        }
        
    }
}
