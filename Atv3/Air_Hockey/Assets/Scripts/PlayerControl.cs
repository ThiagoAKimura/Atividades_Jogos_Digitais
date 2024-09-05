using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Calcula os limites da câmera
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        // Define os limites para o movimento do jogador
        minX = -screenBounds.x; // limite esquerdo
        maxX = screenBounds.x;  // limite direito
        minY = -screenBounds.y; // limite inferior
        maxY = 0;               // metade da tela verticalmente (limite superior)
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        
        // Limita o movimento do jogador
        pos.x = Mathf.Clamp(mousePos.x, minX, maxX); // Limite horizontal para não sair dos lados
        pos.y = Mathf.Clamp(mousePos.y, minY, maxY); // Limite vertical para não passar do meio

        transform.position = pos;
    }

    
}
