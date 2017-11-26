using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    // Чувствительность мыши
    public float sensitivity = 3.0f;
    // Скорость игрока
    public float speed = 3.0f;

    // Максимальный и минимальный углы, на которые можно смотреть по вертикали
    private float minAngle = -10;
    private float maxAngle = 10;

    private Rigidbody player;
    private float rotationX;

    private CharacterController characterController;
    

    void Start()
    {

        characterController = GetComponent<CharacterController>();
        player = GetComponent<Rigidbody>();

        // отключение влияния среды на игрока
        if (player != null)
            player.freezeRotation = true;
    }

    // управление "головой" (камерой) по движениям мыши
    private void MouseMove()
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

    // Управление игроком с помощью клавиатуры
    private void MovePlayer()
    {
        var horizontalMovements = Input.GetAxis("Horizontal") * speed;
        var verticalMovements = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(horizontalMovements, 0, verticalMovements);
        // Ограничение на скорость движения по диагонали
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        // Игрок не будет ходить сквозь пол, стены и другие объекты
        characterController.Move(transform.TransformDirection(movement));
    }

    void Update()
    {
        MouseMove();
        MovePlayer();
    }


}
