using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerIO : MonoBehaviour {

    private MouseInfoMessage mouseInfoMessage;
    private NotificationScript notification;
    private CurrentActionInfo currentActionInfo;
    private Selection selection;

    void Start()
    {
        mouseInfoMessage = GameObject.FindGameObjectWithTag("_MouseInfoMessage").GetComponent<MouseInfoMessage>();
        notification = GameObject.FindGameObjectWithTag("_Notification").GetComponent<NotificationScript>();
        currentActionInfo = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CurrentActionInfo>();
        selection = GameObject.FindGameObjectWithTag("_CurrentActionInfo").GetComponent<Selection>();

    }
    IEnumerator GetInputClick(string tag)
    {
        GameObject clicked = null;
        while (true)
        {
            clicked = getClick(tag);
            if (clicked != null)
            {
                break;
            }
            yield return null;
        }
        yield return clicked;

    }


    public GSCoroutine<GameObject> getClickedGameObject(string tag)
    {
        return new GSCoroutine<GameObject>(this, selection.getSelectionCR(tag));
        //return new GSCoroutine<GameObject>(this, GetInputClick(tag));
    }

    public GSCoroutine<string> getButtonPressDialog(string message, string[] options, string[] buttons)
    {
        return notification.displayMultipleChoiceQuestion(message, options, buttons);
    }

    public void startHoverInfo()
    {
        StartCoroutine("HoverInfo");
    }
    public void stopHoverInfo()
    {
        StopCoroutine("HoverInfo");
        mouseInfoMessage.clearMessage();
    }
    public void displayCurrentActionInfo(string message)
    {
        currentActionInfo.displayMessage(message);
    }
    public void clearCurrentActionInfo()
    {
        currentActionInfo.clearMessage();
    }
    public IEnumerator displayNotificationMessage(string message)
    {
        return notification.displayNotification(message);
    }
    IEnumerator HoverInfo()
    {
        while (true)
        {
            RaycastHit hit;
            //ray shooting out of the camera from where the mouse is
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("_VillageTile"))
                {
                    mouseInfoMessage.displayMessage(hit.collider.gameObject.GetComponent<GridSpace>().VillageTile.tilename);
                }
                else if (hit.collider.gameObject.CompareTag("_PlayerBoardSpace"))
                {
                    PlayerBoardSpace pbs = hit.collider.gameObject.GetComponent<PlayerBoardSpace>();
                    mouseInfoMessage.displayMessage(pbs.hasGhost() ? "Gh-gh-gh-ghost!" : "Open Space");
                }
                else
                {
                    mouseInfoMessage.clearMessage();
                }

            }
            else
            {
                mouseInfoMessage.clearMessage();
            }
            yield return null;
        }
    }

    private GameObject getClick(string tag)
    {


        // this code show nameobject with click   
        if (Input.GetMouseButtonDown(0))
        {
            //empty RaycastHit object which raycast puts the hit details into
            RaycastHit hit;
            //ray shooting out of the camera from where the mouse is
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.gameObject.CompareTag(tag))
                {
                    return hit.collider.gameObject;
                }

            }
        }
        return null;
    }



}
