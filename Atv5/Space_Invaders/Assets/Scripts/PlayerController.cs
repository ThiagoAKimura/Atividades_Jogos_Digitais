using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject meuTiro;
    [SerializeField] float velocidade = 5f;
    private Rigidbody2D meuRB;
    private float screenMinX;
    private float screenMaxX;

    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        // Calcula as bordas da tela
        Vector3 screenBoundsMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 screenBoundsMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));

        screenMinX = screenBoundsMin.x;
        screenMaxX = screenBoundsMax.x;
    }

    void Update()
    {
        // Pegando o input horizontal
        var horizontal = Input.GetAxis("Horizontal");
        Vector2 minhaVelocidade = new Vector2(horizontal, 0);
        minhaVelocidade.Normalize();
        meuRB.velocity = minhaVelocidade * velocidade;

        // Limita a posição do jogador à tela
        float clampedX = Mathf.Clamp(transform.position.x, screenMinX, screenMaxX);
        transform.position = new Vector2(clampedX, transform.position.y);

        // Atira com o botão do mouse ou espaço
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(meuTiro, transform.position, transform.rotation);
        }
    }
}
