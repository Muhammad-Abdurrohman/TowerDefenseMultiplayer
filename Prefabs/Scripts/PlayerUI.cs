using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {

    [SerializeField]
    GameObject pauseMenu;

	// Use this for initialization
	void Start () {
        pauseMenu.SetActive(false);
        PauseMenu.IsOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TogglePauseMenu();
        }
	}

    void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.IsOn = pauseMenu.activeSelf;
    }
}
