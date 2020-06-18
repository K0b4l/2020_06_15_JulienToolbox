using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovementOfTarget : MonoBehaviour
{
    public float _speed = 10;
    int multiplier = 1;

    private void Update()
    {
        MoveBackForth();
    }

    void MoveBackForth()
    {
        if (transform.position.x >= 10)
        {
            multiplier = -1;
        }
        if (transform.position.x <= -10)
        {
            multiplier = 1;
        }
        transform.Translate(transform.right * _speed * Time.deltaTime *multiplier);
    }
}
