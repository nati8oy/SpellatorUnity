//Attach this script to your Canvas GameObject

using UnityEngine;
using UnityEngine.iOS;

public class CanvasSwitcher : MonoBehaviour
{
    enum RenderModeStates { camera, overlay, world };
    RenderModeStates m_RenderModeStates;

    public string deviceModelString;

    Canvas m_Canvas;

    public DeviceGeneration deviceGeneration;

    // Use this for initialization
    void Start()
    {
        m_Canvas = GetComponent<Canvas>();

        deviceModelString = SystemInfo.deviceModel;

        Debug.Log("device type: " + SystemInfo.deviceModel);
        Debug.Log("device generaton " + deviceGeneration);


        //check the device type and change the canvas type accordingly

        switch (deviceGeneration)
            {

            //check if it's the longer and thinner screen type
            case DeviceGeneration.iPhone11:
                SetScreenSpaceCanvas();
                break;
            case DeviceGeneration.iPhone11Pro:
                SetScreenSpaceCanvas();
                break;
            case DeviceGeneration.iPhone11ProMax:
                SetScreenSpaceCanvas();
                break;
            case DeviceGeneration.iPhoneX:
                SetScreenSpaceCanvas();
                break;
            case DeviceGeneration.iPhoneXR:
                SetScreenSpaceCanvas();
                break;
            case DeviceGeneration.iPhoneXS:
                SetScreenSpaceCanvas();
                break;
            case DeviceGeneration.iPhoneXSMax:
                SetScreenSpaceCanvas();
                break;


                //if it's the iPad then use the regular world space camera view
            case DeviceGeneration.iPad1Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPad2Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPad3Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPad4Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPad5Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPad6Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPad7Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadAir1:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadAir2:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadMini1Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadMini2Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadMini3Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadMini4Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadPro10Inch1Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadPro10Inch2Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadPro11Inch:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadPro1Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadPro2Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadPro3Gen:
                SetWorldSpaceCanvas();
                break;
            case DeviceGeneration.iPadUnknown:
                SetWorldSpaceCanvas();
                break;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        //Press the space key to switch between render mode states
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState();
        }
    }
    

    public void SetWorldSpaceCanvas()
    {
        m_Canvas.renderMode = RenderMode.WorldSpace;
        m_RenderModeStates = RenderModeStates.camera;
    }

    public void SetScreenSpaceCanvas()
    {
        m_Canvas.renderMode = RenderMode.ScreenSpaceCamera;
        m_RenderModeStates = RenderModeStates.overlay;
    }

    public void SetScreenSpaceOverlayCanvas()
    {
        m_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        m_RenderModeStates = RenderModeStates.world;
    }



    void ChangeState()
    {
        switch (m_RenderModeStates)
        {
            case RenderModeStates.camera:
                m_Canvas.renderMode = RenderMode.ScreenSpaceCamera;
                m_RenderModeStates = RenderModeStates.overlay;
                break;

            case RenderModeStates.overlay:
                m_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                m_RenderModeStates = RenderModeStates.world;
                break;
            case RenderModeStates.world:
                m_Canvas.renderMode = RenderMode.WorldSpace;
                m_RenderModeStates = RenderModeStates.camera;

                break;
        }
    }
}