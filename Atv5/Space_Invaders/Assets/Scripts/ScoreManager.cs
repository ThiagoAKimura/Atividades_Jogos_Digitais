using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    private Text scoreText;

    void Awake()
    {
        // Garante que apenas uma instância de ScoreManager exista
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Tenta encontrar o objeto ScoreText na cena
        GameObject scoreTextObject = GameObject.Find("ScoreText");
        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<Text>();
            UpdateScoreUI(); // Atualiza a UI com o valor inicial
        }
        else
        {
            Debug.LogError("ScoreText não encontrado na cena! Verifique se o objeto existe e está nomeado corretamente.");
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("scoreText é nulo! Verifique se está vinculado corretamente.");
        }
    }
}
