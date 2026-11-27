using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instace {  get; private set; }

    private void Awake()
    {
        if (Instace != this && Instace != null) Destroy(gameObject);
        else Instace = this;
    }

    void Start()
    {
        
    }

    void SaveGame()
    {

    }

    public void LoadGame()
    {

    }
}
