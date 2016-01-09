using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {

    public List<Ghost> deck;
    public Ghost WuFeng;
	// Use this for initialization
	void Start () {
        deck.Shuffle();
        deck.Insert(deck.Count - 11, WuFeng);
	}

    public Ghost drawGhost()
    {
        Ghost ghost = deck[0];
        deck.RemoveAt(0);
        return ghost;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
