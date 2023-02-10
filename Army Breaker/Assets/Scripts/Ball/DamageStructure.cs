using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStructure : MonoBehaviour
{
    [SerializeField] public float timeToAdd;
    [SerializeField] public int pointsToAdd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.TryGetComponent<StructureHealth>(out StructureHealth structureHealth))
        {
            structureHealth.currentHealth--;
            ScoreHandler scoreHandler = FindObjectOfType<ScoreHandler>();
            scoreHandler.AddToComboBuilder(timeToAdd);
            scoreHandler.AddPoints(pointsToAdd);
        }
    }
}
