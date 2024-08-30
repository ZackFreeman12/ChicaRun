
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class MenuUI : MonoBehaviour
{
    private UIDocument doc;
    private List<Button> buttonList;

    void Awake()
    {
        doc = GetComponent<UIDocument>();
        buttonList = new List<Button>
        {
            //Play (0) Extras (1) Quit(2) Settings(3)
            doc.rootVisualElement.Q("playButton") as Button,
            doc.rootVisualElement.Q("extrasButton") as Button,
            doc.rootVisualElement.Q("quitButton") as Button,
            doc.rootVisualElement.Q("settingsButton") as Button
        };

        buttonList[0].RegisterCallback<PointerEnterEvent>(onPlayClick);

    }

    void Update()
    {

    }

    private void onPlayClick(PointerEnterEvent e)
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
