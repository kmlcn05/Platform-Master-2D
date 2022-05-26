using UnityEngine;
public class MenuManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static MenuManager menu;
    public bool paused;
    public GameObject menuObject;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                OpenMenu();
                Time.timeScale = 0f;
            }
            else
            {
                CloseMenu();
                Time.timeScale = 1f;
            }
        }
    }
    public void Start()
    {

        if (menu != null)
        {
            Destroy(gameObject);
            return;
        }
        menu = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OpenMenu()
    {
        menuObject.SetActive(true);
        paused = true;
    }
    public void CloseMenu()
    {
        menuObject.SetActive(false);
        paused = false;

    }
    public void Resume()
    {
        CloseMenu();
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
