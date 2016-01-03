using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
public class GSCoroutine<T>
{
    public Coroutine coroutine { get; private set; }
    public T result;
    private IEnumerator target;
    public GSCoroutine(MonoBehaviour owner, IEnumerator target)
    {
        this.target = target;
        this.coroutine = owner.StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while (target.MoveNext())
        {
            try
            {
                result = (T)(target.Current);
            }
            catch (Exception e) { Debug.Log(e.StackTrace); }
            yield return result;
        }
    }
}
public class GS {
	public enum Color
	{
		RED,
		GREEN,
		BLUE,
		YELLOW,
		BLACK,
		WHITE
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
