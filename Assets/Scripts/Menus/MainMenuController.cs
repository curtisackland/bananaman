using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class MainMenuController : MonoBehaviour
{
    public UIDocument UIDoc;
    public LeaderboardController leaderboard;
    // Start is called before the first frame update
    private Button buttonStart;
    private Button buttonExit;
    private TextField textFieldUsername;

    private Label score1;
    private Label score2;
    private Label score3;
    
    void Start()
    {
        VisualElement root = UIDoc.rootVisualElement;
        
        buttonStart = root.Q<Button>("Start");
        buttonExit = root.Q<Button>("Exit");
        textFieldUsername = root.Q<TextField>("Username");
        
        score1 = root.Q<Label>("Score1");
        score2 = root.Q<Label>("Score2");
        score3 = root.Q<Label>("Score3");

        score1.text = leaderboard.GetScore1();
        score2.text = leaderboard.GetScore2();
        score3.text = leaderboard.GetScore3();
        
        buttonStart.clicked += () => LoadScene("Main Scene");
        buttonExit.clicked += () => QuitGame();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        leaderboard.SetUsername(textFieldUsername.value);
    }
}
