
using Unity.Netcode;
using Unity.Collections;
using UnityEngine;
using Leo;
using System;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private bool spawnAtSpawnPoint = true;
    

    public NetworkVariable<FixedString32Bytes> playerName;

    private void OnEnable()
    {
        playerName.OnValueChanged += OnNameChange;
    }

    private void OnDisable()
    {
        playerName.OnValueChanged -= OnNameChange;
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
            GetName();
    }

    void Start()
    {
        if (spawnAtSpawnPoint)
            transform.position = FindFirstObjectByType<SpawnPoint>().transform.position;
        SetName();
    }


    #region Player names
    public void GetName()
    {
        playerName.Value = $"Player {LobbyInfo.Instance.CurrentConnectedPlayers}";
    }

    private void OnNameChange(FixedString32Bytes oldValue, FixedString32Bytes newValue)
    {
        SetName();
    }

    private void SetName()
    {
        GetComponentInChildren<TMPro.TextMeshProUGUI>().text = playerName.Value.ToString();
    }

    #endregion
}
