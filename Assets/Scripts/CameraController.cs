using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //target is who is being followed
    // offset is the desired distance to maintain from the target

    public Transform target;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        // // pitch
        // float y = Input.GetAxis("CameraVertical");
        // // pan
        // float z = Input.GetAxis("CameraHorizontal");

        // transform.Rotate(0f, y, z);


        Rotate();
        // take the current location, the destination, and the time you want for the camera to reach the target destination
        // transform.position = Vector3.Lerp(transform.position, (target.position + offset), .125f);

        transform.position = target.position + offset;

        transform.LookAt(target.position);
    }

    void Rotate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("CameraVertical"), Vector3.up) * offset;
        offset.Set(offset.x, 2f, offset.z);
    }
}
