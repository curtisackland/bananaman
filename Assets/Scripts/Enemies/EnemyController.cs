using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public Transform target;

    public float hp = 100f;
    public float maxHp = 100f;
    public float scoreForDamage = 10f;
    
    [HideInInspector]
    public NavMeshAgent agent;

    public Canvas healthbar;
    private UnityEngine.UI.Slider healthbarSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        healthbarSlider = healthbar.transform.Find("Slider").GetComponent<UnityEngine.UI.Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        healthbarSlider.maxValue = maxHp;
        healthbarSlider.value = hp;
        healthbar.transform.LookAt(healthbar.worldCamera.transform);
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public float doDamage(float damage)
    {
        hp -= damage * Time.deltaTime;
        return scoreForDamage * damage * Time.deltaTime;
    }
}
