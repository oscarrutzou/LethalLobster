using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject aiGameObject;

    [SerializeField]
    private int health = 30;

    private void Awake()
    {
        if (aiGameObject == null)
        {
            Debug.LogError("Need to have the ai gameobject, so the parent gameobject that gets deleted when it dies");
        }
    }

    public void Damage(int damage)
    {
        Debug.Log(damage);
        if (health - damage > 0) { 
            health -= damage;
        }else
        {
            health = 0;
            Destroy(aiGameObject);
        }
    }
}
