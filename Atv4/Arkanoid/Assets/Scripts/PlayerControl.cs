using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10.0f; // Velocidade de movimento do jogador
    private float halfWidth;

    void Start()
    {
        // Calcula a metade da largura do jogador com base em seu tamanho
        halfWidth = transform.localScale.x / 2.0f;
    }

    void Update()
    {
        // Recebe o input horizontal (A/D ou setas)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcula a nova posição
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

        // Converte a posição do jogador para coordenadas de tela
        float screenLimitLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + halfWidth;
        float screenLimitRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - halfWidth;

        // Limita a posição do jogador dentro da tela
        newPosition.x = Mathf.Clamp(newPosition.x, screenLimitLeft, screenLimitRight);

        // Aplica a nova posição ao jogador
        transform.position = newPosition;
    }
}
