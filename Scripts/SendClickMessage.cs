using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Runtime.InteropServices;

public class SendClickMessage : NetworkBehaviour
{
    public GameObject obj;

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){

            obj.transform.position += new  Vector3(0, 0, 1);
        }
    }

}
