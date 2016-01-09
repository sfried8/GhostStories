using UnityEngine;
using System.Collections;
using System;

public class PlayerBoardSpace : MonoBehaviour, Selectable {
    public PlayerBoard board;
    public GridSpace.GridSpaceCol position;
    private Ghost ghost;
    public Transform ghostModel;
    private Transform instance;
    public Ghost Ghost
    {
        get
        {
            return ghost;
        }

        set
        {
            ghost = value;
        }
    }

    // Use this for initialization
    void Start () {
        ghost = null;
        board = gameObject.transform.GetComponentInParent<PlayerBoard>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool hasGhost()
    {
        return ghost != null;
    }

    public IEnumerator turnAction(Player player)
    {
        if (hasGhost())
        {
            yield return StartCoroutine(Ghost.onTurn(player));
        }
        else
        {
            yield return null;
        }
    }
    public void addGhost(Ghost ghost)
    {
        Ghost = ghost;
        instance = (Transform)Instantiate(ghostModel, transform.position + Vector3.up, Quaternion.identity);
    }
    public void exorciseGhost()
    {
        Ghost = null;
        Destroy(instance.gameObject);
    }

    public Selectable getUpperNeighbor()
    {
        if ( board.side == PlayerBoard.Side.TOP)
        {
            return this;
        }
        if ( board.side == PlayerBoard.Side.LEFT)
        {
            if ( position == GridSpace.GridSpaceCol.Left)
            {
                return this;
            }
            if ( position == GridSpace.GridSpaceCol.Center)
            {
                return board.leftSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return board.middleSpace as Selectable;
            }
        }
        if (board.side == PlayerBoard.Side.RIGHT)
        {
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return this;
            }
            if (position == GridSpace.GridSpaceCol.Center)
            {
                return board.rightSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Left)
            {
                return board.middleSpace as Selectable;
            }
        }
        if ( board.side == PlayerBoard.Side.BOTTOM)
        {
            return board.manager.findByRowCol(GridSpace.GridSpaceRow.Bottom, position);
        }

        return null;

    }

    public Selectable getLowerNeighbor()
    {
        if (board.side == PlayerBoard.Side.BOTTOM)
        {
            return this;
        }
        if (board.side == PlayerBoard.Side.RIGHT)
        {
            if (position == GridSpace.GridSpaceCol.Left)
            {
                return this;
            }
            if (position == GridSpace.GridSpaceCol.Center)
            {
                return board.leftSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return board.middleSpace as Selectable;
            }
        }
        if (board.side == PlayerBoard.Side.LEFT)
        {
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return this;
            }
            if (position == GridSpace.GridSpaceCol.Center)
            {
                return board.rightSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Left)
            {
                return board.middleSpace as Selectable;
            }
        }
        if (board.side == PlayerBoard.Side.TOP)
        {
            return board.manager.findByRowCol(GridSpace.GridSpaceRow.Top, position.Opposite());
        }

        return null;
    }

    public Selectable getLeftNeighbor()
    {
        if (board.side == PlayerBoard.Side.LEFT)
        {
            return this;
        }
        if (board.side == PlayerBoard.Side.TOP)
        {
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return this;
            }
            if (position == GridSpace.GridSpaceCol.Center)
            {
                return board.rightSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Left)
            {
                return board.middleSpace as Selectable;
            }
        }
        if (board.side == PlayerBoard.Side.BOTTOM)
        {
            if (position == GridSpace.GridSpaceCol.Left)
            {
                return this;
            }
            if (position == GridSpace.GridSpaceCol.Center)
            {
                return board.leftSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return board.middleSpace as Selectable;
            }
        }
        if (board.side == PlayerBoard.Side.RIGHT)
        {
            return board.manager.findByRowCol(position.CCW(), GridSpace.GridSpaceCol.Right);
        }

        return null;
    }

    public Selectable getRightNeighbor()
    {
        if (board.side == PlayerBoard.Side.RIGHT)
        {
            return this;
        }
        if (board.side == PlayerBoard.Side.TOP)
        {
            if (position == GridSpace.GridSpaceCol.Left)
            {
                return this;
            }
            if (position == GridSpace.GridSpaceCol.Center)
            {
                return board.leftSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return board.middleSpace as Selectable;
            }
        }
        if (board.side == PlayerBoard.Side.BOTTOM)
        {
            if (position == GridSpace.GridSpaceCol.Right)
            {
                return this;
            }
            if (position == GridSpace.GridSpaceCol.Center)
            {
                return board.rightSpace as Selectable;
            }
            if (position == GridSpace.GridSpaceCol.Left)
            {
                return board.middleSpace as Selectable;
            }
        }
        if (board.side == PlayerBoard.Side.LEFT)
        {
            return board.manager.findByRowCol(position.CW(), GridSpace.GridSpaceCol.Left);
        }

        return null;
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }
}
