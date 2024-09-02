using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private InputAction _movement;
    [SerializeField] private InputAction _shoot;
    [SerializeField] private InputAction _quit;
    [SerializeField] private InputAction _restart;

    private bool isPlayerMoving;
    private bool isShooting;
    public float speed = 10;
    private float moveDirection;

    void Start()
    {
        _playerInput.currentActionMap.Enable();
        _movement = _playerInput.currentActionMap.FindAction("Movement");
        _restart = _playerInput.currentActionMap.FindAction("Restart");
        _shoot = _playerInput.currentActionMap.FindAction("Shoot");
        _quit = _playerInput.currentActionMap.FindAction("Quit");

        _movement.started += _movement_started;
        _movement.canceled += _movement_canceled;
        _restart.performed += Restart_Performed;
        _quit.performed += Quit_Performed;
        _shoot.started += _shoot_started;
        _shoot.canceled += _shoot_canceled;

        isPlayerMoving = false;
    }

    private void _shoot_canceled(InputAction.CallbackContext context)
    {
        isShooting = false;
    }

    private void _shoot_started(InputAction.CallbackContext context)
    {
        isShooting = true;
    }

    private void Quit_Performed(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void Restart_Performed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void _movement_canceled(InputAction.CallbackContext context)
    {
        isPlayerMoving = false;
        Debug.Log("moving stopped");
    }

    private void _movement_started(InputAction.CallbackContext context)
    {
        isPlayerMoving = true;
        Debug.Log("moving started");
    }

    void Update()
    {
        if (isPlayerMoving)
        {
            moveDirection = _movement.ReadValue<float>();
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerMoving == true)
        {
            _player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed * moveDirection);
        }
        else
        {
            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
