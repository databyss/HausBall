using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class StartMenuController : MonoBehaviour {

    public ScrollRect scrollText;
    public float scrollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
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

        // scroll the text after a 2 second delay
        if (scrollText.verticalNormalizedPosition > 0.0f && Time.timeSinceLevelLoad > 2.0f)
        {
            scrollText.verticalNormalizedPosition -= (scrollSpeed * Time.deltaTime);
        }
    }
}
