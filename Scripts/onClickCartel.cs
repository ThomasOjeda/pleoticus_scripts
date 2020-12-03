using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;

public class onClickCartel : NetworkBehaviour
{
    public void OnPointerClick(PointerEventData eventData) // 3
    {
        CmdSendClickToServer();
        print("snappers1");
    }

    [Command]
    public void CmdSendClickToServer()
    {
        print("snappers");
    }
}
