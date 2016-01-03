﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    public GS.Color color;
    private PlayerIO io;
    private Pool qiPool;
    private Pool buddhaPool;
    private TaoManager taoManager;
    private GameBoard gameBoard;
    private PlayerBoard playerBoard;
    private bool hasYinYang;



    // Use this for initialization
    void Start() {
        io = gameObject.GetComponent<PlayerIO>();
        qiPool = new Pool(4);
        taoManager = new TaoManager();
        taoManager.addTao(color, 1);
        taoManager.addTao(GS.Color.BLACK, 1);
        hasYinYang = true;
        gameBoard = GameObject.FindGameObjectWithTag("_GameBoard").GetComponent<GameBoard>();

    }



    IEnumerator MovePhase()
    {
        GS.displayInfoMessage(displayName() + " has entered the move phase.");
        gameBoard.getPossibleMoves(this);
        while (true)
        {
            io.startHoverInfo();
            GSCoroutine<GameObject> clickedGSC = io.getClickedGameObject("_VillageTile");
            yield return clickedGSC.coroutine;
            while ( clickedGSC.result == null )
            {
                yield return null;
            }
            GridSpace targetgs = clickedGSC.result.GetComponent<GridSpace>();
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
        VillageTile currentTile = gameBoard.getCurrentTile(this);
        string[] options = new string[] { "Request help from " + currentTile.tilename, "Attempt Exorcism", "Pass" };
        string[] buttons = new string[] { "A", "X", "B" };
        GSCoroutine<string> mcq = io.getButtonPressDialog("What would you like to do?", options, buttons);
        yield return mcq.coroutine;
        GS.displayInfoMessage(mcq.result);
        switch ( mcq.result )
        {
            case "A":
                GS.displayInfoMessage(currentTile.tilename + " is busy, try again later.");
                break;
            case "X":
                GS.displayInfoMessage("Attempting Exorcism");
                break;
            case "B":
                GS.displayInfoMessage("Passing turn");
                break;
        }
        yield return new WaitForSeconds(1f);
        

    }




    public IEnumerator takeTurn() {
        yield return StartCoroutine(MovePhase());
        yield return StartCoroutine(VillagerPhase());
        io.stopHoverInfo();
        yield return null;
    }

    public bool isAlive() {
        return qiPool.isEmpty();
    }


    public string displayName() {
        return color.ToString() + " Player";
    }

}