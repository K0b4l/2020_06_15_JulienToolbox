using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycast : MonoBehaviour
{
    public LayerMask _layer;

    public float _distance;

    RaycastHit _raycastHit;

    public UnityEvent OnCastHit;
    public UnityEvent OnCastMiss;

    public void Update()
    {
        Cast();
    }

    public void Cast()
    {
        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out _raycastHit, _distance, _layer))
        {
            OnCastHit.Invoke();
        }
        else
        {
            OnCastMiss.Invoke();
        }
    }

    protected bool CheckLayer(int layer)
    {
        return _layer == (_layer | (1 << layer));
    }
}