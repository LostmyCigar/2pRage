using UnityEngine;
using Unity.Netcode;
using Leo;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button startGameButton;

    [SerializeField]
    private string goToSceneName = "GameScene";

    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += UpdateButton;
        NetworkManager.Singleton.OnClientDisconnectCallback += UpdateButton;
    }

    private void UpdateButton(ulong clientId)
    {
        if (LobbyInfo.Instance.IsReady)
            startGameButton.interactable = true;
        else
            startGameButton.interactable = false;
    }

    public void StartGame()
    {
        if (!LobbyInfo.Instance.IsReady || !NetworkManager.Singleton.IsServer)
            return;
        SceneManager.LoadScene(goToSceneName);
    }
}
