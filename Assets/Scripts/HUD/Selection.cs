using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Selection : MonoBehaviour {
    private Selectable currentlySelected;
    private float lastMovement = 0f;
    public float timeBetweenMovements = 0.3f;
    public GameObject pointer;
    public GameObject instance;
	// Use this for initialization
	void Start () {
	
	}

    private GameObject getSelectedGameObject(string tag)
    {

        if (Input.GetButtonDown("A") && currentlySelected.getGameObject().CompareTag(tag))
        {
            return currentlySelected.getGameObject();
        }
        else if ( Time.realtimeSinceStartup - lastMovement > timeBetweenMovements)
        {
            lastMovement = Time.realtimeSinceStartup;
            if (Input.GetAxis("Vertical") < 0f)
            {
                currentlySelected = currentlySelected.getLowerNeighbor();
            }
            else if (Input.GetAxis("Vertical") > 0f)
            {
                currentlySelected = currentlySelected.getUpperNeighbor();
            }
            if (Input.GetAxis("Horizontal") < 0f)
            {
                currentlySelected = currentlySelected.getLeftNeighbor();
            }
            else if (Input.GetAxis("Horizontal") > 0f)
            {
                currentlySelected = currentlySelected.getRightNeighbor();
            }
            if ( Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f)
            {
                lastMovement = 0f;
            }
            instance.transform.position = currentlySelected.getGameObject().transform.position + 2 * Vector3.up;
        }
        return null;

    }
    public IEnumerator getSelectionCR(string tag)
    {
        List<GameObject> selectable = getAllSelectableObjects().Where(x => x.GetComponent<Selectable>() != null).ToList<GameObject>();
        currentlySelected = selectable[0].GetComponent<Selectable>();
        instance = (GameObject)Instantiate(pointer, selectable[0].transform.position + 2*Vector3.up, Quaternion.identity);
        GameObject selected = getSelectedGameObject(tag);
        while ( selected == null )
        {
            selected = getSelectedGameObject(tag);
            yield return null;
        }
        Destroy(instance.gameObject);
        yield return selected;
    }

    private List<GameObject> getAllSelectableObjects()
    {
        List<GameObject> selectable = new List<GameObject>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("_Selectable"))
        {
            selectable.Add(go.transform.parent.gameObject);
        }
        return selectable;
    }
}
