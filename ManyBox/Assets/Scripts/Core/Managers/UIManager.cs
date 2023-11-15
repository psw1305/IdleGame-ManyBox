using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    #region Properties
    
    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root") ?? new GameObject { name = "@UI_Root" };
            return root;
        }
    }

    public UI_Scene SceneUI => sceneUI;
    
    #endregion

    #region Fields
    
    private int order = 10;
    private UI_Scene sceneUI = null;
    private Stack<UI_Popup> popupStack = new();
   
    #endregion

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

    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        go.transform.SetParent(Root.transform);

        T sceneUI = Util.GetOrAddComponent<T>(go);
        this.sceneUI = sceneUI;

        return sceneUI;
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.Instantiate($"UI/Prefabs/{name}");
        go.transform.SetParent(Root.transform);

        T popup = Util.GetOrAddComponent<T>(go);
        popupStack.Push(popup);

        return popup;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        // 비어있는 스택이라면 삭제 불가
        if (popupStack.Count == 0)
        {
            return;
        }

        // 스택의 가장 위에 있는 Peek() 가 아니면 삭제 불가
        if (popupStack.Peek() != popup)
        {
            Debug.Log("Close Popup Failed");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (popupStack.Count == 0)
        {
            return;
        }

        UI_Popup popup = popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;
        order--;
    }

    public void CloseAllPopupUI()
    {
        while (popupStack.Count > 0) 
        {
            ClosePopupUI();
        }
    }
}
