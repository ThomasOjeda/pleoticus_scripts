using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickMonitorBajar : MonoBehaviour
{
    public GameObject monitor;

    private void OnMouseDown()
    {
        print("Clickeo boton bajar");
        monitor.GetComponent<UpdateText>().paginaAnterior();
    }
}
