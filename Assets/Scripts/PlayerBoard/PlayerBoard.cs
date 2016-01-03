using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerBoard : MonoBehaviour {

    public enum Side { TOP, BOTTOM, LEFT, RIGHT};
    public Side side;
    public PlayerBoardSpace leftSpace;
    public PlayerBoardSpace middleSpace;
    public PlayerBoardSpace rightSpace;
	// Use this for initialization
	void Start () {
	
	}
	public bool isOverrun()
    {
        return (leftSpace.hasGhost() && middleSpace.hasGhost() && rightSpace.hasGhost());
    }

    public List <PlayerBoardSpace> getOpenSpaces()
    {
        List<PlayerBoardSpace> openSpaces = new List<PlayerBoardSpace>();
        if ( !leftSpace.hasGhost() )
        {
            openSpaces.Add(leftSpace);
        }
        if (!middleSpace.hasGhost())
        {
            openSpaces.Add(middleSpace);
        }
        if (!rightSpace.hasGhost())
        {
            openSpaces.Add(rightSpace);
        }

        return openSpaces;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
