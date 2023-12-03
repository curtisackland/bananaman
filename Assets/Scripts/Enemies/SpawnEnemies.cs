using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public EnemyController slime;

    public EnemyController turtle;

    public EnemyController ghost;
    
    public EnemyController snowman;

    private GameObject slimeGameObject;

    private GameObject turtleGameObject;

    private GameObject ghostGameObject;
    
    private GameObject snowmanGameObject;

    public List<Transform> spawns;
    
    public LightingManager lightingManager;

    private bool ghostHasSpawned = false;
    
    private bool snowmanHasSpawned = false;

    public int round = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        slimeGameObject = slime.gameObject;
        turtleGameObject = turtle.gameObject;
        ghostGameObject = ghost.gameObject;
        snowmanGameObject = snowman.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (slime.hp <= 0 && turtle.hp <= 0)
        {
            round++;
            slime.hp = 100 * round;
            turtle.hp = 100 * round;
            slimeGameObject.SetActive(true);
            turtleGameObject.SetActive(true);
            slimeGameObject.transform.position = spawns[Random.Range(0, spawns.Count - 1)].position;
            turtleGameObject.transform.position = spawns[Random.Range(0, spawns.Count - 1)].position;
        }
        
        if ((lightingManager.TimeOfDay >= 18 || lightingManager.TimeOfDay <= 6) && !ghostHasSpawned)
        {
            snowmanGameObject.SetActive(false);
            snowmanHasSpawned = false;
            
            ghostGameObject.SetActive(true);
            ghostGameObject.transform.position = spawns[Random.Range(0, spawns.Count - 1)].position;
            ghost.hp = 100 * round;
            ghostHasSpawned = true;
        }
        else if ((lightingManager.TimeOfDay < 18 && lightingManager.TimeOfDay > 6) && !snowmanHasSpawned)
        {
            ghostGameObject.SetActive(false);
            ghostHasSpawned = false;
            
            snowmanGameObject.SetActive(true);
            snowmanGameObject.transform.position = spawns[Random.Range(0, spawns.Count - 1)].position;
            snowman.hp = 100 * round;
            snowmanHasSpawned = true;
        }
    }
}
