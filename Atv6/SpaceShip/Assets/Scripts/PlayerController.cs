using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Necessário para carregar cenas

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject meuTiro;
    [SerializeField] float velocidade = 5f;
    private Rigidbody2D meuRB;
    private float minX, maxX, minY, maxY;  // Limites da tela
    private float normalTimeScale = 1f;  // Escala de tempo normal
    private float slowTimeScale = 0.5f;  // Escala de tempo lenta

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        // Calculando os limites da tela com base no tamanho da câmera
        Camera cam = Camera.main;
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // Definindo os limites com base nas dimensões da câmera
        minX = -camWidth + transform.localScale.x / 2;  // Adicionando metade da largura do jogador
        maxX = camWidth - transform.localScale.x / 2;
        minY = -camHeight + transform.localScale.y / 2;
        maxY = camHeight - transform.localScale.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Pegando o input horizontal
        var horizontal = Input.GetAxis("Horizontal");
        // Pegando o input vertical
        var vertical = Input.GetAxis("Vertical");
        // Criando Vector2 para definir a velocidade do personagem
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);
        // Normalizando a velocidade
        minhaVelocidade.Normalize();
        // Passando a minha velocidade para meuRB
        meuRB.velocity = minhaVelocidade * velocidade;

        // Limitando a posição do jogador dentro da tela
        Vector3 novaPosicao = transform.position;
        novaPosicao.x = Mathf.Clamp(novaPosicao.x, minX, maxX);  // Limitando a posição X
        novaPosicao.y = Mathf.Clamp(novaPosicao.y, minY, maxY);  // Limitando a posição Y
        transform.position = novaPosicao;

        // Atira com o botão 1 do mouse ou espaço
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(meuTiro, transform.position, transform.rotation);
        }

        // Acelera ou desacelera o tempo com Fire2
        if (Input.GetButton("Fire2"))
        {
            Time.timeScale = slowTimeScale;  // Desacelera o tempo
        }
        else
        {
            Time.timeScale = normalTimeScale;  // Retorna ao tempo normal
        }
    }

    // Função que detecta colisão com o inimigo
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))  // Verifica se colidiu com um inimigo
        {
            // Carrega a cena de Game Over
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
