using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private string conversationStartNode = "Start";
    [SerializeField] private float interactionDistance = 1.5f;

    private Transform player;

    void Start()
    {
        // Echoオブジェクトを探す
        player = GameObject.Find("Echo").transform;
    }

    void Update()
    {
        // EchoとNPCの距離を計算
        float distance = Vector3.Distance(transform.position, player.position);

        // 距離が近くてスペースキーを押したら会話開始
        if (distance < interactionDistance)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                if (!dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.StartDialogue(conversationStartNode);
                }
            }
        }
    }
}