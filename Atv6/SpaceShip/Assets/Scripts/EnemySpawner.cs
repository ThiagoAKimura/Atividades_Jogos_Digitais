using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab do inimigo
    public float spawnInterval = 2f;  // Intervalo entre os spawns
    public float minY = -5.186543f;  // Limite inferior da posição de spawn
    public float maxY = 5.186543f;  // Limite superior da posição de spawn
    private float spawnX;  // Posição X de spawn
    public float enemySpeed = 2f;  // Velocidade do inimigo

    void Start()
    {
        // Calcula a posição de spawn com base na largura da tela
        float cameraHeight = 2f * 5.186543f;
        float cameraWidth = cameraHeight * (16f / 9f); // Supondo uma proporção 16:9
        spawnX = cameraWidth / 2 + 1f;  // Um pouco além da borda direita da tela

        // Inicia o spawn dos inimigos repetidamente
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Gera uma posição aleatória dentro dos limites de Y
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0f);

        // Instancia o inimigo com uma rotação de 90 graus anti-horário
        Quaternion rotation = Quaternion.Euler(0f, 0f, -90f);  // Rotação de 90 graus
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, rotation);

        // Adiciona movimento ao inimigo
        newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemySpeed, 0f);  // Movimento da direita para a esquerda
    }
}
