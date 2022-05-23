using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 0;

    void Awake()
    { //a
      // ���� �������� HighScore ��� ���������� � PlayerPrefs, ��������� ���
        if (PlayerPrefs.HasKey("HighScore"))
        { // b
            score = PlayerPrefs.GetInt("HighScore");
        }
        // ��������� ������ ���������� HighScore � ���������
        PlayerPrefs.SetInt("HighScore", score); // c
    }
    void Update()
    { // b
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;
        // �������� HighScore � PlayerPrefs, ���� ����������
        if (score > PlayerPrefs.GetInt("HighScore"))
        { // d
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
