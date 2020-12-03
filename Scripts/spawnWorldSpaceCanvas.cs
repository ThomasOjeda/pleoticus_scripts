using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWorldSpaceCanvas : NetworkBehaviour
{

    public GameObject tospawn;
    public GameObject spawned;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    [Command]
    void CmdSpawnCanvas()
    {
        spawned = Instantiate(tospawn);
        NetworkServer.Spawn(spawned);
    }

}
