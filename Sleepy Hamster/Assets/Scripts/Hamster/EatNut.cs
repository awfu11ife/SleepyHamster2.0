using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EatNut : MonoBehaviour
{
    [SerializeField] private UnityEvent _nutEaten;

    public event UnityAction NutEaten
    {
        add => _nutEaten.AddListener(value);
        remove => _nutEaten.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ConnectableObject connectableObject))
        {
            Destroy(collision.gameObject);
            _nutEaten?.Invoke();
        }
    }
}
