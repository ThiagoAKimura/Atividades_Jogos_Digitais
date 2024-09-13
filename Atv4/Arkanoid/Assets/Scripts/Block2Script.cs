using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2Script : MonoBehaviour
{
    private SpriteRenderer alteraCor;
    public int vida = 2;
    // Start is called before the first frame update
    void Start()
    {
        alteraCor = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com a bola
        if (collision.gameObject.CompareTag("Ball"))
        {
            vida -= 1;
            if (vida == 1){
                alteraCor.color = Color.green;
            }
            else if (vida == 0){
                // Destroi o bloco
                Destroy(gameObject);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
