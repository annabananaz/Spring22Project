using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    // everything related to lives.
    public TextMeshProUGUI livesText;
    private int livesLeft = 1;
    public Image livesImage;
    public Sprite deadImage;
    public Sprite aliveImage;

    public TextMeshProUGUI beansText;

    // Start is called before the first frame update
    void Start()
    {
        livesImage.GetComponent<Image>().sprite = aliveImage; 
    }

    // Update is called once per frame
    void Update()
    {
        /**/
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
    /**/
    //functions to alter the lives on the UI.
    public void IncreaseLives()
    {
        livesLeft++;

        livesText.text = "X " + livesLeft.ToString();

        if (livesLeft > 0)
        {
            livesImage.GetComponent<Image>().sprite = aliveImage;
        }
    }

    public void DecreaseLives()
    {
        livesLeft = livesLeft - 1;

        livesText.text = "X " + livesLeft.ToString();

        // if the player is out of lives, then change the image to dead face
        if (livesLeft <= 0)
        {
            livesImage.GetComponent<Image>().sprite = deadImage;

            Debug.Log("You Died");
        }
    }
    
    
    //alters the lives
    public void UpdateLives(int num)
    {
        if (num <= 0)
        {
            livesImage.GetComponent<Image>().sprite = deadImage;
        }

        livesText.text = "X " + num.ToString();
    }

    //alters the beans
    public void UpdateBeans(int num)
    {
        beansText.text = "X " + num.ToString();
    }
}
