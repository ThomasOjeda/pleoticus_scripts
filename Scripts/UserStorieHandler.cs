using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStorieHandler : MonoBehaviour
{
    [SerializeField] private GameObject userStoriePrefab;

    [SerializeField] private GameObject anchor;

    private GameObject userStorie;
    // Start is called before the first frame update
    void Start()
    {
        userStorie = Instantiate(userStoriePrefab);
        userStorie.transform.SetParent(this.transform,false);
        //userStorie.transform.SetParent(transform, false);
        userStorie.GetComponent<DragDrop>().setAnchor(anchor);
        userStorie.transform.position = transform.position;
        userStorie.GetComponent<DragDrop>().setCanvas(transform.parent.gameObject);
        print("instancia de user storie");
    }

    public void initiateNewUserStorie()
    {
            Start();

    }

}
