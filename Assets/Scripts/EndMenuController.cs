using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class EndMenuController : MonoBehaviour {

    public ScrollRect scrollText;
    public float scrollSpeed;

	// Update is called once per frame
	void Update () {
        // load game field on space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("PlayField");
        }
        // quit on ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        // scroll the text
        if (scrollText.verticalNormalizedPosition > 0.0f)
        {
            scrollText.verticalNormalizedPosition -= (scrollSpeed * Time.deltaTime);
        }
	}
}
