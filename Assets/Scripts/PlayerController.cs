using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Variables usadas
    [Header("References")]
    public Camera playerCamera;

    [Header("Items")]
    public int eggs = 0;
    public int mayo = 0;
    public int milk = 0;
    public int cheese = 0;
    public int cash = 0;

    //Caracteristicas del personaje
    [Header("Move Settings")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float gravityScale = -0.05f;

    [Header("Jump Settings")]
    public float jumpHeight = 1000f;

    [Header("Rotation Settings")]
    public float rotationSensibility = 10f;

    [Header("HUD Text")]
    public TMP_Text eggsText;
    public TMP_Text milkText;
    public TMP_Text cashText;
    public TMP_Text mayoText;
    public TMP_Text cheeseText;


    private float cameraVerticalAngle;
    Vector3 moveInput = Vector3.zero;
    Vector3 rotationinput = Vector3.zero;
    CharacterController characterController;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Look();
        UpdateValueText();
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            moveInput = transform.TransformDirection(moveInput) * runSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
            }
        }
        moveInput.y += gravityScale + Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

    private void Look()
    {
        rotationinput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        cameraVerticalAngle = cameraVerticalAngle + rotationinput.y;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);
    }

    private void UpdateValueText()
    {
        eggsText.text = eggs.ToString(); // Actualizar el valor en el Text del UI
        milkText.text = milk.ToString(); // Actualizar el valor en el Text del UI
        cheeseText.text = cheese.ToString(); // Actualizar el valor en el Text del UI
        mayoText.text = mayo.ToString(); // Actualizar el valor en el Text del UI
        cashText.text = cash.ToString(); // Actualizar el valor en el Text del UI
    }

}