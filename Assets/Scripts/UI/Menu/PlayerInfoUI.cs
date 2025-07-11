using UnityEngine;
using System;
using Unity.Netcode;
using Leo;
using TMPro;
using UnityEditor.EditorTools;
using Unity.VisualScripting;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text connectedPlayersText;


    private void Start()
    {
        Relay.Instance.OnGameCreated += UpdateConnectedPlayersText;
        Relay.Instance.OnPlayerJoined += UpdateConnectedPlayersText;
        UpdateConnectedPlayersText();
    }


    [ContextMenu("Update Connected Players Text")]
    private void UpdateConnectedPlayersText()
    {
        var connectedPlayers = LobbyInfo.Instance.CurrentConnectedPlayers.ToString();
        var minPlayers = LobbyInfo.Instance.MinPlayers.ToString();
        var s = $"{connectedPlayers}/{minPlayers} Players Connected"; 
        connectedPlayersText.text = s;
    } 
}
