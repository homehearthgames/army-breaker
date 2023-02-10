using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color color;

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
    }
}
