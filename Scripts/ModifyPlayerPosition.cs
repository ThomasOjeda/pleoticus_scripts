using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyPlayerPosition : NetworkBehaviour
{
    public void modifyPlayerPosition(Transform newPosition)
    {
        if (isLocalPlayer)
            transform.position = newPosition.position;
    }
}
