using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoEffectsControls : MonoBehaviour
{
    public float PixelationRate = 1.25f;

    private Material _mat;

    private float _pixelation = 200;

    // Start is called before the first frame update
    private void Start()
    {
        _mat = GetComponent<RawImage>().material;
    }

    // Update is called once per frame
    private void Update()
    {
        //guard statement if material doesn't exist
        if (_mat == null) return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _pixelation = (_pixelation + 1) * PixelationRate;
            _pixelation = (int)Mathf.Clamp(_pixelation, 2, 200); //these numbers should match the max and min on the shader
            _mat.SetFloat("_Pixelation", _pixelation);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _pixelation = (_pixelation / PixelationRate) - 1;
            _pixelation = (int)Mathf.Clamp(_pixelation, 2, 200); //these numbers should match the max and min on the shader
            _mat.SetFloat("_Pixelation", _pixelation);
        }
    }
}