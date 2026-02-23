using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string targetScene;
    [SerializeField] private Vector2 playerSpawnPosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Echoが触れたら遷移する
        if (other.gameObject.name == "Echo")
        {
            // スポーン位置を保存
            PlayerPrefs.SetFloat("SpawnX", playerSpawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", playerSpawnPosition.y);
            PlayerPrefs.Save();

            // Sceneを読み込む
            SceneManager.LoadScene(targetScene);
        }
    }
}