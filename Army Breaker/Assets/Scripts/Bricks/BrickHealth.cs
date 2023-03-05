using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 1;
    [SerializeField] public int currentHealth = 1;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }
}
