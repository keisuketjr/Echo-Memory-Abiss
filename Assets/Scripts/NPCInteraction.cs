using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private string conversationStartNode = "Start";
    [SerializeField] private float interactionDistance = 1.5f;
    [SerializeField] private GameObject interactionHint;

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Echo").transform;

        // ヒントを最初は非表示にする
        if (interactionHint != null)
        {
            interactionHint.SetActive(false);
            Debug.Log("ヒントを非表示にしました");
        }
        else
        {
            Debug.Log("interactionHintがnullです");
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < interactionDistance)
        {
            // 近づいたらヒントを表示
            if (interactionHint != null)
                interactionHint.SetActive(true);

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                if (!dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.StartDialogue(conversationStartNode);
                }
            }
        }
        else
        {
            // 離れたらヒントを非表示
            if (interactionHint != null)
                interactionHint.SetActive(false);
        }
    }
}