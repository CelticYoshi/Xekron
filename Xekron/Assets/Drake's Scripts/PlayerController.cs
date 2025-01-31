using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed;
    public float jumpForce = 10f;
    public float gravityModifier = 1f;
    public float mouseSensitivity = 1f;
    public GameObject bullet;
    public Transform firePoint;
    public Transform theCamera;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool _canPlayerJump;
    private Vector3 _moveInput;
    private CharacterController _characterController;
    [SerializeField] private Animator _playerAnimation;
    [SerializeField] private Transform _player;
    

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()

    {
        Vector3 movementDirection = (_player.position - transform.position).normalized;

        //Player jump setup
        float yVelocity = _moveInput.y;

        //Player movement
        //_moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //_moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 forwardDirection = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalDirection = transform.right * Input.GetAxis("Horizontal");

        _moveInput = (forwardDirection + horizontalDirection).normalized;
        _moveInput *= moveSpeed;

        //Apply Jumping
        _moveInput.y = yVelocity; 

        _moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;       

        //Check if character controller is on the ground
        if(_characterController.isGrounded)
        {
            Debug.Log (_characterController.isGrounded);
            _moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        //Check if player can jump
        _canPlayerJump = Physics.OverlapSphere(groundCheckpoint.position, 0.5f, whatIsGround).Length > 0;

        //Make player jump
        if(Input.GetKeyDown(KeyCode.Space) && _canPlayerJump)
        {
            _moveInput.y = jumpForce;
        }

        _characterController.Move(_moveInput * Time.deltaTime);

        //Camera rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
        
        theCamera.rotation = Quaternion.Euler(theCamera.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
         
         //Handle Shooting
        if(Input.GetMouseButtonDown(0))
        {
            //Find the crosshair
            RaycastHit hit;
            if(Physics.Raycast(theCamera.position, theCamera.forward, out hit, 50f))
            {
                if(Vector3.Distance(theCamera.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(theCamera.position + (theCamera.forward * 30f));
            }
            
            //Create the bullet
            Instantiate(bullet, firePoint.position, firePoint.rotation);

        }

    }
    public bool PlayerIsJumping()
        {
            return _characterController.isGrounded;
        }
}

