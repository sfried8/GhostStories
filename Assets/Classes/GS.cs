using UnityEngine;
using System.Collections;

public class GS : MonoBehaviour {
	private bool waitingForInput = false;
	private string input = "";
	public enum Color
	{
		RED,
		GREEN,
		BLUE,
		YELLOW,
		BLACK,
		WHITE
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


		
	public static void displayMessage( string message ) {
		Debug.Log (message);
	}


	public static void displayErrorMessage( string message ) {
		displayMessage ("[ERROR] " + message);
	}
	public static void displayInfoMessage( string message ) {
		displayMessage ("[INFO ] " + message);
	}
	public static void displayWarnMessage( string message ) {
		displayMessage ("[WARN ] " + message);
	}


}
