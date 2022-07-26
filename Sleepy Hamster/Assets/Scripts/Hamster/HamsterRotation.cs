using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterRotation : MonoBehaviour
{
    [SerializeField] private float _smoothing;
    private Quaternion _targetQuaternion;

    private void Start()
    {
        _targetQuaternion = gameObject.GetComponentInParent<Transform>().rotation;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -_targetQuaternion.z), _smoothing * Time.deltaTime);
    }
}
