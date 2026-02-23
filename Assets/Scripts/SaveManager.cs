using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string savePath;

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

        savePath = Application.persistentDataPath + "/savedata.json";
    }

    // セーブする
    public void Save(GameObject player, int fragBond)
    {
        SaveData data = new SaveData();
        data.playerX = player.transform.position.x;
        data.playerY = player.transform.position.y;
        data.fragBond = fragBond;
        data.currentScene = SceneManager.GetActiveScene().name;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);

        Debug.Log("セーブしました：" + savePath);
    }

    // ロードする
    public SaveData Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("ロードしました");
            return data;
        }
        else
        {
            Debug.Log("セーブデータがありません");
            return null;
        }
    }

    // セーブデータが存在するか確認
    public bool HasSaveData()
    {
        return File.Exists(savePath);
    }
}