using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int order = 10;

    Stack<UI_Popup> popupStack = new();
    UI_Scene sceneUI = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root") ?? new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = order;
            order++;
        }
        else // 팝업이 아닌 일반 고정 UI
        {
            canvas.sortingOrder = 0;
        }
    }
}
