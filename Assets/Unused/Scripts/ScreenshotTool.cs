using UnityEngine;

public class ScreenshotTool : EntityBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Screenshot captured.");
            ScreenCapture.CaptureScreenshot("screenshot.png", 2);
        }
    }
}
