using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class LearningLog : MonoBehaviour
{
    [SerializeField] private GameObject learningLogPanel;
    [SerializeField] private TextMeshProUGUI logContent;

    void Start()
    {
        // 最初は非表示
        learningLogPanel.SetActive(false);
    }

    void Update()
    {
        // Tabキーで開閉
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            bool isOpen = learningLogPanel.activeSelf;
            learningLogPanel.SetActive(!isOpen);

            // 開いた時にログを更新
            if (!isOpen)
            {
                UpdateLog();
            }
        }
    }

    // ログの内容を更新する
    public void UpdateLog()
    {
        if (GameManager.Instance == null) return;

        int fragBond = GameManager.Instance.fragBond;

        string anomaly = "該当なし";
        if (fragBond >= 3)
            anomaly = "警告：結合値が上限に近づいています";
        else if (fragBond <= -3)
            anomaly = "警告：結合値が下限に近づいています";

        logContent.text =
            "＞ 感情値ログ\n" +
            "──────────────\n" +
            $"フラグ結合値：{fragBond}\n" +
            "共鳴指数：未定義\n" +
            "──────────────\n" +
            "＞ 異常検知\n" +
            anomaly + "\n" +
            "──────────────\n" +
            "＞ 備考\n" +
            "記録なし";
    }

    // 閉じるボタン
    public void OnCloseButtonPressed()
    {
        learningLogPanel.SetActive(false);
    }
}