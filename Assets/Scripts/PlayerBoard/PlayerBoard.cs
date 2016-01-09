using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerBoard : MonoBehaviour {

    public enum Side { TOP, BOTTOM, LEFT, RIGHT};
    public Side side;
    public Player player;
    public PlayerBoardSpace leftSpace;
    public PlayerBoardSpace middleSpace;
    public PlayerBoardSpace rightSpace;
    public GridSpaceManager manager;
	// Use this for initialization
    public PlayerBoardSpace getSpace( GridSpace.GridSpaceCol col)
    {
        if ( col == GridSpace.GridSpaceCol.Left )
        {
            return leftSpace;
        }
        if ( col == GridSpace.GridSpaceCol.Center)
        {
            return middleSpace;
        }
        return rightSpace;
    }
	void Start () {
        manager = GameObject.FindGameObjectWithTag("_GameBoard").GetComponent<GameBoard>().gridSpaceManager;
    }
	public bool isOverrun()
    {
        return (leftSpace.hasGhost() && middleSpace.hasGhost() && rightSpace.hasGhost());
    }
    public IEnumerator performGhostActions()
    {
        yield return StartCoroutine(leftSpace.turnAction(player));
    }
	// Update is called once per frame
	void Update () {
	
	}
}
