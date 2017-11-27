using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    
    // Чувствительность мыши
    public float sensitivity = 3.0f;

    // Максимальный и минимальный углы, на которые можно смотреть по вертикали
    private float minAngle = -10;
    private float maxAngle = 10;

    private Rigidbody body;
    private float rotationX;

    void Start ()
    {
        body = GetComponent<Rigidbody>();

        // отключение влияния среды на игрока
        if (body != null)
            body.freezeRotation = true;
    }


    void Update()
    {
        // Вертикальная ось - Mouse Y
        // Горизонтальная ось - Mouse X
        var xRotation = Input.GetAxis("Mouse Y") * sensitivity;
        var yRotation = Input.GetAxis("Mouse X") * sensitivity;

        // управление головой (камерой) по движениям мыши
        float rotationY = transform.localEulerAngles.y + yRotation;
        rotationX += xRotation;
        rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);
    }


}
