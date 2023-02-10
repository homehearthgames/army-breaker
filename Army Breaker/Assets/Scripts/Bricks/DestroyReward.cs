using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyReward : MonoBehaviour
{
    [SerializeField] int pointReward = 1000;
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
        scoreHandler.AddPoints(pointReward);
    }
}
