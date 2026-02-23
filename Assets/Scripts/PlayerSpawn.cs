using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        // 保存されたスポーン位置を取得
        float spawnX = PlayerPrefs.GetFloat("SpawnX", 0f);
        float spawnY = PlayerPrefs.GetFloat("SpawnY", 0f);

        // Echoの位置を設定
        transform.position = new Vector3(spawnX, spawnY, 0f);
    }
}