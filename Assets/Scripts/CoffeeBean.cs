using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBean : MonoBehaviour {
    public GameObject player;
    //public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        // When the player collides with the coffee bean the bean adds to bean counter in the GameManager and then deletes itself
        if (collision.collider.tag == "Player")
        {
            //gameManager.GetComponent<GameManager>().coffeebeans++;
            Destroy(gameObject);
        }
    }
}
