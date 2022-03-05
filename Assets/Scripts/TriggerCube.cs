using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public float damage = 10f;

    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Fall Cube")
        {
            Debug.Log("Fall Cube is gone");

            Destroy(collider.gameObject);
        }

        Debug.Log(collider.gameObject.name);
    }

}
