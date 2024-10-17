using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    public int requiredBrains = 5; // Defina quantos cérebros são necessários para avançar para a próxima fase
    public string nextLevelName; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o jogador encostou no objeto
        if (collision.CompareTag("Player"))
        {
            // Verifica se o jogador coletou cérebros suficientes
            if (BrainCounter.instance.brainCount >= requiredBrains)
            {
                // Carrega a próxima cena
                SceneManager.LoadScene(nextLevelName); 
            }
            else
            {
                // Pode adicionar uma mensagem para o jogador que ele precisa coletar mais cérebros
                Debug.Log("Você precisa coletar mais cérebros!");
            }
        }
    }
}
