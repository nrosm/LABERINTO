using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 3f; // Velocidad de movimiento del personaje
    public float mouseSensitivity = 2f; // Sensibilidad del ratón
    public Transform cameraTransform; // La cámara asociada al personaje
    public float maxVerticalAngle = 80f; // Ángulo máximo de rotación vertical
    private float verticalRotation = 0f;


    void Start()
    {
        // Bloquear y ocultar el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento vertical y horizontal del personaje
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        // Al pulsar shift, aumenta tu velocidad considerablente. 
        if(Input.GetKey(KeyCode.LeftShift))
            velocidad = 8f;
        // Si no estás pulsando shift, vuelves a la velocidad original
        if(Input.GetKey(KeyCode.LeftShift) == false)
            velocidad = 2f;
        
        Vector3 moveDirection = transform.forward * vInput + transform.right * hInput;
        transform.position += moveDirection * velocidad * Time.deltaTime;

        // Rotación del personaje y de la cámara con el ratón
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity; // Movimiento horizontal del ratón
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity; // Movimiento vertical del ratón

        // Rotar el personaje en el eje Y (horizontal)
        transform.Rotate(0, mouseX, 0);

        // Rotar la cámara en el eje X (vertical)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxVerticalAngle, maxVerticalAngle);

        
    }
}

