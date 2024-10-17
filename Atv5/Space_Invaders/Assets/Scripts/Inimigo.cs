using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private int state = 0;
    private float x;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
        x = transform.position.x;
    }

    void Update()
    {
        // Atualiza o temporizador
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }

        // Movimentação do inimigo
        var pos = transform.position;
        if (state >= -5 && state < 0)
        {
            pos.x = x - state;
        }
        else if (state == 0)
        {
            pos.y -= 0.5f;
            ChangeState();
            pos.x = x;
        }
        else if (state > 0 && state <= 5)
        {
            pos.x = x + state;
        }
        transform.position = pos;
    }

    void ChangeState()
    {
        state = state + 1;
        if (state > 5)
        {
            state = -5;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com o tiro do jogador
        if (collision.gameObject.CompareTag("Tiro"))
        {
            // Destroi o inimigo
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // Adiciona 10 pontos à pontuação total
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(10); // Adiciona 10 pontos
            }
        }

        // Verifica colisão com a parede inferior
        if (collision.gameObject.tag == "BottomWall")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // Carrega a cena de Game Over
        SceneManager.LoadScene("GameOver");
    }
}
