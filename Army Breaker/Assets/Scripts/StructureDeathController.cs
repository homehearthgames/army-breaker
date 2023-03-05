using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureDeathController : MonoBehaviour
{
    private bool isQuitting;
    [SerializeField] ParticleSystem destroyParticles;
    BoxCollider2D boxCollider2D;
    DestroyReward destroyReward;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        destroyReward = GetComponentInParent<DestroyReward>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ball")
        {
            destroyReward.DistributeReward();
            boxCollider2D.enabled = false;
            destroyParticles.gameObject.SetActive(true);
        }
    }

}
