using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DetectInRangePlayerVision : MonoBehaviour
{
    GameObject userView;
    public GameObject[] objectTarget;
    Transform given;
    bool found;

    Vector3[] objectDirection;

    [SerializeField]
    float _shaderApparitionAngle = 100f;

    float _MaxAngle = 180f;

    public UnityEvent OnWithinSight;

    private Material[] _mat;


    private void Update()
    {
        objectTarget = IsHighlighTag.GetAllHighlightable().Select(k => k.gameObject).ToArray();
        _mat = new Material[objectTarget.Length];

        userView = this.gameObject;
        for (int i = 0; i < objectTarget.Length; i++)
        {
            _mat[i] = objectTarget[i].GetComponent<Renderer>().material;

            objectDirection[i] = objectTarget[i].transform.position - userView.transform.position;
            VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.EyesCenter, out found, out given);

            CheckAngle(i);
        }        
    }

    private void CheckAngle(int index)
    {
        Quaternion localQuaternionOfObject = Quaternion.LookRotation(objectDirection[index], given.up);
        float angle = Quaternion.Angle(given.rotation, localQuaternionOfObject);

        SetShaderIntensity(angle, index);
    }

    private void SetShaderIntensity(float angle, int index)
    {
        if (angle >= _shaderApparitionAngle)
        {
            Switchhighlighted(true, angle, index);
        }
        else Switchhighlighted(false, angle, index);
    }

    void Switchhighlighted(bool highlighted, float angle, int index)
    {
        _mat[index].SetFloat("_Highlighted", (highlighted ? AngleToLerp(angle) : 0.0f));
    }

    float AngleToLerp(float lerpedAngle)
    {
        return Mathf.InverseLerp(_shaderApparitionAngle, _MaxAngle, lerpedAngle);
    }
}
