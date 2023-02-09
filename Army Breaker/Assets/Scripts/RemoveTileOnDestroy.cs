using UnityEngine;
using UnityEngine.Tilemaps;

public class RemoveTileOnDestroy : MonoBehaviour
{
    private Tilemap tilemap;

    private void Start()
    {
        tilemap = GetComponentInParent<Tilemap>();
    }

    public void DestroyTile()
    {
        Debug.Log("Running DestroyTile()");
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        // tilemap.SetTile(cellPosition, null);
    }
}
