using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool isGameOver = false;

    // Start is called before the first frame update
    public void GameOver()
    {

        if (!isGameOver)
        {

            Time.timeScale = 0f;

            SceneManager.LoadScene("GameOver");
        }
    }

    public void TryAgain()
    {

        SceneManager.LoadScene("MainGame");

    }

}
   

