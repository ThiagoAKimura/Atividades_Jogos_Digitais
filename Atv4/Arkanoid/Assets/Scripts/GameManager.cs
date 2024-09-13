using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] blocks; // Referência para os blocos na cena
    void Start()
    {
        // Encontre todos os blocos na cena
       
    }

    void Update()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
        Debug.Log(blocks.Length);
        
        // Verifique se todos os blocos foram destruídos
        if (blocks.Length == 0)
        {
            // Carregue a próxima cena
            SceneManager.LoadScene("Nivel2");
            Debug.Log("Mudando de tela");
        }
    }

    // Método para atualizar a lista de blocos quando um bloco é destruído
    public void UpdateBlockList()
    {
        blocks = GameObject.FindGameObjectsWithTag("Block");
    }
}
