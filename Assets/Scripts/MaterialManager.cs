using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    private Renderer[] _renderers;
    public Material _currentMaterial;

    private void Start() => _renderers = GetComponentsInChildren<Renderer>(true);

    public void SetMaterial(Material material) 
    {
        _currentMaterial = material;
        foreach(var renderer in _renderers) renderer.material = material;
    }

    public Material GetMaterial() { return _currentMaterial; }
}
