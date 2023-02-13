using UnityEngine;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;
    public string folderName = "Screenshots";
    public bool captureWholeScreen = true;
    public Rect captureRect = new Rect(0, 0, 1920, 1080);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            string folderPath = Path.Combine(Application.dataPath, folderName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            Texture2D texture;
            if (captureWholeScreen)
            {
                texture = ScreenCapture.CaptureScreenshotAsTexture();
            }
            else
            {
                texture = new Texture2D((int)captureRect.width, (int)captureRect.height, TextureFormat.RGB24, false);
                texture.ReadPixels(captureRect, 0, 0);
                texture.Apply();
            }

            byte[] bytes = texture.EncodeToPNG();
            string filePath = Path.Combine(folderPath, "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
            File.WriteAllBytes(filePath, bytes);

            Debug.Log("Screenshot saved to " + filePath);
        }
    }
}
