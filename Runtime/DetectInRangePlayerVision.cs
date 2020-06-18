using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectInRangePlayerVision : MonoBehaviour
{
    GameObject userView; 
    public GameObject objectTarget; 
    Transform given; 
    bool found;

    Vector3 objectDirection;

    [SerializeField]
    float _shaderApparitionAngle = 100f;

    float _MaxAngle = 180f;

    Material objectShader;
    public UnityEvent OnWithinSight;

    private Material _mat;

    private void Start()
    {
        userView = this.gameObject;
        _mat = GetComponent<Renderer>().material;
    }

    private void Awake()
    {
        objectShader = objectTarget.GetComponent<Renderer>().material;
        objectDirection = objectTarget.transform.position - userView.transform.position;
        VirtualRealityTags.GetClassicVrTag(VirtualRealityClassicTags.EyesCenter, out found, out given);
        
        CheckAngle();
    }

    private void CheckAngle()
    {
        Quaternion localQuaternionOfObject = Quaternion.LookRotation(objectDirection, given.up); 
        float angle = Quaternion.Angle(given.rotation, localQuaternionOfObject);

        SetShaderIntensity(angle);
    }

    private void SetShaderIntensity(float angle)
    {
        if ( angle >= _shaderApparitionAngle)
        {
            Switchhighlighted(true, angle);
        }
        else Switchhighlighted(false, angle);
    }

    void Switchhighlighted(bool highlighted, float angle)
    {
        _mat.SetFloat("_Highlighted", (highlighted ? AngleToLerp(angle) : 0.0f));
    }

    float AngleToLerp(float lerpedAngle)
    {
        return Mathf.InverseLerp(_shaderApparitionAngle, _MaxAngle, lerpedAngle);
    }
}
