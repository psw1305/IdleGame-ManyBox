using UnityEngine;

public class Managers : MonoBehaviour
{
    #region Singleton
    private static Managers instance;
    public static Managers Instance  => instance != null ? instance : (instance = new());
    #endregion

    private ResourceManager resource = new();
    private GameManager game = new();
    private UIManager ui = new();
    public static ResourceManager Resource => Instance.resource;
    public static GameManager Game => Instance.game;
    public static UIManager UI => Instance.ui;
}
