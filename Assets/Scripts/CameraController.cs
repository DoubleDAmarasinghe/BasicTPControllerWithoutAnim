using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float camerasense;
    public Transform parent;
    float xrotation = 0f;



    void Start()
    {
        //parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * camerasense * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * camerasense * Time.deltaTime;
        xrotation -= mousey;
        xrotation = Mathf.Clamp(xrotation, -10f, 10f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        parent.Rotate(Vector3.up * mouseX);


    }


}
