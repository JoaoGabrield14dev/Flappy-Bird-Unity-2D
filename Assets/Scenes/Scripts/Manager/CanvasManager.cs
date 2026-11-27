using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    [SerializeField] private TMP_Text textScore;

    [Header("Game Over Painel")]
    [SerializeField] private GameObject painelDeath;
    [SerializeField] private TMP_Text textScoreObtained;
    [SerializeField] private TMP_Text textHightScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateScore(int score)
    {
        textScore.text = score.ToString();
    }

    public void ShowPainelDeath(int score_obtained)
    {
        StartCoroutine(PainelDeathSystem(score_obtained));
    }

    IEnumerator PainelDeathSystem(int score_obtained)
    {
        yield return new WaitForSeconds(2);

        painelDeath.SetActive(true);

        textScore.gameObject.SetActive(false);

        textScoreObtained.text = score_obtained.ToString();
        textHightScore.text = SaveManager.Instace.Score.ToString();
    }


    // ========= BUTTONS =========

    public void ButtonPlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene(0);
    }
}
