using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private string gameStartScene = "Scene1";

    // スタートボタンを押した時
    public void OnStartButtonPressed()
    {
        if (FadeManager.Instance != null)
        {
            FadeManager.Instance.FadeToScene(gameStartScene);
        }
        else
        {
            SceneManager.LoadScene(gameStartScene);
        }
    }
}