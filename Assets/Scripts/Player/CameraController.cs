using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player player;
    public float mouseSens = 400f;
    private float yRotation = 0f;
    public float maxY;
    public float minY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // para que desaparezca el cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        yRotation -= mouseY; // el menos es importante
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(yRotation, 0, 0), 1f); //Lerp = interpolacion, euler es un vector normal

        player.transform.Rotate(Vector3.up * mouseX); //movimiento horizontal 

        if (yRotation >= maxY)
        {
            yRotation = maxY;
        }
        if (yRotation <= minY)
        {
            yRotation = minY;
        }
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}