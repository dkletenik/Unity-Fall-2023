using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveHighScores : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    const string NAME_KEY = "TopScoreName";
    const string SCORE_KEY = "TopScore";
    const int NUM_HIGH_SCORES = 5;

    [SerializeField] TMP_Text[] nameTexts;
    [SerializeField] TMP_Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();

        playerScore = playerScore + Random.Range(11,21);

        SaveScore();
        ViewScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveScore()
    {
        for (int i = 1; i <=  NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;


            //first check if there is a high scoring playe
            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                /* in middle */
                //then check if player's score is greater than existing high score
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);


                if (playerScore > currentScore)
                {
                    int tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetInt(currentScoreKey, playerScore);
                    PlayerPrefs.SetString(currentNameKey, playerName);

                    playerScore = tempScore;
                    playerName = tempName;
                }
                
            }
        

            else
            {
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                PlayerPrefs.SetString(currentNameKey, playerName);
                return;
            }
        }

    }

    public void ViewScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].SetText(PlayerPrefs.GetString(NAME_KEY+(i+1)));
            scoreTexts[i].SetText(PlayerPrefs.GetInt(SCORE_KEY+(i+1)).ToString());
        }

    }
}
