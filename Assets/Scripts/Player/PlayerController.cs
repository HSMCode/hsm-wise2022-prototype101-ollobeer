using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float turnSpeed;    
    [SerializeField] float speed;

    private Animator _playerAnim;

    private Rigidbody _playerRb;
    public float force;
    // public float forceDown;
    public float gravityModifier = 1f;

    public bool isOnGround;
    public bool isJumping;
    public bool isFalling;
    public bool isLanding;

    public bool jumpCancelled;
    public float jumpTimer;
    public float jumpButtonPressedTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();

        // Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(_playerRb.velocity.y);

        // player is walking and running 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        
        _playerAnim.SetFloat("Run", forwardInput);

        if(forwardInput != 0 || horizontalInput != 0)
        {
            _playerAnim.SetBool("Walk", true);
        } 
        else 
        {
            _playerAnim.SetBool("Walk", false);    
        }

        // press space to jump - player is jumping
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !isFalling)
        {
            isOnGround = false;
            isJumping = true;

            if(isJumping)
            {
                _playerAnim.SetTrigger("Jump");

                //_playerRb.AddForce(force, ForceMode.Impulse);
            }
        }

        // release space to start falling - player isFalling
        if(isJumping)
        {
            jumpTimer += Time.deltaTime;
            if(Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
                isFalling = true;

                if(isFalling)
                {
                    _playerAnim.SetBool("Falling", true);
                }
            }
            if(jumpTimer > jumpButtonPressedTime)
            {
                isJumping = false;
                jumpCancelled = true;
            }
        }

        if(_playerRb.velocity.y < 0 && isFalling)
        {
            isFalling = false;
            isLanding = true;
            _playerAnim.SetBool("Falling", false);
        }
    }

    void FixedUpdate()
    {
        if(isJumping)
        {
            gravityModifier = 1f;
            _playerRb.AddForce(Vector3.up * force, ForceMode.Force);
        }

        if(isFalling || isOnGround || isLanding || jumpCancelled)
        {
           // _playerRb.AddForce(Vector3.down * forceDown * _playerRb.mass);
           gravityModifier = 30f;
        }

        _playerRb.AddForce(Physics.gravity * (gravityModifier - 1) * _playerRb.mass);
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.CompareTag("Ground"))
    //     {
    //         isOnGround = true;
    //     }
    // }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpTimer = 0;
            jumpCancelled = false;
            //isLanding = false;

            if(isLanding)
            {
                _playerAnim.SetBool("Land", false);
                isLanding = false;
            }
        }
    }

}