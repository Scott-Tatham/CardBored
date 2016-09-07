using UnityEngine;
using System.Collections;

public class BaseUI : MonoBehaviour
{
    Rect rect;

    void Awake()
    {
        int x = 100;
        int y = 100;

        rect = new Rect((Screen.width / 2) - (x / 2), (Screen.height / 2) - (y / 2), x, y);
    }

    protected virtual void OnGUI()
    {
        GUI.Box(rect, GUIContent.none);
    }
}