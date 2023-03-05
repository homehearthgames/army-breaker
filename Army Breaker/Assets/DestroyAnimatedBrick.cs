using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimatedBrick : MonoBehaviour
{
    RemoveTileOnDestroy removeTileOnDestroy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CallDestroy()
    {
        if (TryGetComponent<RemoveTileOnDestroy>(out removeTileOnDestroy))
        {
            removeTileOnDestroy.DestroyTile();
        }
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
