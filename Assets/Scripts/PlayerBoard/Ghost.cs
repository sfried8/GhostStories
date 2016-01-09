using UnityEngine;
using System.Collections;

public abstract class Ghost : MonoBehaviour {

	public GS.Color color;
    private int resistance;
    private int haunterPosition = -1;
    private string ghostName;

    public int Resistance
    {
        get
        {
            return resistance;
        }

        set
        {
            resistance = value;
        }
    }

    protected int HaunterPosition
    {
        get
        {
            return haunterPosition;
        }

        set
        {
            haunterPosition = value;
        }
    }

    public string GhostName
    {
        get
        {
            return ghostName;
        }

        set
        {
            ghostName = value;
        }
    }

    public abstract IEnumerator onSummon (Player player);
	public abstract IEnumerator onTurn(Player player);
    public abstract IEnumerator onExit(Player player);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
