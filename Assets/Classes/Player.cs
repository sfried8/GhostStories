using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GS.Color color;
	private Pool qiPool;
	private Pool buddhaPool;
	private TaoManager taoManager;
	public GameBoard gameBoard;
	private PlayerBoard playerBoard;
	private Vector3 currentPosition;



	private string input = "";
	// Use this for initialization
	void Start () {

	}
	


    IEnumerator MovePhase()
    {
        GS.displayInfoMessage(displayName() + " has entered the move phase.");
        while(true)
        {
            yield return StartCoroutine(GetInput());
            if (input == "x")
            {
                GS.displayInfoMessage(displayName() + " has decided not to move.");
                break;
            }
            else if (input.Length == 2)
            {

                double x = char.GetNumericValue(input[0]);
                double y = char.GetNumericValue(input[1]);
                if ( gameBoard.canMove(this, (int)x, (int)y))
                {
                    GS.displayInfoMessage(displayName() + " is moving to (" + x + "," + y + ")");
                    transform.position = new Vector3((float)x, 1f, (float)y);
                    gameBoard.movePlayer(this, (int)x, (int)y);
                    break;
                }
                else
                {
                    GS.displayWarnMessage(displayName() + " cannot go there");
                }


            }
            else
            {
                GS.displayErrorMessage("Bad input: " + input);
            }
            yield return null;
        }
        GS.displayInfoMessage(displayName() + " has finished the move phase.");

    }
    IEnumerator VillagerPhase()
    {
        GS.displayInfoMessage(displayName() + " has entered the villager phase.");
        while (true)
        {
            if (gameBoard.canRequestVillagerHelp(this))
            {
                yield return StartCoroutine(GetInput());
                if (input == "n")
                {
                    GS.displayInfoMessage(displayName() + " has decided not to request help.");
                    break;
                }
                else if (input == "y")
                {

                    gameBoard.requestVillagerHelp(this);
                    break;


                }
                else
                {
                    GS.displayErrorMessage("Bad input: " + input);
                }
                yield return null;
            }
            else
            {
                GS.displayWarnMessage("Cannot request help!");
            }
        }
        GS.displayInfoMessage(displayName() + " has finished the villager phase.");

    }

    IEnumerator GetInput()
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

	public IEnumerator takeTurn() {
        yield return StartCoroutine(MovePhase());
        yield return StartCoroutine(VillagerPhase());
        yield return null;
    }

	public bool isAlive() {
		return qiPool.isEmpty ();
	}

	private void takeMyTurn() {
		performYinPhase ();
	}

	private void performYinPhase() {
		GS.displayInfoMessage (displayName() + " is now in the Yin phase.");
		
	}

	private void requestVillager() {
		Debug.Log ("Requesting villager help");
	}

	private void attemptExorcism() {

	}
	private void placeBuddha() {

	}


	public string displayName() {
		return color.ToString() + " Player";
	}


}
