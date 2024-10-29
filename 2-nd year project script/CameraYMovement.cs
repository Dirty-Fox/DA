using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraYMovement : MonoBehaviour
{
    float xRotation;

    void Update()
    {
        //Mouse Control
        float mouseY = Input.GetAxis("Mouse Y");

        if (MenuManager.menuActive == false)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 70f);

            transform.localRotation = Quaternion.Euler(xRotation, -90f, 0f);
        }

    }
}
