using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationScript : MonoBehaviour {

    public Color backgroundColor;
    public Color textColor;

    private Text text;
    private Image backgroundImage;

    public float fadeSpeed = 5f;


    public IEnumerator displayMultipleChoiceQuestionCR( string message, string[] options, string[] buttons)
    {
        text = gameObject.GetComponentInChildren<Text>();
        string fullMessage = message;
        for( int i = 0; i < options.Length; i++)
        {
            fullMessage += "\n" + buttons[i] + "  " + options[i];
        }
        text.text = fullMessage;


        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1f;
        GSCoroutine<string> buttonPress = new GSCoroutine<string>(this, GetButtonPressCR(buttons));
        yield return buttonPress.result;
        while (buttonPress.result == null)
        {
            yield return null;
        }
        while (cg.alpha > 0.05f)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, 0, fadeSpeed * Time.deltaTime);
            yield return buttonPress.result;
        }
        cg.alpha = 0f;
        yield return buttonPress.result;
    }
    public GSCoroutine<string> displayMultipleChoiceQuestion ( string message, string[] options, string[] buttons)
    {
        return new GSCoroutine<string>(this, displayMultipleChoiceQuestionCR(message, options, buttons));
    }
    IEnumerator GetButtonPressCR(string[] options)
    {
        if (options.Length > 0)
        {
            string selectedOption = "";
            while (true)
            {
                foreach (string option in options)
                {
                    if (Input.GetButtonDown(option))
                    {
                        selectedOption = option;
                        break;
                    }
                }
                if (selectedOption != "")
                {
                    break;
                }
                yield return null;
            }
            yield return selectedOption;

        } 
        else
        {
            yield return null;
        }

    }
    public IEnumerator displayNotification( string message )
    {
        return displayTimedNotification(message, 0f);
    }
	public IEnumerator displayTimedNotification(string message, float secondsToWait)
    {
        text = gameObject.GetComponentInChildren<Text>();

        text.text = message + "  ▶";

        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.alpha = 1f;
        if ( secondsToWait == 0f)
        {
            yield return StartCoroutine(getAnyButtonInput());
        }
        else
        {
            yield return new WaitForSeconds(secondsToWait);
        }
        while (cg.alpha > 0.05f )
        {
            cg.alpha = Mathf.Lerp(cg.alpha, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        cg.alpha = 0f;
        yield return null;

    }
    public IEnumerator getAnyButtonInput()
    {
        while (true)
        {
            if ( Input.anyKeyDown )
            {
                break;
            }
            yield return null;
        }
        yield return null;
    }
}
