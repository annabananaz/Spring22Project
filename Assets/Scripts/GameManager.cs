using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // important variables
    public int lives = 1;

    public int beans = 0;

    public PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBeans(int num)
    {
        beans += num;
        playerUI.UpdateBeans(beans);
    }

    public void ChangeLives(int num)
    {
        lives += num;
        playerUI.UpdateLives(lives);
    }
}
