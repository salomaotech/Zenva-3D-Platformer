using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public int score = 0;
    public int hightScore = 0;

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

        print("Ponto: " + score.ToString());

        if (score > hightScore)
        {

           score = hightScore;

        }

        

    }

}
