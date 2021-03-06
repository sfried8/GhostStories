﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {
	public List<Player> players;
	public int currentTurn;
    public NotificationScript notification;
    public Deck deck;

    public Ghost drawGhost()
    {
        return deck.drawGhost();
    }

    IEnumerator nextTurn() {
        currentTurn++;
        Player current = players[currentTurn % players.Count];
        yield return StartCoroutine(notification.displayNotification("It is now " + current.displayName() + "'s turn."));
        yield return StartCoroutine(current.takeTurn());
    }

	public List<Player> getPlayers() {
		return players;
	}
	IEnumerator Start(){
		currentTurn = -1;
        yield return new WaitForSeconds(0.5f);
        while ( currentTurn < 15 )
        {
		     yield return nextTurn ();
        }

	}

}
