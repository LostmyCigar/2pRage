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

        [SerializeField]
        private Color[] playerColors;

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
        
        public Color GetPlayerColor(int playerIndex)
        {
            if (playerIndex < 0 || playerIndex >= playerColors.Length)
            {
                return Color.white;
            }
            return playerColors[playerIndex];
        }
    }
}

