using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHead>())
            Debug.Log("Stomp");
    }
}
