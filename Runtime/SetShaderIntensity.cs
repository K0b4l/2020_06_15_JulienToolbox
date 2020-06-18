using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderIntensity : MonoBehaviour
{
    private Material _mat;

    private void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }
}
