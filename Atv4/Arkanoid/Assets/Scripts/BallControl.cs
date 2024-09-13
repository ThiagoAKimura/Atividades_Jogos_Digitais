using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 10.0f; // Velocidade da bola
    private Rigidbody2D rb; // Componente de Rigidbody2D para controlar a física da bola

    private Vector3 respawnPosition = new Vector3(0, -1.99f, 0); // Posição de renascimento
    private LifeManager lifeManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeManager = FindObjectOfType<LifeManager>(); // Encontra o gerenciador de vidas na cena
        Invoke("LaunchBall",2);
    }

    void LaunchBall()
    {
        transform.position = respawnPosition;
        rb.velocity = new Vector2(Random.Range(-1f,1f),-1).normalized * speed;
    }

    void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BottomWall")
        {
            RespawnBall();
            lifeManager.LoseLife(); // Chama o método de perder vida no gerenciador de vidas
        }
        if (collision.collider.CompareTag("Player"))
        {
            // Modificar a direção da bola com base no movimento do jogador
            Vector2 paddleVelocity = collision.collider.attachedRigidbody.velocity;
            float paddleInfluence = paddleVelocity.x * 0.5f; // Ajusta o impacto do movimento do paddle na bola

            // Ajusta a velocidade da bola, mantendo a magnitude constante
            Vector2 newVelocity = new Vector2(rb.velocity.x + paddleInfluence, rb.velocity.y).normalized * speed;
            rb.velocity = newVelocity;
        }
    }

    void RespawnBall()
    {
        transform.position = respawnPosition;
        rb.velocity = new Vector2(0,0);
        Invoke("LaunchBall",2);
    }
}
