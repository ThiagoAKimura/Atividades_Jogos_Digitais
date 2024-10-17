using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform leftLimit, rightLimit;
    private bool movingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (transform.position.x >= rightLimit.position.x)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (transform.position.x <= leftLimit.position.x)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // O jogador perde ao encostar no corpo
            Debug.Log("Game Over: Colidiu com o corpo do inimigo");
            SceneManager.LoadScene("GameOverScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            // Certifique-se de que esta lógica esteja correta
            Debug.Log("PlayerFeet colidiu com a cabeça do inimigo");
            Destroy(gameObject); // Destrói o inimigo
        }
    }
}
