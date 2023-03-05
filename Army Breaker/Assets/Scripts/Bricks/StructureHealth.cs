using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 1;
    [SerializeField] public int currentHealth = 1;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color color;
    [SerializeField] GameObject smokeParticles;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        ChangeStructureColor();
        DestroyStructure();
    }

    public void DestroyStructure()
    {
        if (currentHealth <= 0)
        {
            DestroyReward destroyReward = GetComponent<DestroyReward>();
            destroyReward.DistributeReward();
            Destroy(gameObject);
            if (gameObject.TryGetComponent(out RemoveTileOnDestroy rtod)) {
                Debug.Log("Got reference to the tile");
                rtod.DestroyTile();
            }
        }
    }


    
    public void ChangeStructureColor()
    {
        float ratio = 1 - ((float)currentHealth / maxHealth);
        spriteRenderer.color = new Color(1 - ratio, 1 - ratio, 1 - ratio);
        if (currentHealth == 1 && maxHealth != 1)
        {
            if (smokeParticles != null)
            {
                smokeParticles.SetActive(true);
            }
        }
    }
}
