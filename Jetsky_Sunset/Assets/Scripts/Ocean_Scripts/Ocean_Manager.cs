using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean_Manager : MonoBehaviour
{

    public float waveHeight;

    public float waveFrequency;

    public float waveSpeed;

    public Transform _ocean;

    Material _oceanMaterial;
    Texture2D _displacementWaves;


    // Start is called before the first frame update
    void Start()
    {
        SetVariables();
    }

    void SetVariables()
    {
        _oceanMaterial = _ocean.GetComponent<Renderer>().sharedMaterial;
        _displacementWaves = (Texture2D)_oceanMaterial.GetTexture("_Wave_Displacement_Map");
    }

    public float WaterHeightAtPosition(Vector3 _position)
    {
        return _ocean.position.y + _displacementWaves.GetPixelBilinear(_position.x * waveFrequency/100, _position.z * waveFrequency/100 + Time.time * waveSpeed/100).g * waveHeight/100 * _ocean.localScale.x;
    }

    void OnValidate()
    {
        if (!_oceanMaterial)
        {
            SetVariables();
        }
        UpdateMaterial();

    }

    void UpdateMaterial()
    {
        _oceanMaterial.SetFloat("_Waves_Frequency", waveFrequency/100);
        _oceanMaterial.SetFloat("_Waves_Speed", waveSpeed/100);
        _oceanMaterial.SetFloat("_Wave_Height", waveHeight/100);
    }
}
