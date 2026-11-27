using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instace {  get; private set; }

    private int score;
    private int deaths;

    public int Score { get =>  score; set => score = value; }
    public int Deaths { get => deaths; set => deaths = value; }

    private void Awake()
    {
        if (Instace != this && Instace != null) Destroy(gameObject);
        else Instace = this;

        LoadGame();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("deaths", deaths);
    }

    void LoadGame()
    {
        score = PlayerPrefs.GetInt("score");
        deaths = PlayerPrefs.GetInt("deaths");
    }
}
