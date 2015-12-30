using UnityEngine;
using System.Collections;

public abstract class Ghost : MonoBehaviour {
	private string name;
	private GS.Color color;
	private int resistance;
	private int haunterPosition;

	public abstract void onSummon ();
	public abstract void onTurn();
	public abstract void onExit ();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
