using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseMenu;
    [SerializeField] bool isPaused;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
        }
    }

    public void changeSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    public void quitApp()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void cheat()
    {
        PlayerPrefs.SetInt("tutorial",1);
        PlayerPrefs.SetInt("chapt1",1);
        PlayerPrefs.SetInt("chapt2",1);
        PlayerPrefs.SetInt("chapt3",1);
    }

    public void resetProgress()
    {
        PlayerPrefs.SetInt("tutorial", 0);
        PlayerPrefs.SetInt("chapt1", 0);
        PlayerPrefs.SetInt("chapt2", 0);
        PlayerPrefs.SetInt("chapt3", 0);
    }
}
