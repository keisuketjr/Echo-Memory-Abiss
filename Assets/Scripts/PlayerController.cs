using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private DialogueRunner dialogueRunner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    void FixedUpdate()
    {
        // 会話中は動かない
        if (dialogueRunner != null && dialogueRunner.IsDialogueRunning)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            input.y += 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            input.y -= 1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            input.x -= 1f;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            input.x += 1f;

        rb.linearVelocity = input.normalized * moveSpeed;
    }
}