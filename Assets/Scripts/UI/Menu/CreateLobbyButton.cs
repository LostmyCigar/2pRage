using System.Threading.Tasks;
using Leo;
using UnityEngine;
using Unity.Netcode;

public class CreateLobbyButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text joinCodeField;
    public async void OnClick()
    {
        //hacky way of not creating new lobbies when we already have one
        if (NetworkManager.Singleton.IsHost)
            return;

        var joinCode = await Relay.Instance.CreateGame();
        joinCodeField.text = joinCode;
    }
}
