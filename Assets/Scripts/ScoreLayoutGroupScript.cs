using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLayoutGroupScript : MonoBehaviour
{
    [SerializeField] private RoundManagerScript roundManager;
    [SerializeField] private GameObject playerScorePannelPrefab;
    private List<GameObject> scorePannel = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < roundManager.numberOfPlayer; i++)
        {
            GameObject scorePlayerObject = Instantiate(playerScorePannelPrefab);
            scorePlayerObject.transform.SetParent(transform);
            scorePannel.Add(scorePlayerObject);
        }

        foreach (GameObject pannel in scorePannel)
        {
            GameObject scoreTextObject = pannel.GetComponent<playerscorepannelprefabscript>().scoreText;
            string texscore = "ouais";
            GameObject numberplayerText = pannel.GetComponent<playerscorepannelprefabscript>().playerNumberText;
            string texPlayerNumber = "pou";

            if (pannel == scorePannel[0])
            {
                texscore = ScoresStoring.ScorePlayer1.ToString();
                texPlayerNumber = "Joueur.euse 1";
            }
            else if (pannel == scorePannel[1])
            {
                texscore = ScoresStoring.ScorePlayer2.ToString();
                texPlayerNumber = "Joueur.euse 2";
            }
            else if (pannel == scorePannel[2])
            {
                texscore = ScoresStoring.ScorePlayer3.ToString();
                texPlayerNumber = "Joueur.euse 3";
            }
            else if (pannel == scorePannel[3])
            {
                texscore = ScoresStoring.ScorePlayer4.ToString();
                texPlayerNumber = "Joueur.euse 4";
            }

            scoreTextObject.GetComponent<TextMeshProUGUI>().text = texscore;
            numberplayerText.GetComponent<TextMeshProUGUI>().text = texPlayerNumber;
        }
    }

    public void updatingScore()
    {
        foreach (GameObject pannel in scorePannel)
        {
            GameObject scoreTextObject = pannel.GetComponent<playerscorepannelprefabscript>().scoreText;
            string texscore = "ouais";

            if (pannel == scorePannel[0])
            {
                texscore = ScoresStoring.ScorePlayer1.ToString();
            }
            else if (pannel == scorePannel[1])
            {
                texscore = ScoresStoring.ScorePlayer2.ToString();
            }
            else if (pannel == scorePannel[2])
            {
                texscore = ScoresStoring.ScorePlayer3.ToString();
            }
            else if (pannel == scorePannel[3])
            {
                texscore = ScoresStoring.ScorePlayer4.ToString();
            }

            scoreTextObject.GetComponent<TextMeshProUGUI>().text = texscore;
        }
    }
}
