using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColor : MonoBehaviour
{
    BrickHealth brickHealth;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        brickHealth = GetComponent<BrickHealth>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStructureColor();
    }
        
    public void ChangeStructureColor()
    {
        float ratio = 1 - ((float)brickHealth.currentHealth / brickHealth.maxHealth);
        spriteRenderer.color = new Color(1 - ratio, 1 - ratio, 1 - ratio);
    }
}
