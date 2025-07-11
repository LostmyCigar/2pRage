
using Unity.Netcode;
using Unity.Collections;
using UnityEngine;
using Leo;
using System;

public class Player : NetworkBehaviour
{   
    public NetworkVariable<FixedString32Bytes> playerName;
    public NetworkVariable<Color> playerColor = new NetworkVariable<Color>(
        default,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server);


    public string GetName()
    {
        playerName.Value = $"Player {LobbyInfo.Instance.CurrentConnectedPlayers}";
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playerName.Value.ToString();
        return playerName.Value.ToString();
    }

    public Color GetColor()
    {
        playerColor.Value = LobbyInfo.Instance.GetPlayerColor(LobbyInfo.Instance.CurrentConnectedPlayers);
        GetComponentInChildren<SpriteRenderer>().color = playerColor.Value;
        return playerColor.Value;
    }

    public override void OnNetworkSpawn()
    {
        GetName();
        GetColor();
    }

    void Start()
    {
        transform.position = FindFirstObjectByType<SpawnPoint>().transform.position;
    }

}
