using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int Health;
    public static bool gameOver = false;
    public GameObject GameLostText;
    
    void Start()
    {
        Health = 100;
    }

    
    void Update()
    {
        if (Health <= 0)
        {
            //SceneManager.LoadScene("GameOverScene");
            GameLostText.SetActive(true);
            gameOver = true;
        }

        Debug.Log(Health);
    }
}
