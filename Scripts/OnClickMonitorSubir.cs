using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickMonitorSubir : MonoBehaviour
{
    public GameObject monitor;

    private void OnMouseDown()
    {
        print("Clickeo boton subir");
        monitor.GetComponent<UpdateText>().paginaSiguiente();
    }
}
