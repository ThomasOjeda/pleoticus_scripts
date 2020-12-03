using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickMonitor : MonoBehaviour
{
    public GameObject mural;

    private void OnMouseDown()
    {
        print("Clickeo boton");
        mural.GetComponent<UpdateText>().updateName("Joaquin");
    }
}
