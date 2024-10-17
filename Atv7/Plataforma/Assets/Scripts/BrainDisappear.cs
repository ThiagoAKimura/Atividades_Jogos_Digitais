using UnityEngine;

public class BrainDisappear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Incrementa o contador de cérebros no singleton BrainCounter
            BrainCounter.instance.AddBrain();

            // Faz o objeto desaparecer
            gameObject.SetActive(false);
        }
    }
}
