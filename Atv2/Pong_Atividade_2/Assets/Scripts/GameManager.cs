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

    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
        }
        else
        {
            PlayerScore2++;
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

        // Exibe a pontuação
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

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
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 400, 100),(PlayerScore1 == 10 ? "Jogador Um ganhou!" : "Computador ganhou!"));
        }

        // Botão de reinício sempre visível
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            // Reiniciar o jogo
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            gameEnded = false;
            Time.timeScale = 1; // Reinicia o jogo
            theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Atualiza a lógica do jogo, se necessário
    }
}
