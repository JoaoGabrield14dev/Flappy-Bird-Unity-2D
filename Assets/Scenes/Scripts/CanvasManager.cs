using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    [SerializeField] private TMP_Text textScore;
    [SerializeField] private GameObject painelDeath;

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

    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        textScore.text = score.ToString();
    }
}
