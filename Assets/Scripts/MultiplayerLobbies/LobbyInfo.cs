using UnityEngine;
using Unity.Netcode;

namespace Leo
{
    public class LobbyInfo : Singleton<LobbyInfo>
    {
        private string lobbyName;

        [SerializeField]
        private int maxPlayers = 2;

        [SerializeField]
        private int minPlayers = 2;

        public int MaxPlayers => maxPlayers;
        public int MinPlayers => minPlayers;

        public int CurrentConnectedPlayers => NetworkManager.Singleton.ConnectedClientsIds.Count;

        public bool IsFull => CurrentConnectedPlayers >= MaxPlayers;
        public bool IsReady => CurrentConnectedPlayers >= MinPlayers;
        
        public string LobbyName
        {
            get => lobbyName;
            set
            {
                lobbyName = value;
            }
        }
    }
}

