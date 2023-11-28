using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class PlayerHUD : MonoBehaviour
{
    public UIDocument UIDoc;
    public Player bananaman;

    private Label score;
    private ProgressBar healthBar;
    private Label laserTime;
    private ProgressBar laserCooldownBar;
    
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = UIDoc.rootVisualElement;
        
        score = root.Q<Label>("Score");
        healthBar = root.Q<ProgressBar>("Health");
        laserTime = root.Q<Label>("LaserTime");
        laserCooldownBar = root.Q<ProgressBar>("LaserCooldown");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = bananaman.score.ToString();
        healthBar.value = bananaman.health;
        laserTime.text = bananaman.currentLasterTime + "/" + bananaman.maxLaserTime;
        
        laserCooldownBar.value = bananaman.currentLaserCooldown;
        if (bananaman.currentLaserCooldown != 0)
        {
            laserCooldownBar.style.display = DisplayStyle.Flex;
            laserCooldownBar.title = "Reloading...";
        }
        else
        {
            laserCooldownBar.title = "";
            laserCooldownBar.style.display = DisplayStyle.None;
        }
        
    }
}
