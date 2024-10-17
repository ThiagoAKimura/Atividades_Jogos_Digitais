using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float parallaxEffectMultiplier; // Multiplicador para o efeito de parallax
    private float initialPositionX; // Posição inicial da camada
    private float spriteWidth; // Largura do sprite da camada

    void Start()
    {
        // Armazena a posição inicial da camada
        initialPositionX = transform.position.x;

        // Calcula a largura do sprite (supondo que tenha um SpriteRenderer)
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    void Update()
    {
        // Calcula a nova posição da camada com o efeito de parallax
        float playerPositionX = player.position.x;
        float targetPositionX = initialPositionX + (playerPositionX * parallaxEffectMultiplier);

        // Atualiza a posição da camada suavemente
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetPositionX, Time.deltaTime * 5), // Ajuste a suavização aqui
            transform.position.y,
            transform.position.z
        );

        // Se a camada sair da tela, reposicione-a (opcional)
        if (playerPositionX > initialPositionX + spriteWidth)
        {
            initialPositionX += spriteWidth; // reposiciona para criar um efeito contínuo
        }
        else if (playerPositionX < initialPositionX - spriteWidth)
        {
            initialPositionX -= spriteWidth; // reposiciona para criar um efeito contínuo
        }
    }
}
