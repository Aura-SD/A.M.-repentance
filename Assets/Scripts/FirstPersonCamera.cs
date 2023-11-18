using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;

    float sensitivity = 200;

    Vector2 rotation = Vector2.zero;

    public float yRotationMinimum = -65;
    public float yRotationMaximum = 65;

    // Update is called once per frame
    void Update()
    {
        rotation.x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotation.y -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        rotation.y = Mathf.Clamp(rotation.y, yRotationMinimum, yRotationMaximum);

        player.Rotate(player.up * rotation.x);

        transform.localRotation = Quaternion.Euler(rotation.y, 0, 0);
    }
}
