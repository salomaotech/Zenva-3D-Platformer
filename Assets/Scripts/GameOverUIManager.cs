using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverUIManager : MonoBehaviour
{

    public Text score;
    public Text maxPoints;

    void Start()
    {

        try
        {
            score.text = "Pontos: " + GameManager.instance.score.ToString();
            maxPoints.text = "Máximo: " + GameManager.instance.maxPoints.ToString();

        }
        catch
        {

        }

    }

    public void RestartGame()
    {

        GameManager.instance.Reset();

    }

}
