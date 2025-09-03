using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerCameraController : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _orientation;
    [SerializeField] private Rigidbody _rb;

    [Header("Camera Settings")]
    [SerializeField] private float speed = 14f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdatePlayerOrientation();
    }

    void Update()
    {
        UpdatePlayerOrientation();
    }

    private void UpdatePlayerOrientation()
    {
        Vector3 playerDirection = _player.position - new Vector3(transform.position.x, _player.position.y, transform.position.z);
        _orientation.forward = playerDirection.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = _orientation.forward * verticalInput + _orientation.right * horizontalInput;

        if (moveDirection != Vector3.zero)
        {
            _playerBody.forward = Vector3.Slerp(_playerBody.forward, moveDirection.normalized, Time.deltaTime * speed);
        }
    }
}
