using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerAdministrator : NetworkBehaviour
{
    
    [SyncVar] int identificator = 0;

    List<GameObject> connectedPlayers;

    [Server]
    public void Start()
    {
       
    }

    [Server]
    public int NewPlayerId()
    {

        identificator++;

        return identificator-1;

    }

    [Server]
    public void RegisterNewPlayer(GameObject player,int id)
    {
        if (connectedPlayers == null)
            connectedPlayers = new List<GameObject>(); 

        connectedPlayers.Add(player);

        print("Estas son las id de los jugadores conectados");
        foreach (GameObject obj in connectedPlayers)
        {
            print(obj.GetComponent<PlayerIdentificatorScript>().idOfPlayer);
        }
    }

    [Server]
    public void DeletePlayer(GameObject player, int id)
    {
        connectedPlayers.Remove(player);
    }
    

}
