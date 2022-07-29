using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Link : MonoBehaviour
{
    [SerializeField]private bool _isAbleToRemove = true;

    public bool IsAbleToRemove => _isAbleToRemove;

    public void SetDisableToCut()
    {
        _isAbleToRemove = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
    }
}
