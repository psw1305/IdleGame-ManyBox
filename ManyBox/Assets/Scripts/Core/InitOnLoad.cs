using UnityEngine;

internal static class InitOnLoad
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitApplication()
    {
        // �ҷ��� ���ҽ� ���� �̸�
        GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs/InitOnLoad");

        if (prefabs.Length > 0)
        {
            foreach (var prefab in prefabs)
            {
                GameObject go = Object.Instantiate(prefab);
                go.name = prefab.name;
                Object.DontDestroyOnLoad(go);
            }
        }
    }
}

