using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private DialogueRunner dialogueRunner;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // 会話中は動かない
        if (dialogueRunner != null && dialogueRunner.IsDialogueRunning)
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("IsMoving", false);
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

        // アニメーションパラメーターを更新
        if (input != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);
            animator.SetFloat("MoveX", input.x);
            animator.SetFloat("MoveY", input.y);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}