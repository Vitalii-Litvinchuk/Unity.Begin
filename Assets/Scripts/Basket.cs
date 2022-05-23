using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT; // a
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // b
                                                              // �������� ��������� Text ����� �������� �������
        scoreGT = scoreGO.GetComponent<Text>(); // �
                                                       // ���������� ��������� ����� ����� ������ 0
    }
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    { //a
      // �������� ������, �������� � ��� �������
      Application.Quit();
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            // ������������� ����� � scoreGT � ����� �����
            int score = int.Parse(scoreGT.text); // d
                                                 // �������� ���� �� ��������� ������
            score += 100;
            // ������������� ����� ����� ������� � ������ � ������� �� �� �����
            scoreGT.text = score.ToString();

            PlayerPrefs.SetInt("ScoreGameResult", score);

            // ��������� ������ ����������
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
