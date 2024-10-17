using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Inimigo; // Referência para os blocos na cena
    void Start()
    {
       
    }

    void Update()
    {
        Inimigo = GameObject.FindGameObjectsWithTag("Inimigo");
        Debug.Log(Inimigo.Length);
        
        // Verifique se todos os blocos foram destruídos
        if (Inimigo.Length == 0)
        {
            // Carregue a próxima cena
            SceneManager.LoadScene("GameOver");
            Debug.Log("Mudando de tela");
        }
    }

    // Método para atualizar a lista de blocos quando um bloco é destruído
    public void UpdateBlockList()
    {
        Inimigo = GameObject.FindGameObjectsWithTag("Inimigo");
    }
}
