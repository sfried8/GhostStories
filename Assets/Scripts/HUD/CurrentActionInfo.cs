using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentActionInfo : MonoBehaviour {

    private Text text;
    private CanvasGroup cg;
    public float maxAlpha = 0.75f;
    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
        cg = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void displayMessage(string message)
    {
        text.text = message;
        cg.alpha = maxAlpha;
    }
    public void clearMessage()
    {
        cg.alpha = 0f;
    }
}
