using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindController : MonoBehaviour
{
    [SerializeField] private GameObject _blindOverlay;

    [Header("Light")]
    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _nightLight;
    [SerializeField] private GameObject _lightBulb;

    [Header("Skybox")]
    [SerializeField] private Material _daySkybox;
    [SerializeField] private Material _nightSkybox;

    [Header("Lamp")]
    [SerializeField] private MeshRenderer _lamp;
    [SerializeField] private Material _lampOnMaterial;
    [SerializeField] private Material _lampOffMaterial;

    [Header("TV")]
    [SerializeField] private MeshRenderer _tvScreen;
    [SerializeField] private Material _tvOnMaterial;
    [SerializeField] private Material _tvOffMaterial;

    private bool _isNight = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleDayNight();
        }
    }

    private void ToggleDayNight()
    {
        _isNight = !_isNight;

        // Overlay
        _blindOverlay.SetActive(!_isNight);

        // Lights
        _nightLight.SetActive(_isNight);
        _light.SetActive(!_isNight);
        _lightBulb.SetActive(!_isNight);

        // Lamp
        _lamp.material = _isNight ? _lampOffMaterial : _lampOnMaterial;

        // TV (handle multiple material slots safely)
        Material[] mats = _tvScreen.materials;
        mats[1] = _isNight ? _tvOffMaterial : _tvOnMaterial;
        _tvScreen.materials = mats;

        // Skybox
        RenderSettings.skybox = _isNight ? _nightSkybox : _daySkybox;
        DynamicGI.UpdateEnvironment();
    }
}