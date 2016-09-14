using UnityEngine;
using System.Collections;

public class CrossHairUI : MonoBehaviour
{
    [SerializeField]
    Texture2D crossHair;
    bool freeze;
    float centreX;
    float centreY;
    Rect rect;

    public bool GetFreeze()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            freeze = false;
        }

        else if (Cursor.lockState == CursorLockMode.None)
        {
            freeze = true;
        }

        return freeze;
    }

    void Start()
    {
        freeze = false;
        centreX = (Screen.width / 2) - (crossHair.width / 2);
        centreY = (Screen.height / 2) - (crossHair.height / 2);

        rect = new Rect(centreX, centreY, crossHair.width, crossHair.height);

        MouseLock();
    }

    void Update()
    {
        SetMouseLock();
    }

    void OnGUI()
    {
        GUI.DrawTexture(rect, crossHair);
    }

    public static void MouseLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void MouseUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void SetMouseLock()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MouseUnlock();
        }

        if (Input.GetMouseButtonDown(0))
        {
            MouseLock();
        }
    }
}