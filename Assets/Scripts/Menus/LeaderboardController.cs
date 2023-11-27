using UnityEngine;
using System;

public class LeaderboardController : MonoBehaviour
{

    public void Start()
    {
        if (String.IsNullOrEmpty(PlayerPrefs.GetString("score1")))
        {
            PlayerPrefs.SetString("score1", "*** 000");
        }
        
        if (String.IsNullOrEmpty(PlayerPrefs.GetString("score2")))
        {
            PlayerPrefs.SetString("score2", "*** 000");
        }
        
        if (String.IsNullOrEmpty(PlayerPrefs.GetString("score3")))
        {
            PlayerPrefs.SetString("score3", "*** 000");
        }

        if (String.IsNullOrEmpty(PlayerPrefs.GetString("username")))
        {
            PlayerPrefs.SetString("username", "***");
        }
    }
    
    

    public void SavePlayerPrefs(String username, float score)
    {
        float score1 = float.Parse(PlayerPrefs.GetString("score1").Split(" ")[1]);
        float score2 = float.Parse(PlayerPrefs.GetString("score2").Split(" ")[1]);
        float score3 = float.Parse(PlayerPrefs.GetString("score3").Split(" ")[1]);

        if (score > score1)
        {
            PlayerPrefs.SetString("score3", PlayerPrefs.GetString("score2"));
            PlayerPrefs.SetString("score2", PlayerPrefs.GetString("score1"));
            PlayerPrefs.SetString("score1", username + " " + score);
        } else if (score > score2)
        {
            PlayerPrefs.SetString("score3", PlayerPrefs.GetString("score2"));
            PlayerPrefs.SetString("score2", username + " " + score);  
        } else if (score > score3)
        {
            PlayerPrefs.SetString("score3", username + " " + score); 
        }
        
    }

    public String GetScore1()
    {
        return PlayerPrefs.GetString("score1");
    }
    
    public String GetScore2()
    {
        return PlayerPrefs.GetString("score2");
    }
    
    public String GetScore3()
    {
        return PlayerPrefs.GetString("score3");
    }

    public String GetUsername()
    {
        return PlayerPrefs.GetString("username");
    }

    public void SetUsername(String username)
    {
        PlayerPrefs.SetString("username", username);
    }
        
}
