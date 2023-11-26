using UnityEngine;


public class ScoresStoring : MonoBehaviour
{
    public static int ScorePlayer1;
    public static int ScorePlayer2;
    public static int ScorePlayer3;
    public static int ScorePlayer4;
    public static ScoresStoring Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
