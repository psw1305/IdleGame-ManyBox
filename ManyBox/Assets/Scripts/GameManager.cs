using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button boxButton;
    [SerializeField] TextMeshProUGUI boxLabel;
    public double Box { get; set; }

    void Start()
    {
        Box = 0;
        boxButton.onClick.AddListener(BoxClick);
    }

    void BoxClick()
    {
        Box += 1;
        boxLabel.text = string.Format("Box : {0}", Box);
    }
}
