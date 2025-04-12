using System.Collections;
using System.Collections.Generic;
using Leo;
using UnityEngine;
using TMPro;

public class JoinLobbyButton : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    public void Start()
    {
        inputField.caretWidth = 0;
    }
    
    public void OnClick(){
        string joinCode = inputField.text.ToUpper();
        
        Relay.Instance.JoinGame(joinCode);
    }
}
