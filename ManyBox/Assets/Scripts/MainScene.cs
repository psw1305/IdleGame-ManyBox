using UnityEngine;

public class MainScene : MonoBehaviour
{
    public UI_Scene_Main MainUI { get; private set; }

    void Awake()
    {
        Managers.Game.Init();
        MainUI = Managers.UI.ShowSceneUI<UI_Scene_Main>();
        MainUI.Init();
    }
}
