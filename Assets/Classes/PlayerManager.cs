using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
	public List<Player> players;
	public int currentTurn;



	IEnumerator nextTurn() {
        currentTurn++;
        Player current = players[currentTurn % players.Count];
        GS.displayInfoMessage("It is now " + current.displayName() + "'s turn.");
        yield return StartCoroutine(current.takeTurn());
    }

	public List<Player> getPlayers() {
		return players;
	}
	IEnumerator Start(){
		currentTurn = -1;
        while ( currentTurn < 15 )
        {
		     yield return nextTurn ();
        }

	}

}
