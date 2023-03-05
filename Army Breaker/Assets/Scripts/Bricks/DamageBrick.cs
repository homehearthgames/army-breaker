using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBrick : MonoBehaviour
{
    BrickHealth brickHealth;
    ParticleSystem damagedParticles;
    // Start is called before the first frame update
    void Start()
    {
        brickHealth = GetComponent<BrickHealth>();
        damagedParticles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ball")
        {
            Debug.LogWarning("Decreasing HP");
            brickHealth.currentHealth--;
            if (brickHealth.currentHealth == 1 && damagedParticles != null)
            {
                damagedParticles.Play();
            }
        }
    }
}
