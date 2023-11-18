using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private const float YMin = -50.0f;
    private const float YMax = 50.0f;

    public Transform lookAt;

    public float distanceFromPlayer = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensivity = 4.0f;


    // Update is called once per frame
    void Update()
    {

        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY -= Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Directon = new Vector3(0, 0, -distanceFromPlayer);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        transform.position = lookAt.position + rotation * Directon;
        transform.LookAt(lookAt.position);

    }
}
