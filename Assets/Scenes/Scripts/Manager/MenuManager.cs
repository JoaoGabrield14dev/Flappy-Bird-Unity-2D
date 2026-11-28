using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textHightScore;

    void Start()
    {
        textHightScore.text = SaveManager.Instace.Score.ToString();
    }

    public void ButtonDeleteData()
    {
        SaveManager.Instace.Score = 0;
        SaveManager.Instace.SaveGame();

        textHightScore.text = SaveManager.Instace.Score.ToString();
    }

    public void ButtonPlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonExitGame()
    {
        Application.Quit();
    }
}
