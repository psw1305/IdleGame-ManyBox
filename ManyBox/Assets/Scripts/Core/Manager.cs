public static class Manager
{
    private static GameManager game = new();
    private static UIManager ui = new();

    public static GameManager Game => game;
    public static UIManager UI => ui;
}
