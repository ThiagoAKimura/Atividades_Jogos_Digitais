using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;  // Referência ao Animator
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;  // Congela a rotação
        animator = GetComponent<Animator>();  // Obtém o componente Animator
    }

    void Update()
{
    // Movimento horizontal
    float moveInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

    // Atualiza o parâmetro "Speed" no Animator
    animator.SetFloat("Speed", Mathf.Abs(moveInput));  // Passa o valor absoluto de moveInput

    // Verificação de solo para pular
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

    // Pular
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // Espelhar o sprite do jogador mantendo a escala original
    if (moveInput < 0)
    {
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    else if (moveInput > 0)
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    
}
}
