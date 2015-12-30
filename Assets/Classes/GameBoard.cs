using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameBoard : MonoBehaviour {
    private List<List<VillageTile>> tiles;
    public struct Point
    {
        public int x;
        public int y;
        public Point( int x, int y )
        {
            this.x = x;
            this.y = y;
        }
        public void set( int x, int y )
        {
            this.x = x;
            this.y = y;
        }
    }
    Point greenPlayerPosition = new Point(1,1);
    Point redPlayerPosition = new Point(1, 1);
    Point bluePlayerPosition = new Point(1, 1);
    Point yellowPlayerPosition = new Point(1, 1);
    void Start()
    {
        List<VillageTile> t2d = new List<VillageTile>();
        for ( int i = 0; i < 9; i++)
        {
            t2d.Add(new VT_Graveyard("graveyard "+i));
        }
        UnityEngine.Random rng = new UnityEngine.Random();
        for (int i = 0; i < 9; i++)
        {
            VillageTile temp = t2d[i];
            int randomIndex = UnityEngine.Random.Range(i, 9);
            t2d[i] = t2d[randomIndex];
            t2d[randomIndex] = temp;
        }

        tiles = new List<List<VillageTile>>();
        tiles.Add(t2d.GetRange(0, 3));
        tiles.Add(t2d.GetRange(3, 3));
        tiles.Add(t2d.GetRange(6, 3));

        printBoard();

    }

    public void printBoard()
    {
        Debug.Log("\n");
        for ( int i = 2; i >= 0; i -- )
        {
            List<VillageTile> t = tiles[i];
            Debug.Log("\t\t\t-------------------------------------------------");
            Debug.Log( "\t\t\t"+t[0].tilename + " | " + t[1].tilename + " | " + t[2].tilename );
        }
    }

    public void movePlayer(Player player, int x, int y)
    {
        setPlayerPosition(player, x, y);
        string newTile = tiles[x][y].tilename;
        GS.displayInfoMessage(player.displayName() + " is now on the " + newTile + " tile");
    }

    public bool canMove( Player player, int x, int y )
    {
        if ( player.color == GS.Color.RED)
        {
            return true;
        }

        return areTheyNeighbors(getPlayerPosition(player), new Point(x, y));

        
    }

    private bool areTheyNeighbors( Point a, Point b)
    {
        int xDist = a.x - b.x;
        int yDist = a.y - b.y;

        xDist = xDist > 0 ? xDist : -xDist;
        yDist = yDist > 0 ? yDist : -yDist;

        return (xDist < 2 && yDist < 2);
    }

    private Point getPlayerPosition( Player player )
    {
        switch( player.color )
        {
            case GS.Color.BLUE:
                return bluePlayerPosition;
            case GS.Color.GREEN:
                return greenPlayerPosition;
            case GS.Color.RED:
                return redPlayerPosition;
            case GS.Color.YELLOW:
                return yellowPlayerPosition;
            default:
                return new Point(0, 0);

        }
        
    }
    private void setPlayerPosition(Player player, int x, int y)
    {
        switch (player.color)
        {
            case GS.Color.BLUE:
                bluePlayerPosition = new Point(x, y);
                break;
            case GS.Color.GREEN:
                greenPlayerPosition = new Point(x, y);
                break;
            case GS.Color.RED:
                redPlayerPosition = new Point(x, y);
                break;
            case GS.Color.YELLOW:
                yellowPlayerPosition = new Point(x, y);
                break;

        }

    }

    private VillageTile getCurrentTile( Player player )
    {
        Point pos = getPlayerPosition(player);
        return tiles[pos.x][pos.y];
    }

    public bool canRequestVillagerHelp( Player player )
    {
        return getCurrentTile(player).canPerformAction(player);
    }
    public void requestVillagerHelp(Player player)
    {
        getCurrentTile(player).performAction(player);
    }

}
