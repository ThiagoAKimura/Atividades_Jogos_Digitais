using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com a bola
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroi o bloco
            Destroy(gameObject);
        }
    }
}
