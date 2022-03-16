using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //target is who is being followed
    // offset is the desired distance to maintain from the target

    public Transform target;

    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f; 
    private float currentX = 0f;

    private float currentY = 0f;

    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    private const float Y_Angle_MIN = 0f;
    private const float Y_Angle_MAX = 50f;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;

        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {

        currentX += Input.GetAxis("CameraHorizontal");
        currentY += Input.GetAxis("CameraVertical");

        currentY = Mathf.Clamp(currentY, Y_Angle_MIN, Y_Angle_MAX);

    }

    //called after player moves
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0,-distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = target.position + rotation * dir;

        //look at player
        camTransform.LookAt(target.position);
    }

}
