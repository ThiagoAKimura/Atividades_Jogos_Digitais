using UnityEngine;
using UnityEngine.UI; // Necessário para manipular elementos UI

public class LifeManager : MonoBehaviour
{
    public int totalLives = 3; // Número total de vidas do jogador
    public GameObject[] hearts; // Array de imagens/corações na UI
    public GameObject gameOverPanel; // Referência ao painel de Game Over

    private int currentLives;

    void Start()
    {
        currentLives = totalLives; // Inicializa as vidas com o valor total
        UpdateHearts();
        gameOverPanel.SetActive(false); // Certifica-se de que a tela de Game Over está oculta no início
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--; // Diminui uma vida
            UpdateHearts(); // Atualiza a UI
        }

        if (currentLives <= 0)
        {
            GameOver(); // Chama o método para quando o jogador perde todas as vidas
        }
    }

    void UpdateHearts()
    {
        // Atualiza a UI dos corações com base nas vidas restantes
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].SetActive(true); // Mostra o coração
            }
            else
            {
                hearts[i].SetActive(false); // Esconde o coração
            }
        }
    }

    void GameOver()
    {
        // Exibe a tela de Game Over
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Pausa o jogo (opcional)
        Debug.Log("Game Over!");
    }
}
