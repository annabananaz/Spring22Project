using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    private int livesLeft = 1;
    public RawImage livesImage;

    public Texture2D deadImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //testing lives
        if (Input.GetKeyDown("p"))
        {
            DecreaseLives();
        }
        if (Input.GetKeyDown("o"))
        {
            IncreaseLives();
        }
    }

    //functions to alter the lives on the UI.
    public void IncreaseLives()
    {
        livesLeft++;

        livesText.text = "X " + livesLeft.ToString();
    }

    public void DecreaseLives()
    {
        livesLeft = livesLeft - 1;

        livesText.text = "X " + livesLeft.ToString();

        // if the player is out of lives, then change the image to dead face
        if (livesLeft <= 0)
        {
            livesImage.texture = deadImage;

            Debug.Log("You Died");
        }
    }
}
