using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{
    public bool isPaused;
    public UIDocument UIDoc;
    
    private Button buttonResume;
    private Button buttonExitToMainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = UIDoc.rootVisualElement;
        
        PauseGame(false);
        
        buttonResume = root.Q<Button>("Resume");
        buttonExitToMainMenu = root.Q<Button>("ExitToMainMenu");
        
        buttonResume.clicked += () => PauseGame(false);
        buttonExitToMainMenu.clicked += () => LoadScene("Main Menu");
    }
    
    void PauseGame(bool paused)
    {
        if (paused)
        {
            UIDoc.rootVisualElement.style.display = DisplayStyle.Flex;
            
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
        }
        else
        {
            UIDoc.rootVisualElement.style.display = DisplayStyle.None;
            
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
        }
        
        isPaused = paused;
        Time.timeScale = paused ? 0 : 1;
    }
    
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }
}