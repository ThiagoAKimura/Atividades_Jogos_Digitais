using UnityEngine;

public class AIController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade base do movimento da IA
    public float movementDeviation = 0.5f; // Desvio máximo do movimento
    public string ballName1 = "Ball"; // Nome da primeira bola na hierarquia
    public string ballName2 = "Ball_2"; // Nome da segunda bola na hierarquia
    public float yMinLimit = -4.5f; // Limite inferior para a posição Y da raquete
    public float yMaxLimit = 4.5f; // Limite superior para a posição Y da raquete

    private Rigidbody2D rb2d;
    private Transform ball1;
    private Transform ball2;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ball1 = GameObject.Find(ballName1).transform; // Encontra a primeira bola pelo nome
        ball2 = GameObject.Find(ballName2).transform; // Encontra a segunda bola pelo nome
    }

    void FixedUpdate()
    {
        if (ball1 != null && ball2 != null)
        {
            // Determine qual bola está mais próxima
            Transform closestBall = GetClosestBall(ball1, ball2);

            // Calcule a direção vertical para a bola mais próxima
            float directionY = closestBall.position.y - transform.position.y;

            // Adicione um desvio aleatório para simular um comportamento mais humano
            float deviation = Random.Range(-movementDeviation, movementDeviation);

            // Ajuste a velocidade com base na direção e no desvio
            float velocityY = directionY * moveSpeed + deviation;

            // Define a velocidade do Rigidbody2D
            rb2d.velocity = new Vector2(0, Mathf.Clamp(velocityY, -moveSpeed, moveSpeed));
        }

        // Limite o movimento da raquete dentro dos limites da tela
        Vector2 position = rb2d.position;
        position.y = Mathf.Clamp(position.y, yMinLimit, yMaxLimit);
        rb2d.position = position;
    }

    Transform GetClosestBall(Transform ball1, Transform ball2)
    {
        // Calcula a distância até cada bola
        float distanceToBall1 = Mathf.Abs(ball1.position.y - transform.position.y);
        float distanceToBall2 = Mathf.Abs(ball2.position.y - transform.position.y);

        // Retorna a bola mais próxima
        return distanceToBall1 < distanceToBall2 ? ball1 : ball2;
    }
}
