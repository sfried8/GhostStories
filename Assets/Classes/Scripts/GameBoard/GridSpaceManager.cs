using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class GridSpaceManager : MonoBehaviour{

    public List<GridSpace> gridSpaceList;
    public GameBoardModelManager GameBoardModelManager;
    private GridSpace redPlayerPosition;
    private GridSpace greenPlayerPosition;
    private GridSpace yellowPlayerPosition;
    private GridSpace bluePlayerPosition;



    public List<GridSpace> getAllSpaces()
    {
        return gridSpaceList;
    }
    public IEnumerator movePlayer( Player player, string villageName )
    {
        unHighlightAll();
        yield return StartCoroutine(setPlayerPosition(player, findByVillageTileName(villageName)));
    }
    private GridSpace findByVillageTileName( string villageName )
    {
        foreach (GridSpace gridSpace in gridSpaceList)
        {
            if ( gridSpace.VillageTile.tilename == villageName )
            {
                return gridSpace;
            }
        }
        return null;
    }
    private GridSpace findByRowCol(GridSpace.GridSpaceRow r, GridSpace.GridSpaceCol c)
    {
        foreach (GridSpace gridSpace in gridSpaceList)
        {
            if (gridSpace.GridSpacePosition.row == r && gridSpace.GridSpacePosition.col == c)
            {
                return gridSpace;
            }
        }
        return null;
    }
    public List<string> getPlayerPossibleMoves( Player player)
    {
        GridSpace currentPosition = getPlayerPosition(player);
        List<GridSpace> neighbors;
        List<string> neighborNames = new List<string>();
        if ( player.color == GS.Color.RED )
        {
            neighbors = getAllSpaces();
            highlightAll();
        }
        else
        {
            neighbors = getNeighbors(currentPosition);
        }
        foreach ( GridSpace gs in neighbors)
        {
            neighborNames.Add(gs.VillageTile.tilename);
        }
        return neighborNames;
    }
    public List<GridSpace> getNeighbors( GridSpace gridSpace)
    {
        List<GridSpace> neighbors = new List<GridSpace>();
        foreach (GridSpace otherGridSpace in gridSpaceList)
        {
            if (isNeighbor(gridSpace.GridSpacePosition, otherGridSpace.GridSpacePosition))
            {
                neighbors.Add(otherGridSpace);
                otherGridSpace.highlight();
            }
        }
        return neighbors;
    }

    public void unHighlightAll()
    {
        foreach (GridSpace gridSpace in gridSpaceList)
        {
            gridSpace.unhighlight();
        }
    }
    public void highlightAll()
    {
        foreach (GridSpace gridSpace in gridSpaceList)
        {
            gridSpace.highlight();
        }
    }

    private bool isNeighbor( GridSpace.GridSpacePosition_struct a, GridSpace.GridSpacePosition_struct b)
    {
        bool rowNeighbor = !((a.row == GridSpace.GridSpaceRow.Bottom && b.row == GridSpace.GridSpaceRow.Top) ||
                             (a.row == GridSpace.GridSpaceRow.Top && b.row == GridSpace.GridSpaceRow.Bottom));
        bool colNeighbor = !((a.col == GridSpace.GridSpaceCol.Left && b.col == GridSpace.GridSpaceCol.Right) ||
                             (a.col == GridSpace.GridSpaceCol.Right && b.col == GridSpace.GridSpaceCol.Left));

        return rowNeighbor && colNeighbor;
    }


    private GridSpace getPlayerPosition(Player player)
    {
        switch (player.color)
        {
            case GS.Color.RED:
                return redPlayerPosition;
            case GS.Color.GREEN:
                return greenPlayerPosition;
            case GS.Color.YELLOW:
                return yellowPlayerPosition;
            case GS.Color.BLUE:
                return bluePlayerPosition;
        }
        return null;
    }
    private IEnumerator setPlayerPosition(Player player, GridSpace gridSpace)
    {
        switch (player.color)
        {
            case GS.Color.RED:
                redPlayerPosition = gridSpace;
                break;
            case GS.Color.GREEN:
                greenPlayerPosition = gridSpace;
                break;
            case GS.Color.YELLOW:
                yellowPlayerPosition = gridSpace;
                break;
            case GS.Color.BLUE:
                bluePlayerPosition = gridSpace;
                break;
        }
        yield return StartCoroutine(GameBoardModelManager.movePlayer(player, gridSpace));
    }

    public void ShuffleBoard()
    {



        gridSpaceList.Shuffle();

        int i = 0;
        foreach ( GridSpace.GridSpaceRow r in Enum.GetValues(typeof(GridSpace.GridSpaceRow))  )
        {
            foreach (GridSpace.GridSpaceCol c in Enum.GetValues(typeof(GridSpace.GridSpaceCol)))
            {
                gridSpaceList[i].GridSpacePosition = new GridSpace.GridSpacePosition_struct(r, c);
                i++;
            }
        }
        GridSpace center = findByRowCol(GridSpace.GridSpaceRow.Center, GridSpace.GridSpaceCol.Center);
        redPlayerPosition = center;
        yellowPlayerPosition = center;
        greenPlayerPosition = center;
        bluePlayerPosition = center;

        GameBoardModelManager.initializeBoardWithPlayersAtCenter(gridSpaceList);
    }
}
