using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameBoard : MonoBehaviour {
    public GridSpaceManager gridSpaceManager;


    void Start()
    {

        
        gridSpaceManager.ShuffleBoard();

    }

    public void printBoard()
    {

    }
    public List<string> getPossibleMoves(Player player)
    {
        return gridSpaceManager.getPlayerPossibleMoves(player);
    }
    public bool movePlayer(Player player, string villageName)
    {
        if ( gridSpaceManager.getPlayerPossibleMoves(player).Contains(villageName)) {
            StartCoroutine (gridSpaceManager.movePlayer(player, villageName));
            return true;
        }
        return false;
    }

   public IEnumerator attemptExorcism( Player player )
    {
        List<PlayerBoardSpace> attackableGhosts = gridSpaceManager.getAttackableGhostSpaces(player);
        foreach ( PlayerBoardSpace pbs in attackableGhosts )
        {
            if ( pbs.hasGhost() )
            {
                GS.displayInfoMessage("Exorcising " + pbs.Ghost.GhostName);
                yield return new WaitForSeconds(0.3f);
                pbs.exorciseGhost();
            }
        }
        yield return null;
    }

    public VillageTile getCurrentTile( Player player )
    {
        return gridSpaceManager.getPlayerPosition(player).VillageTile;
    }

    public bool canRequestVillagerHelp( Player player )
    {
        return false;// getCurrentTile(player).canPerformAction(player);
    }
    public void requestVillagerHelp(Player player)
    {
        //getCurrentTile(player).performAction(player);
    }

}
