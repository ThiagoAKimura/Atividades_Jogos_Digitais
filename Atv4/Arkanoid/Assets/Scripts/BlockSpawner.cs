using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab do bloco a ser gerado
    public int rows = 5; // Número de linhas de blocos
    public int columns = 10; // Número de colunas de blocos
    public float xSpacing = 1.1f; // Espaçamento horizontal entre os blocos
    public float ySpacing = 0.6f; // Espaçamento vertical entre os blocos
    public Vector2 startPosition = new Vector2(-8.5f, 4.0f); // Posição inicial para o primeiro bloco

    void Start()
    {
        GenerateBlocks();
    }

    void GenerateBlocks()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calcula a posição de cada bloco
                Vector2 spawnPosition = new Vector2(
                    startPosition.x + col * xSpacing, 
                    startPosition.y - row * ySpacing
                );

                // Instancia o bloco na posição calculada
                Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
