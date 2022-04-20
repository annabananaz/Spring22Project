using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBean : MonoBehaviour {
    //public GameObject gameManager;
    // Start is called before the first frame update
    public float rotationSpd;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpd);
    }

    void OnTriggerEnter(Collider collider) {

        Debug.Log("Test");
        // When the player collides with the coffee bean the bean adds to bean counter in the GameManager and then deletes itself
        if (collider.gameObject.tag == "Player")
        {
            var manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.ChangeBeans(1);

            Destroy(gameObject);
        }
    }
}
