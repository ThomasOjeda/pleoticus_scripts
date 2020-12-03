using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReceiveDrop : MonoBehaviour , IDropHandler
{
    public FollowCursor userStoryAnchor;

    [SerializeField] private GameObject userStorieHandler;

    [SerializeField] private GameObject listcontent;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && eventData.pointerDrag.tag == "USER_STORIE")
            {

                //GameObject listcontent = transform.GetChild(2).gameObject.transform.GetChild(0).gameObject;

                if (eventData.pointerDrag.GetComponent<DragDrop>().getIsFirstDrop())
                    userStorieHandler.GetComponent<UserStorieHandler>().initiateNewUserStorie();

                eventData.pointerDrag.transform.SetParent(listcontent.transform, false);

                /*if (eventData.pointerDrag.transform.parent==userStorieHandler.transform)
                userStorieHandler.GetComponent<UserStorieHandler>().initiateNewUserStorie();

                eventData.pointerDrag.transform.SetParent(listcontent.transform,false);*/

                userStoryAnchor.setActualizar(true);
            }
    }
}
