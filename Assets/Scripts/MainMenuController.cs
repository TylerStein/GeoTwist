using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool touchInput = false;
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            touchInput = touch.phase == TouchPhase.Began;
        }

        if (Input.GetButton("Fire1") || touchInput) {
            SceneManager.LoadScene(levelName);
        }
    }
}
