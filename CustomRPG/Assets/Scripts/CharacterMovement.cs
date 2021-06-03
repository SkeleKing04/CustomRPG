using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 0.5f;
    public float RotateSpeed = 1f;
    public float JumpForce = 10f;
    private Camera MainCamera;
    private Rigidbody m_rigidbody;
    private Terrain ground;
    public bool grounded;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        m_rigidbody = GetComponent<Rigidbody>();
        ground = FindObjectOfType<Terrain>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameManager.gameState)
        {
            case GameManager.e_GameState.Playing:
                // rotate the character according to left/right key presses
                m_rigidbody.position += (transform.right * Input.GetAxis("Horizontal") * MoveSpeed);
                m_rigidbody.position += (transform.forward * Input.GetAxis("Vertical") * MoveSpeed);
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * RotateSpeed * Time.deltaTime);
                m_rigidbody.position += (transform.up * Input.GetAxis("Jump") * JumpForce);
                //Quaternion cameraAngle = Quaternion.Euler(Input.GetAxis("Mouse Y") / 100, Input.GetAxis("Mouse X") / 100, 0);
                //rotate player left and right
                //rotate camera up and down
                MainCamera.transform.Rotate(new Vector3(-(Input.GetAxis("Mouse Y")),0, 0) * RotateSpeed * Time.deltaTime);
                MainCamera.transform.localRotation = Quaternion.Euler(MainCamera.transform.localRotation.eulerAngles.x,
                0, 0);
                break;
        }

    }
}
