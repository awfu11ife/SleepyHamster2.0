using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectableObject : MonoBehaviour
{
    [SerializeField] private float _distanceFromChainEnd;

    public void ConnectRope(Rigidbody2D lastChain, Vector2 hookPosition)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.anchor = (hookPosition - new Vector2(transform.position.x, transform.position.y)).normalized;
        joint.connectedAnchor = new Vector2(0, -_distanceFromChainEnd);
        joint.connectedBody = lastChain;
    } 
}
