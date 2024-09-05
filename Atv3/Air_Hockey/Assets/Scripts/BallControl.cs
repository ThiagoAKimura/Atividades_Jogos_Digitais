using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool discoLancado = false; // Verifica se o disco já foi lançado

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetarDisco(); // Garante que o disco comece parado e no centro
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!discoLancado && coll.collider.name == "Palheta1") // Verifica se colidiu com o jogador
        {
            LançarDisco(); // Lança o disco
        }
    }

    void LançarDisco()
    {
        // Define uma direção aleatória inicial para o disco
        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);

        // Aplica uma força inicial para lançar o disco
        rb2d.AddForce(new Vector2(randX, randY).normalized * 500f); // Ajuste a força conforme necessário
        discoLancado = true; // Marca que o disco foi lançado
    }

    public void ResetarDisco()
    {
        rb2d.velocity = Vector2.zero; // Para o movimento
        transform.position = Vector2.zero; // Reposiciona o disco no centro
        discoLancado = false; // Reseta o estado de lançamento
    }

    
}
