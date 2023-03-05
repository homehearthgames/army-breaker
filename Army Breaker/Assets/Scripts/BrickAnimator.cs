using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickAnimator : MonoBehaviour
{
    DestroyReward destroyReward;
    [SerializeField] Animator animator;
    BrickHealth brickHealth;
    [SerializeField] ParticleSystem destroyParticle;

    BoxCollider2D brickCollider;
    // Start is called before the first frame update
    void Start()
    {
        brickHealth = GetComponent<BrickHealth>();
        destroyReward = GetComponent<DestroyReward>();
        brickCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (brickHealth.currentHealth <= 1)
            {
                brickCollider.enabled = false;
                destroyReward.DistributeReward();
                if (destroyParticle != null)
                {
                    Instantiate(destroyParticle, new Vector3(0.5f, 0.5f, 0f), Quaternion.identity);
                }
                Debug.LogWarning("Destroy!");
                animator.SetTrigger("Destroy");
            } else
            {
                Debug.LogWarning("Hit!");
                animator.SetTrigger("Hit");
            }
        }
    }
}
