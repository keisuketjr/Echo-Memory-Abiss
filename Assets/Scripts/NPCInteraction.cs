using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;
using TMPro;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private string conversationStartNode = "Start";
    [SerializeField] private float interactionDistance = 1.5f;
    [SerializeField] private TextMeshProUGUI interactionHintText;

    private Transform player;

    void Start()
    {
        player = GameObject.Find("Echo").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < interactionDistance)
        {
            // 近づいたらヒントを表示
            if (interactionHintText != null)
                interactionHintText.gameObject.SetActive(true);

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
            if (interactionHintText != null)
                interactionHintText.gameObject.SetActive(false);
        }
    }
}