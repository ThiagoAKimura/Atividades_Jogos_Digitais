using UnityEngine;

public class BrainMovement : MonoBehaviour
{
    public float amplitude = 0.5f;  // A altura do movimento
    public float speed = 2f;        // A velocidade do movimento

    private Vector3 startPos;       // A posição inicial do osso

    void Start()
    {
        // Salva a posição inicial do osso
        startPos = transform.position;
    }

    void Update()
    {
        // Calcula a nova posição usando Mathf.Sin para criar um movimento suave
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * amplitude;

        // Aplica a nova posição
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
