using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{

    private Rigidbody2D meuRB;
    [SerializeField] private float vel = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //Usando RigidBody2D
        meuRB = GetComponent<Rigidbody2D>();

        
        meuRB.velocity = new Vector2(vel, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
