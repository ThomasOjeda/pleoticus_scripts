using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Mirror;

public class spawnCube : NetworkBehaviour
{
    public GameObject cubo;
    // Start is called before the first frame update
    [Server]
    void Start()
    {
        Instantiate(cubo);
        cubo.transform.position = new Vector3(0, 5, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
