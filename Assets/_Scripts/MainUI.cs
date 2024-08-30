
using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    private UIDocument doc;
    private Label coinLabel;

    void Awake()
    {
        doc = GetComponent<UIDocument>();

        coinLabel = doc.rootVisualElement.Q("coinLabel") as Label;
    }

    void FixedUpdate()
    {
        coinLabel.text = PlayerManager.instance.coins.ToString(); ;
    }
}
