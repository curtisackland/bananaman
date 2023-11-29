using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public EnemyController slime;

    public EnemyController turtle;

    private GameObject slimeGameObject;

    private GameObject turtleGameObject;

    public List<Transform> spawns;

    public int round = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        slimeGameObject = slime.gameObject;
        turtleGameObject = turtle.gameObject;
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
    }
}
