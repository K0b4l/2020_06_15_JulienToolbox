using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour
{
    public GameObject _colorChangeTarget;
    public Color _startingColor;

    Color _previousColor;

    private void Start()
    {
        _colorChangeTarget.GetComponent<Renderer>().material.color = _startingColor;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _previousColor = _colorChangeTarget.GetComponent<Renderer>().material.color;
            _colorChangeTarget.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }

        if (Input.GetMouseButtonDown(1))
        {
            _colorChangeTarget.GetComponent<Renderer>().material.color = _previousColor;
        }
    }
}
