using UnityEngine;
using System.Collections;
using System;

public class GraveWalker : Ghost {

    public override IEnumerator onExit(Player player)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator onSummon(Player player)
    {
        player.QiPool.getFromPool(1);
        yield return null;
    }

    public override IEnumerator onTurn(Player player)
    {
        GS.displayInfoMessage("BOO!");
        yield return null;
    }

    // Use this for initialization
    void Start () {
        GhostName = "Grave Walker";
        HaunterPosition = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
