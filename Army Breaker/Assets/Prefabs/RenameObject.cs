using UnityEngine;

public class RenameObject : MonoBehaviour
{
    private void Start()
    {
        string originalName = gameObject.name;
        if (originalName.EndsWith("(Clone)"))
        {
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
    }
}
