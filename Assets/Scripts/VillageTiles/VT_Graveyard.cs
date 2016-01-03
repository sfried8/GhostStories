using UnityEngine;
using System.Collections;
using System;

public class VT_Graveyard : VillageTile
{


    public override bool canPerformAction(Player player)
    {
        if ( isHaunted )
        {
            return false;
        }
        return true;
    }

    public override void performAction(Player player)
    {
        GS.displayInfoMessage(player.displayName() + " used the " + tilename + " oooooooo");
    }
}
