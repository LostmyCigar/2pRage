using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Leo;
using System.Threading.Tasks;

public class Player : NetworkBehaviour
{
    private void Start()
    {
        transform.position = FindFirstObjectByType<SpawnPoint>().transform.position;
        
        var color = LobbyInfo.Instance.GetPlayerColor(LobbyInfo.Instance.CurrentConnectedPlayers);
        GetComponentInChildren<SpriteRenderer>().color = color;

        var name = $"Player {LobbyInfo.Instance.CurrentConnectedPlayers}";
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = name;
    }
}
