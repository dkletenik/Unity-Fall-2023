using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text sceneText;
    [SerializeField] int level;

    public const int DEFAULT_POINTS = 1;
    public const int SCORE_THRESHOLD = 10;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex - 1;
        DisplayScene();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void AddPoints(int points)
    {
        score += points;
        DisplayScore();

        if(score >= SCORE_THRESHOLD)
        {
            SceneManager.LoadScene(level + 2); //level is already 1 less than the index (e.g. 1 instead of 2)
        }
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

    }

    private void DisplayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    private void DisplayScene()
    {
        sceneText.SetText("Level: " + level);
    }
}
