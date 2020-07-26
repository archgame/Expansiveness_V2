using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWebCam : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled, // 0 for no sync, 1 for panel refresh rate, 2 for 1/2 panel rate
        Application.targetFrameRate = 45;
    }

    // Start is called before the first frame update
    private void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        // for debugging purposes, prints available devices to the console
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Webcam available: " + devices[i].name);
        }

        Renderer rend = this.GetComponentInChildren<Renderer>();
        Image image = this.GetComponentInChildren<Image>();
        RawImage raw = this.GetComponentInChildren<RawImage>();
        // assuming the first available WebCam is desired
        WebCamTexture tex = new WebCamTexture(devices[0].name);
        if (rend != null)
            rend.material.mainTexture = tex;
        if (image != null)
            image.material.mainTexture = tex;
        if (raw != null)
            raw.material.mainTexture = tex;
        tex.Play();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}