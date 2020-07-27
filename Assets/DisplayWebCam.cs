using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWebCam : MonoBehaviour
{
    private WebCamTexture webCamTexture;
    private int _cameraIndex = 0;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled, // 0 for no sync, 1 for panel refresh rate, 2 for 1/2 panel rate
        Application.targetFrameRate = 45;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SetWebCamera(_cameraIndex);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            SetWebCamera(_cameraIndex, -1);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            SetWebCamera(_cameraIndex, 1);
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }

    private void SetWebCamera(int index, int step = 0)
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        RawImage raw = this.GetComponentInChildren<RawImage>();

        if (devices.Length == 0 || raw == null) return;

        int _numberOfDevices = devices.Length;
        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Webcam available: " + devices[i].name);
        }

        //step to next camera
        if (step != 0)
        {
            webCamTexture.Stop();

            _cameraIndex += step;
            if (_cameraIndex < 0)
                _cameraIndex = _numberOfDevices - 1;
            if (_cameraIndex > _numberOfDevices - 1)
                _cameraIndex = 0;
        }

        //set webcame as texture
        webCamTexture = new WebCamTexture(devices[_cameraIndex].name);
        raw.material.SetTexture("_MainTexture", webCamTexture);
        webCamTexture.Play();
    }
}