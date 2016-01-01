using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public GS.Color color;
    private Pool qiPool;
    private Pool buddhaPool;
    private TaoManager taoManager;
    public GameBoard gameBoard;
    private PlayerBoard playerBoard;



    private string input = "";
    private GameObject clicked;
    // Use this for initialization
    void Start() {

    }



    IEnumerator MovePhase()
    {
        GS.displayInfoMessage(displayName() + " has entered the move phase.");
        gameBoard.getPossibleMoves(this);
        while (true)
        {
            yield return StartCoroutine(GetInputClick("VT"));
            GridSpace targetgs = clicked.GetComponent<GridSpace>();
            VillageTile vt = targetgs.VillageTile;
            string target = vt.tilename;


                if (gameBoard.movePlayer(this, target))
                {
                    GS.displayInfoMessage(displayName() + " is moving to " + target);
                    break;
                }
                else
                {
                    GS.displayWarnMessage(displayName() + " cannot go there");
                }
        
            yield return null;
        }
        GS.displayInfoMessage(displayName() + " has finished the move phase.");

    }
    IEnumerator VillagerPhase()
    {
        GS.displayInfoMessage(displayName() + " has entered the villager phase.");
        //while (true)
        //{
        //    if (gameBoard.canRequestVillagerHelp(this))
        //    {
        //        yield return StartCoroutine(GetInput());
        //        if (input == "n")
        //        {
        //            GS.displayInfoMessage(displayName() + " has decided not to request help.");
        //            break;
        //        }
        //        else if (input == "y")
        //        {

        //            gameBoard.requestVillagerHelp(this);
        //            break;


        //        }
        //        else
        //        {
        //            GS.displayErrorMessage("Bad input: " + input);
        //        }
        //        yield return null;
        //    }
        //    else
        //    {
        //        GS.displayWarnMessage("Cannot request help!");
        //    }
        //}
        yield return new WaitForSeconds(1f);
        GS.displayInfoMessage(displayName() + " has finished the villager phase.");

    }

    IEnumerator GetInputText()
    {
        bool waitingForInput = true;
        input = "";
        while (waitingForInput)
        {

            foreach (char c in Input.inputString)
            {
                if (c == "\b"[0])
                {
                    if (input.Length != 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                    }
                }
                else
                {
                    if (c == "\n"[0] || c == "\r"[0])
                    {
                        Debug.Log(input);
                        waitingForInput = false;
                    }
                    else
                    {
                        input += c;
                    }
                }
            }
            yield return null;
        }
    }
    IEnumerator GetInputClick( string tag)
    {
        while( true )
        {
            clicked = getClick(tag);
            if (clicked != null)
            {
                break;
            }
            yield return null;
        }
        yield return null;

    }

    public IEnumerator takeTurn() {
        yield return StartCoroutine(MovePhase());
        yield return StartCoroutine(VillagerPhase());
        yield return null;
    }

    public bool isAlive() {
        return qiPool.isEmpty();
    }

    private void takeMyTurn() {
        performYinPhase();
    }

    private void performYinPhase() {
        GS.displayInfoMessage(displayName() + " is now in the Yin phase.");

    }

    private void requestVillager() {
        Debug.Log("Requesting villager help");
    }

    private void attemptExorcism() {

    }
    private void placeBuddha() {

    }


    public string displayName() {
        return color.ToString() + " Player";
    }
    public GameObject getClick(string tag)
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