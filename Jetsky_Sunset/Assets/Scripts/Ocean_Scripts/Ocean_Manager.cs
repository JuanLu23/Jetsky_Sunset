using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean_Manager : MonoBehaviour
{

    public float waveHeight = 0.5f;

    public float waveFrequency = 1f;

    public float waveSpeed = 1f;

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
        _oceanMaterial = GetComponent<Renderer>().sharedMaterial;
        _displacementWaves = (Texture2D)_oceanMaterial.GetTexture("_Wave_Displacement_Map");
    }

    public float WaterHeightAtPosition(Vector3 _position)
    {
        return _ocean.position.y + _displacementWaves.GetPixelBilinear(_position.x * waveFrequency, _position.z * waveFrequency + Time.time * waveSpeed).g * waveHeight * _ocean.localScale.x;
    }

    private void OnValidate()
    {
        if (!_oceanMaterial)
        {
            SetVariables();
        }

    }

    void UpdateMaterial()
    {

    }
}
