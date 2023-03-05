using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    RemoveTileOnDestroy removeTileOnDestroy;
    BrickHealth brickHealth;
    DestroyReward destroyReward;
    // Start is called before the first frame update
    void Start()
    {
        brickHealth = GetComponent<BrickHealth>();
        destroyReward = GetComponent<DestroyReward>();
    }

    // Update is called once per frame
    void Update()
    {
        if (brickHealth.currentHealth <= 0)
        {
            if (TryGetComponent<RemoveTileOnDestroy>(out removeTileOnDestroy))
            {
                removeTileOnDestroy.DestroyTile();
            }
            destroyReward.DistributeReward();
            Destroy(this.gameObject);
        }
    }
}
