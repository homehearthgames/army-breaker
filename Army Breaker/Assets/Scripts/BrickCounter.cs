using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCounter : MonoBehaviour
{
    public int numberOfBricks;

    // Start is called before the first frame update
    void Start()
    {
        UpdateNumberOfBricks();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateNumberOfBricks();
    }

    private void UpdateNumberOfBricks()
    {
        // Get all the objects in the scene with the "Brick" tag
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        // Get the count of objects with the "Brick" tag
        numberOfBricks = bricks.Length;
    }
}
