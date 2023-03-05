using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : MonoBehaviour
{
    [SerializeField] GameObject enemyKings;
    [SerializeField] GameObject playerKings;

    public bool playerKingsSlain;
    public bool enemyKingsSlain;

    // Start is called before the first frame update
    void Start()
    {
        CheckEnemyKings(); 
        CheckPlayerKings();   
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyKings(); 
        CheckPlayerKings(); 
    }

    void CheckPlayerKings()
    {
        if (playerKings.transform.childCount > 0) // If the enemy king has children, it is not slain
        {
            playerKingsSlain = false;
            return;
        }
        // If the loop has finished without returning, it means all enemy kings are slain
        playerKingsSlain = true;
    }

    void CheckEnemyKings()
    {
        if (enemyKings.transform.childCount > 0) // If the enemy king has children, it is not slain
        {
            enemyKingsSlain = false;
            return;
        }
        // If the loop has finished without returning, it means all enemy kings are slain
        enemyKingsSlain = true;
    }
}
