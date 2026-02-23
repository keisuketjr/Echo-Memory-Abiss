using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 感情値
    public int fragBond = 0;

    private GameObject player;

    void Awake()
    {
        // シングルトン設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.Find("Echo");

        // 新規スタートの場合はロードしない
        if (PlayerPrefs.GetInt("IsNewGame", 1) == 1)
        {
            PlayerPrefs.SetInt("IsNewGame", 0);
            return;
        }

        // セーブデータがあればロードする
        if (SaveManager.Instance != null && SaveManager.Instance.HasSaveData())
        {
            SaveData data = SaveManager.Instance.Load();
            if (data != null)
            {
                fragBond = data.fragBond;

                if (data.currentScene == SceneManager.GetActiveScene().name)
                {
                    player.transform.position = new Vector3(data.playerX, data.playerY, 0f);
                }
            }
        }
    }

    void Update()
    {
        // 将来的にセーブキーを設定予定
    }

    // セーブを実行する
    public void SaveGame()
    {
        if (SaveManager.Instance != null && player != null)
        {
            SaveManager.Instance.Save(player, fragBond);
        }
    }

    // Yarnスクリプトから呼び出せるセーブコマンド
    [YarnCommand("save")]
    public static void YarnSave()
    {
        if (Instance != null)
        {
            Instance.SaveGame();
            Debug.Log("Yarnからセーブしました");
        }
    }
}