using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgain : MonoBehaviour
{
    void Start()
    {
        GameObject scoreGO = GameObject.Find("YourScore");
        scoreGO.GetComponent<Text>().text = "Your score: " + PlayerPrefs.GetInt("ScoreGameResult");
    }
}
