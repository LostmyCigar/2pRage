using System;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

namespace Leo
{
    public class Relay : Singleton<Relay>
    {
        private UnityTransport m_transport;

        public int ConnectedPlayersCount => NetworkManager.Singleton.ConnectedClientsIds.Count;

        private string m_joinCode;
        public string JoinCode => m_joinCode;

        public Action OnGameCreated;
        public Action OnPlayerJoined;

        private async void Awake()
        {
            m_transport = FindFirstObjectByType<UnityTransport>();
            await Authenticate();
        }

        // public void Ping(string joinCode){
        //     Debug.Log("Ping: " + joinCode);
        // }


        public static async Task Authenticate()
        {
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }


        public async Task<string> CreateGame()
        {
            Allocation alloc = await RelayService.Instance.CreateAllocationAsync(4);
            m_joinCode = await RelayService.Instance.GetJoinCodeAsync(alloc.AllocationId);

            SetHostRelayData(alloc, m_transport);

            NetworkManager.Singleton.StartHost();

            Debug.Log("CreateGame: " + m_joinCode);
            OnGameCreated?.Invoke();
            return m_joinCode;
        }

        public async void JoinGame(string joinCode)
        {
            try {
                Debug.Log("Trying to join game with code: " + joinCode);
                JoinAllocation alloc = await RelayService.Instance.JoinAllocationAsync(joinCode);

                SetClientRelayData(alloc, m_transport);
                NetworkManager.Singleton.StartClient();

                Debug.Log("JoinGame: " + joinCode);
                OnPlayerJoined?.Invoke();
            } catch (Exception e) {
                Debug.Log("Failed to join game: " + e.Message);
            }

        }


        private void SetHostRelayData(Allocation a, UnityTransport t)
        {
            t.SetHostRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData);
        }

        private void SetClientRelayData(JoinAllocation a, UnityTransport t)
        {
            t.SetClientRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData, a.HostConnectionData);
        }
    }
}

