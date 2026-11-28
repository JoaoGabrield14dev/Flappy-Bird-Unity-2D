using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instace {  get; private set; }

    private int score;

    public int Score { get =>  score; set => score = value; }

    private void Awake()
    {
        if (Instace != this && Instace != null) Destroy(gameObject);
        else Instace = this;

        LoadGame();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("score", score);
    }

    void LoadGame()
    {
        score = PlayerPrefs.GetInt("score");
    }

    public void CheckMaxScore(int score_)
    {
        if (score_ > score)
        {
            score = score_;
        }
    }
}
