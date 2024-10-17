using UnityEngine;
using UnityEngine.SceneManagement;

public class BrainCounter : MonoBehaviour
{
    public static BrainCounter instance;  // Singleton para acesso global
    public int brainCount = 0;            // Contador de cérebros

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Impede a destruição ao carregar uma nova cena
        }
        else
        {
            Destroy(gameObject);  // Garante que só haja um contador ativo
        }
    }

    private void OnEnable()
    {
        // Adiciona o evento quando uma nova cena for carregada
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Remove o evento quando o objeto for destruído
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Método chamado quando uma cena é carregada
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica se a cena carregada é "SampleScene"
        if (scene.name == "SampleScene")
        {
            // Reseta a contagem de cérebros
            brainCount = 0;
        }
    }

    // Função para adicionar cérebros
    public void AddBrain()
    {
        brainCount++;
    }
}
