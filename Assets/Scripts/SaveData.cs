using System;

[Serializable]
public class SaveData
{
    // プレイヤーの位置
    public float playerX;
    public float playerY;

    // 感情値（フラグとの関係値）
    public int fragBond;

    // 現在のシーン名
    public string currentScene;
}