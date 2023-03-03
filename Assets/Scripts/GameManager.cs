using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public int score = 0;
    public int hightScore = 0;
    public int currentLevel = 1;
    public int hightLevel = 2;
    public int maxPoints = 13;

    void Awake()
    {
       
        if(instance == null)
        {

            instance = this;

        }else if(instance != this)
        {

            Destroy(gameObject);

        }

        DontDestroyOnLoad(gameObject);

    }

    public void IncreaseScore(int amount)
    {

        score += amount;

        if (score > hightScore)
        {

            hightScore = score;

        }


        if(score >= maxPoints)
        {

            SceneManager.LoadScene("Level2");

        }

    }

    public void Reset()
    {

        score = 0;
        currentLevel = 1;
        SceneManager.LoadScene("Level" + currentLevel);

    }

    public void IncreaseLevel()
    {

        if(currentLevel < hightLevel)
        {

            currentLevel++;

        }
        else
        {

            currentLevel = 1;

        }

        SceneManager.LoadScene("Level" + currentLevel);

    }

}
