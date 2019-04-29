using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHider : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
    }

    void OnApplicationQuit()
    {
        Cursor.visible = true;
    }
}
