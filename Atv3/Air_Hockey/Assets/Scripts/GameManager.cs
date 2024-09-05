using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;

    public GUISkin layout;
    public GameObject theBall;

    private bool gameEnded = false; // Adicionado para verificar se o jogo acabou

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    public static void Score(string wallName)
    {
        if (wallName == "GameObject (2)")
        {
            PlayerScore1++;
            Debug.Log("PONTO");
        }
        else
        {
            PlayerScore2++;
            Debug.Log("PONTO");
        }
    }

    void EndGame(string winner)
    {
        gameEnded = true; // Define que o jogo acabou
        Time.timeScale = 0; // Pausa o jogo
        // Exibir mensagem de vitória aqui
        Debug.Log(winner + " ganhou!");
    }

    void OnGUI()
    {
        GUI.skin = layout;

        // Botão de reinício
        Rect restartButtonRect = new Rect(Screen.width / 2 - 60, 35, 120, 53);
        if (GUI.Button(restartButtonRect, "RESTART"))
        {
            // Reiniciar o jogo
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            gameEnded = false;
            Time.timeScale = 1; // Reinicia o jogo
            theBall.SendMessage("ResetarDisco", 0.5f, SendMessageOptions.RequireReceiver);
        }

        // Exibe a pontuação ao lado do botão de reinício
        float labelWidth = 100;
        float labelHeight = 100;
        float spaceBetween = 10; // Espaço entre o botão e as pontuações

        // Pontuação do jogador 1 (à esquerda do botão de reinício)
        GUI.Label(new Rect(restartButtonRect.x - restartButtonRect.width - spaceBetween, restartButtonRect.y + 10, labelWidth, labelHeight), "" + PlayerScore1);
        
        // Pontuação do jogador 2 (à direita do botão de reinício)
        GUI.Label(new Rect(restartButtonRect.x + restartButtonRect.width + spaceBetween, restartButtonRect.y + 10, labelWidth, labelHeight), "" + PlayerScore2);

        // Verifica se algum jogador ganhou e exibe a tela de vitória
        if (PlayerScore1 == 10)
        {
            EndGame("Jogador Um");
        }
        else if (PlayerScore2 == 10)
        {
            EndGame("Computador");
        }

        if (gameEnded)
        {
            // Tela de vitória
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 400, 100), (PlayerScore1 == 10 ? "VOCE ganhou!" : "ONDAS CEREBRAIS DO KINNECT ganhou!"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza a lógica do jogo, se necessário
    }
}
