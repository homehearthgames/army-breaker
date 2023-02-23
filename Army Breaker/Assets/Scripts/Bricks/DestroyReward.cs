using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyReward : MonoBehaviour
{
    [SerializeField] int pointReward = 100;
    [SerializeField] int timeToAdd = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DistributeReward() {
        ScoreHandler scoreHandler = FindObjectOfType<ScoreHandler>();
        //Use this if statement later in order to check if this is the player kingdom or not
        //We dont want to award points or combo for destroying our own stuff
        if (true)
        {
            scoreHandler.AddPoints(pointReward);
            scoreHandler.AddToComboBuilder(timeToAdd);
        }
    }
}
