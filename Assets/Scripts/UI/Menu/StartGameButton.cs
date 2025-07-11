using UnityEngine;
using Leo;

public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button startGameButton;

    [SerializeField]
    private string goToSceneName = "GameScene";

    void Start()
    {
        Relay.Instance.OnGameCreated += UpdateButton;
        Relay.Instance.OnPlayerJoined += UpdateButton;
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (LobbyInfo.Instance.IsReady)
            startGameButton.interactable = true;
        else
            startGameButton.interactable = false;
    }

    public void StartGame()
    {
        if (!LobbyInfo.Instance.IsReady)
            return;
    }
}
