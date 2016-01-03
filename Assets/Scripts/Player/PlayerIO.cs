using UnityEngine;
using System.Collections;

public class PlayerIO : MonoBehaviour {

    private MouseInfoMessage mouseInfoMessage;
    private NotificationScript notification;

    void Start()
    {
        mouseInfoMessage = GameObject.FindGameObjectWithTag("_MouseInfoMessage").GetComponent<MouseInfoMessage>();
        notification = GameObject.FindGameObjectWithTag("_Notification").GetComponent<NotificationScript>();
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
        return new GSCoroutine<GameObject>(this, GetInputClick(tag));
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
                //print out the name if the raycast hits something
                Debug.Log(hit.collider.name);
                //freeclup= hit.collider.name;
                if (hit.collider.gameObject.CompareTag(tag))
                {
                    return hit.collider.gameObject;
                }

            }
        }
        return null;
    }

}
