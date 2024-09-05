using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    public Transform bola; // Referência para o transform da bola (disco)
    public float velocidade = 5f; // Velocidade de movimento da IA
    private Rigidbody2D rb2d;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Calcula os limites da tela
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        // Define os limites para o movimento da IA na metade superior
        minX = -screenBounds.x;  // limite esquerdo
        maxX = screenBounds.x;   // limite direito
        minY = 0;                // limite inferior (meia tela superior)
        maxY = screenBounds.y;   // limite superior (parte superior da tela)

        // Define a posição inicial da palheta IA para a metade superior da tela
        transform.position = new Vector2(0, (maxY + minY) / 2); // Centraliza verticalmente na metade superior
    }

    void FixedUpdate()
    {
    if (bola != null)
    {
        Vector2 pos = transform.position;
        Vector2 bolaPos = bola.position;

        // Calcula a direção para a bola
        Vector2 direcao = (bolaPos - pos).normalized;

        // Move a palheta IA em direção à bola
        Vector2 novoPos = pos + direcao * velocidade * Time.fixedDeltaTime;

        // Limita a velocidade da palheta
        rb2d.velocity = (novoPos - pos) / Time.fixedDeltaTime;

        // Limita o movimento da palheta IA à metade superior da tela
        rb2d.position = new Vector2(Mathf.Clamp(novoPos.x, minX, maxX), Mathf.Clamp(novoPos.y, minY, maxY));
    }
    }
}
