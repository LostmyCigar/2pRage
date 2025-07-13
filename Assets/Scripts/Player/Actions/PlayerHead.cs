using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.GetComponent<PlayerFoot>())
            Debug.Log("Ouch");

    }
}
