using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class RopeCreator : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _hook;
    [SerializeField] private GameObject _linkPrefab;
    [SerializeField] private int _numberOfLinks;
    [SerializeField] private ConnectableObject _connectableObject;

    public ConnectableObject ConnectableObject => _connectableObject;

    private void Awake()
    {
        CreateRope();
    }

    private void CreateRope()
    {
        Rigidbody2D previousRB = _hook;

        for (int i = 0; i < _numberOfLinks; i++)
        {
            GameObject link = Instantiate(_linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if (i < _numberOfLinks - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                _connectableObject.ConnectRope(link.GetComponent<Rigidbody2D>(), transform.position);
            }
        }
    }
}
