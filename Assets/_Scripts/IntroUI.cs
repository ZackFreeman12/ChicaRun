
using UnityEngine.UIElements;
using UnityEngine;

public class IntroUI : MonoBehaviour
{
    private UIDocument doc;
    private Label pressLabel;
    private float labelOpacity = 1;
    private bool blink;

    void Awake()
    {
        doc = GetComponent<UIDocument>();

        pressLabel = doc.rootVisualElement.Q("pressLabel") as Label;
    }
    void Update()
    {



        if (labelOpacity <= 0.2)
        {
            blink = true;
        }
        if (labelOpacity == 1)
        {
            blink = false;
        }

        if (blink)
        {
            labelOpacity += 0.02f;
        }
        else
        {
            labelOpacity -= 0.02f;
        }
        pressLabel.style.opacity = labelOpacity;
    }
}
