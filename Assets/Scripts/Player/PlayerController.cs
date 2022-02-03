using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Camera _camera;

    public float _maxSpeed = 15.0f;
    public float _minSpeed = 15.0f;
    public float _currentSpeed;


    private float _mouseSensitivity = 5.0f;
    private float xRotation = 0f;
    private Vector3 _playerVelocity;

    void Start()
    {
        Time.timeScale = 1;
        _characterController = GetComponent<CharacterController>();

        _camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Time.timeScale >= 0.01f)
        {
            _currentSpeed = _minSpeed;

            //Value from -1 to 1.
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            //Move Player based on ZQSD input.
            Vector3 movement = transform.forward * vertical + transform.right * horizontal; //Instead of Vector3 wich give us forward and right in world space.
            _characterController.Move(movement * _currentSpeed * Time.deltaTime);

            //Get Mouse position input.
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

            //Rotate camera with Y mouse's input.
            xRotation -= mouseY; //Same as xRotation = xRotation - mouseY.

            //Clamp camera's movement between 80 and -70 degrees on Y axis. U need a stored value for using clamp function.

            xRotation = Mathf.Clamp(xRotation, -70.0f, 60.0f); //Mathf register few commun mathematical functions.
            _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //Better to initialize camera first to avoid to call it many times in Update().

            _playerVelocity.y += -9.18f * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);

            //Rotate camera with X mouse's input.
            transform.Rotate(Vector3.up * mouseX * 3 / 4);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _currentSpeed = _maxSpeed;
                /*_characterController.Move(movement * _currentSpeed * Time.deltaTime);*/
            }
       }
    }
    private void FixedUpdate()
    {
        //Detect if Player is grounded.
        if (_characterController.isGrounded)
        {
            _playerVelocity.y = 0f;
        }
        else
        {
            //If not grounded apply gravity to the Player.
            _playerVelocity.y += -9.18f * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }
    }
}
