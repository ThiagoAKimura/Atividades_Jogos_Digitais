using UnityEngine;

public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Ball"))
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("ResetarDisco", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}




