using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o inimigo colidiu com o tiro
        if (collision.gameObject.CompareTag("Tiro"))
        {
            // Adiciona 10 pontos ao jogador
            ScoreManager.instance.AddPoints(10);

            // Destroi o inimigo
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Destruidor"))
        {
            // Destroi o inimigo
            Destroy(gameObject);
        }
    }
}
