using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      // Referência ao jogador
    public float cameraSpeed = 2f; // Velocidade de movimentação da câmera
    public float offsetX = 2f;    // Distância que o jogador pode andar até a borda antes da câmera se mover
    public float minX = 0f;       // Limite mínimo da câmera no eixo X

    private float startX;         // Ponto inicial da câmera no eixo X

    void Start()
    {
        // Salva a posição inicial da câmera no eixo X
        startX = transform.position.x;
    }

    void Update()
    {
        // Verifica a posição do jogador em relação à câmera
        float playerPosX = player.position.x;
        float cameraPosX = transform.position.x;

        // Se o jogador passar da borda direita (definida por "offsetX"), a câmera se move para a direita
        if (playerPosX > cameraPosX + offsetX)
        {
            // Move a câmera suavemente para a direita
            transform.position = new Vector3(Mathf.Lerp(cameraPosX, playerPosX - offsetX, Time.deltaTime * cameraSpeed), transform.position.y, transform.position.z);
        }
        // Se o jogador passar da borda esquerda (definida por "offsetX"), a câmera se move para a esquerda
        else if (playerPosX < cameraPosX - offsetX)
        {
            // Move a câmera suavemente para a esquerda
            float newCameraPosX = Mathf.Lerp(cameraPosX, playerPosX + offsetX, Time.deltaTime * cameraSpeed);

            // Limita a posição da câmera ao mínimo (minX)
            newCameraPosX = Mathf.Max(newCameraPosX, minX);

            // Aplica a nova posição à câmera
            transform.position = new Vector3(newCameraPosX, transform.position.y, transform.position.z);
        }
    }
}
