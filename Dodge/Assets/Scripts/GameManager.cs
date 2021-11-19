using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameOverText;
    private Text timeText;
    private Text recordText;

    private float surviveTime;
    private bool isGameOver;

    private void Awake()
    {
        gameOverText = GameObject.Find("GameOver Text");
        timeText = GameObject.Find("Time Text").GetComponent<Text>();
        recordText = GameObject.Find("Record Text").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        } else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time : " + (int)bestTime;
    }
}
