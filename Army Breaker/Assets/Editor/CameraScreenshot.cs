using UnityEngine;
using UnityEditor;
using System.IO;

public class CameraScreenshot : MonoBehaviour
{
    [MenuItem("Assets/Take Camera Screenshot")]
    public static void SaveCameraScreenshot()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogWarning("No camera found in the scene.");
            return;
        }

        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 24);
        cam.targetTexture = rt;
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        cam.Render();
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null;
        DestroyImmediate(rt);

        byte[] bytes = screenshot.EncodeToPNG();
        string screenshotPath = Path.Combine(Application.dataPath, "Level_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
        File.WriteAllBytes(screenshotPath, bytes);

        Debug.Log("Screenshot saved to " + screenshotPath);
    }
}
