using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            tBasketGO.SetActive(false);
            basketList.Add(tBasketGO);
        }
        basketList.Reverse();
        basketList[0].SetActive(true);

        PlayerPrefs.SetInt("ScoreGameResult", 0);
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGO.GetComponent<Text>().text = "0";
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        GameObject tBasketGO = basketList[0];
        basketList.RemoveAt(0);
        Destroy(tBasketGO);
        // Если корзин не осталось^ перезапустить игру
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_GameOver");
        }
        else
            basketList[0].SetActive(true);
    }
}
