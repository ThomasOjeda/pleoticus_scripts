using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptApretoTeclaL : NetworkBehaviour
{
    /*
    GameObject spawnedBoard;
    private void Start()
    {
        spawnedBoard=GameObject.Find("NetworkManager").GetComponent<NetworkManagerV5>().spawnedBoard;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            CmdTellServerToMoveBoard();
        }
    }

    [Command] 
    public void CmdTellServerToMoveBoard()
    {
        spawnedBoard.transform.position += new Vector3(0, 1, 0);
        RpcTellClientsToMoveBoard();
    }

    [ClientRpc]
    public void RpcTellClientsToMoveBoard()
    {
        spawnedBoard.transform.position += new Vector3(0, 1, 0);
    }
    */
}
