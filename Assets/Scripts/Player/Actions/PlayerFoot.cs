using UnityEngine;

public class PlayerFoot : MonoBehaviour
{
    private GameObject thisPlayer;
    private PlayerStomp stompCheck;
    private void Awake()
    {
        stompCheck = GetComponentInParent<PlayerStomp>();
        thisPlayer = transform.root.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHead>())
            stompCheck.StompOtherPlayer(collision.transform.root.gameObject);
    }
}
