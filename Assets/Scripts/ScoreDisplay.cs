using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    private int _scoreP1;
    private int _scoreP2;
    private int _scoreP3;
    private int _scoreP4;
    

    private void Start()
    {
        _scoreP1 = ScoresStoring.ScorePlayer1;
        _scoreP2 = ScoresStoring.ScorePlayer2;
        _scoreP3 = ScoresStoring.ScorePlayer3;
        _scoreP4 = ScoresStoring.ScorePlayer4;
        score.text = $"Scores Finaux :\n Joueur 1 : {_scoreP1} points\n Joueur 2 : {_scoreP2} points\n Joueur {3} : {_scoreP3} points\n Joueur 4 : {_scoreP4} points";
    }
}
