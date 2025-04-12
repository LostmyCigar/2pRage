using System.Threading.Tasks;
using Leo;
using UnityEngine;

public class CreateLobbyButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text joinCodeField;
    public async void OnClick()
    {
        var joinCode = await Relay.Instance.CreateGame();
        joinCodeField.text = joinCode;
    }
}
