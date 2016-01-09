using UnityEngine;
using System.Collections;
using System;

public static class GridSpaceExtensions
{
    public static GridSpace.GridSpaceCol Opposite(this GridSpace.GridSpaceCol col)
    {

        if (col == GridSpace.GridSpaceCol.Left)
        {
            return GridSpace.GridSpaceCol.Right;
        }
        else if (col == GridSpace.GridSpaceCol.Right)
        {
            return GridSpace.GridSpaceCol.Left;
        }
        return GridSpace.GridSpaceCol.Center;
    }
    public static GridSpace.GridSpaceRow CW(this GridSpace.GridSpaceCol col)
    {
        if (col == GridSpace.GridSpaceCol.Left)
        {
            return GridSpace.GridSpaceRow.Top;
        }
        else if (col == GridSpace.GridSpaceCol.Right)
        {
            return GridSpace.GridSpaceRow.Bottom;
        }
        return GridSpace.GridSpaceRow.Center;
    }
    public static GridSpace.GridSpaceRow CCW(this GridSpace.GridSpaceCol col)
    {
        if (col == GridSpace.GridSpaceCol.Left)
        {
            return GridSpace.GridSpaceRow.Bottom;
        }
        else if (col == GridSpace.GridSpaceCol.Right)
        {
            return GridSpace.GridSpaceRow.Top;
        }
        return GridSpace.GridSpaceRow.Center;
    }
    public static GridSpace.GridSpaceRow Opposite(this GridSpace.GridSpaceRow row)
    {
        if (row == GridSpace.GridSpaceRow.Top)
        {
            return GridSpace.GridSpaceRow.Bottom;
        }
        else if (row == GridSpace.GridSpaceRow.Bottom)
        {
            return GridSpace.GridSpaceRow.Top;
        }
        return GridSpace.GridSpaceRow.Center;
    }
    public static GridSpace.GridSpaceCol CW(this GridSpace.GridSpaceRow row)
    {
        if (row == GridSpace.GridSpaceRow.Top)
        {
            return GridSpace.GridSpaceCol.Right;
        }
        else if (row == GridSpace.GridSpaceRow.Bottom)
        {
            return GridSpace.GridSpaceCol.Left;
        }
        return GridSpace.GridSpaceCol.Center;
    }
    public static GridSpace.GridSpaceCol CCW(this GridSpace.GridSpaceRow row)
    {
        if (row == GridSpace.GridSpaceRow.Top)
        {
            return GridSpace.GridSpaceCol.Left;
        }
        else if (row == GridSpace.GridSpaceRow.Bottom)
        {
            return GridSpace.GridSpaceCol.Right;
        }
        return GridSpace.GridSpaceCol.Center;
    }
}
public class GridSpace : MonoBehaviour, Selectable{
    private GridSpaceManager manager;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("_GameBoard").GetComponent<GameBoard>().gridSpaceManager;
    }
    public enum GridSpaceRow
    {
        Bottom,
        Center,
        Top
    }
    public enum GridSpaceCol
    {
        Left,
        Center,
        Right
    }

	public struct GridSpacePosition_struct
    {
        public GridSpaceRow row;
        public GridSpaceCol col;
        public GridSpacePosition_struct( GridSpaceRow r, GridSpaceCol c)
        {
            row = r;
            col = c;
        }
    }



    private GridSpacePosition_struct gridSpacePosition;
    public VillageTile villageTile;


    public VillageTile VillageTile
    {
        get
        {
            return villageTile;
        }

        set
        {
            villageTile = value;
        }
    }

    public GridSpacePosition_struct GridSpacePosition
    {
        get
        {
            return gridSpacePosition;
        }

        set
        {
            gridSpacePosition = value;
        }
    }
    public override string ToString()
    {
        return VillageTile.tilename + ": " + GridSpacePosition.row + ", " + GridSpacePosition.col;
    }
    public void highlight()
    {
        VillageTile.highlight();
    }
    public void unhighlight()
    {
        VillageTile.unhighlight();
    }

    public Selectable getUpperNeighbor()
    {
        if (gridSpacePosition.row == GridSpaceRow.Bottom)
        {
            return manager.findByRowCol(GridSpaceRow.Center, gridSpacePosition.col);
        }
        if (gridSpacePosition.row == GridSpaceRow.Center)
        {
            return manager.findByRowCol(GridSpaceRow.Top, gridSpacePosition.col);
        }
        return manager.TopBoard.getSpace(GridSpacePosition.col.Opposite());
    }

    public Selectable getLowerNeighbor()
    {
        if (gridSpacePosition.row == GridSpaceRow.Top)
        {
            return manager.findByRowCol(GridSpaceRow.Center, gridSpacePosition.col);
        }
        if (gridSpacePosition.row == GridSpaceRow.Center)
        {
            return manager.findByRowCol(GridSpaceRow.Bottom, gridSpacePosition.col);
        }
        return manager.BottomBoard.getSpace(GridSpacePosition.col);
    }

    public Selectable getLeftNeighbor()
    {
        if (gridSpacePosition.col == GridSpaceCol.Right)
        {
            return manager.findByRowCol(gridSpacePosition.row, GridSpaceCol.Center);
        }
        if (gridSpacePosition.col == GridSpaceCol.Center)
        {
            return manager.findByRowCol(gridSpacePosition.row, GridSpaceCol.Left);
        }
        return manager.LeftBoard.getSpace(GridSpacePosition.row.CCW());
    }

    public Selectable getRightNeighbor()
    {
        if (gridSpacePosition.col == GridSpaceCol.Left)
        {
            return manager.findByRowCol(gridSpacePosition.row, GridSpaceCol.Center);
        }
        if (gridSpacePosition.col == GridSpaceCol.Center)
        {
            return manager.findByRowCol(gridSpacePosition.row, GridSpaceCol.Right);
        }
        return manager.RightBoard.getSpace(GridSpacePosition.row.CW());
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }
}
