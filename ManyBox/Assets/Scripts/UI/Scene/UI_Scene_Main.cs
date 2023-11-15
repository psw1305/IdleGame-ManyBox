public class UI_Scene_Main : UI_Scene
{
    #region Enums

    enum Buttons
    {
        btnGameScreen,
    }
    enum Texts
    {
        txtBoxCount,
    }

    #endregion

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        BindButton(typeof(Buttons));
        BindText(typeof(Texts));

        GetButton((int)Buttons.btnGameScreen).onClick.AddListener(OnButtonClicked);
        GetText((int)Texts.txtBoxCount).text = $"»óÀÚ ¼ö: {Managers.Game.Box}";
    }

    public void OnButtonClicked()
    {
        Managers.Game.Box += 1;
    }
}
