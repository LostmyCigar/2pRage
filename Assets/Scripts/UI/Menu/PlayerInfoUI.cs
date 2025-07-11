using UnityEngine;
using System;
using Unity.Netcode;
using Leo;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text connectedPlayersText;


    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += UpdateConnectedPlayersText;
        NetworkManager.Singleton.OnClientDisconnectCallback += UpdateConnectedPlayersText;
    }


    private void UpdateConnectedPlayersText(ulong clientId)
    {
        var connectedPlayers = LobbyInfo.Instance.CurrentConnectedPlayers.ToString();
        var minPlayers = LobbyInfo.Instance.MinPlayers.ToString();

        var s = $"{connectedPlayers}/{minPlayers} Players Connected"; 
        connectedPlayersText.text = s;
    } 
}
