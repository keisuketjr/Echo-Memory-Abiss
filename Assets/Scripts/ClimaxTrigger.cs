using UnityEngine;
using Yarn.Unity;

public class ClimaxTrigger : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private string climaxNode = "Climax_Start";
    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;
        if (other.gameObject.name != "Echo") return;
        if (dialogueRunner.IsDialogueRunning) return;

        hasTriggered = true;
        dialogueRunner.StartDialogue(climaxNode);
    }
}