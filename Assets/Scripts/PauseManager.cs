using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        SettingsMenu.SetActive(false);
    }
}
