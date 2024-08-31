using UnityEngine;

public class BallControl2 : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private AudioSource audioSource;
    public float initialSpeed = 20f;
    public float increasedSpeed = 30f; // Velocidade aumentada quando o jogador atinge 5 pontos

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        Vector2 direction;
        if (rand < 1)
        {
            direction = new Vector2(1, -1);
        }
        else
        {
            direction = new Vector2(-1, -1);
        }

        rb2d.AddForce(direction * (GameManager.PlayerScore1 >= 5 || GameManager.PlayerScore2 >= 5 ? increasedSpeed : initialSpeed));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {

            audioSource.Play();

            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Invoke("GoBall", 2);
    }
}
