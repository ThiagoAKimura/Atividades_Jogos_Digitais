using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Necessário para carregar cenas

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Instância para acessar o ScoreManager de qualquer outro script
    public int score = 0;  // Pontuação inicial
    public Text scoreText; // Texto que exibe a pontuação

    private void Awake()
    {
        // Certifique-se de que só existe uma instância do ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();  // Atualiza o texto da pontuação na tela
    }

    // Função para adicionar pontos
    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();

        // Verifica se a pontuação atingiu 1000
        if (score >= 1000)
        {
            LoadVictoryScene();  // Carrega a cena de vitória
        }
    }

    // Atualiza o texto da pontuação na tela
    void UpdateScoreText()
    {
        scoreText.text = "Pontos: " + score;
    }

    // Função para carregar a cena de vitória
    void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene");  
    }
}
