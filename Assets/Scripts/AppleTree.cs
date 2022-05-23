using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleTree : MonoBehaviour
{
    //������ ������, ��� ���� �������� ������
    public GameObject applePrefab;
    //�������� ���������� �����
    public float speed = 1f;
    //��� � ���� ���� �������� ������
    public float leftAndRightEdge = 10f;
    //��������� ���� �������� ���� �����
    public float chanceToChangeDirections = 0.1f;
    //������� �������� ����� �� �����
    public float secondBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    private int scoreChanged = 0;

    private int treeDifficult = 1;
    void Start()
    {
        Invoke("DropApple", 2);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed); //��� � �����
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);

        int score = PlayerPrefs.GetInt("ScoreGameResult");

        if (score % 1000 == 0 && score != scoreChanged)
        {
            MultiplyDifficultRules((float)1.25, (float)0.95);
            scoreChanged = score;
            ++treeDifficult;
            GameObject scoreGO = GameObject.Find("DifficultTree");
            scoreGO.GetComponent<Text>().text = "Difficult tree: " + treeDifficult;
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    public void MultiplyTreeSpeed(float speed)
    {
        this.speed *= speed;
    }

    public void MultiplyAppleRate(float rate)
    {
        this.secondBetweenAppleDrops *= rate;
    }

    public void MultiplyDifficultRules(float speed, float secondRate)
    {
        MultiplyTreeSpeed(speed);
        MultiplyAppleRate(secondRate);

    }
}
