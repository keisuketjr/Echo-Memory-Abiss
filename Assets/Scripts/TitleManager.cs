using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private string gameStartScene = "Scene1";
    [SerializeField] private GameObject continueButton;

    void Start()
    {
        // セーブデータがあればコンティニューボタンを表示
        if (SaveManager.Instance != null)
        {
            continueButton.SetActive(SaveManager.Instance.HasSaveData());
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    // スタートボタンを押した時
    public void OnStartButtonPressed()
    {
        // 新規スタートフラグを設定
        PlayerPrefs.SetInt("IsNewGame", 1);
        PlayerPrefs.Save();

        if (FadeManager.Instance != null)
        {
            FadeManager.Instance.FadeToScene(gameStartScene);
        }
        else
        {
            SceneManager.LoadScene(gameStartScene);
        }
    }

    // コンティニューボタンを押した時
    public void OnContinueButtonPressed()
    {
        if (SaveManager.Instance != null && SaveManager.Instance.HasSaveData())
        {
            // コンティニューフラグを設定
            PlayerPrefs.SetInt("IsNewGame", 0);
            PlayerPrefs.Save();

            SaveData data = SaveManager.Instance.Load();
            if (FadeManager.Instance != null)
            {
                FadeManager.Instance.FadeToScene(data.currentScene);
            }
            else
            {
                SceneManager.LoadScene(data.currentScene);
            }
        }
    }
}