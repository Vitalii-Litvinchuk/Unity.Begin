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
                                                              // Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>(); // с
                                                       // Установить начальное число очков равным 0
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
      // Отыскать яблоко, попавшее в эту корзину
      Application.Quit();
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            // Преобразовать текст в scoreGT в целое число
            int score = int.Parse(scoreGT.text); // d
                                                 // Добавить очки за пойманное яблоко
            score += 100;
            // Преобразовать число очков обратно в строку и вывести ее на экран
            scoreGT.text = score.ToString();

            PlayerPrefs.SetInt("ScoreGameResult", score);

            // Запомнить высшее достижение
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
