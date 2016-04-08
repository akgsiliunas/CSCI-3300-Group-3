using UnityEngine;
using System.Collections;
using UnityEditor;

public class Menuitem : MonoBehaviour {

    [MenuItem("Adbullah/Delete Saved Score")]
    static void DoSomething()
    {
        Debug.Log("Score Deleted...");
        PlayerPrefs.DeleteAll();
    }
}
