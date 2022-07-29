using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class NutEater : MonoBehaviour
{
    [SerializeField] private UnityEvent _nutEaten;
    private Collider2D _collider2D;

    public event UnityAction NutEaten
    {
        add => _nutEaten.AddListener(value);
        remove => _nutEaten.RemoveListener(value);
    }

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Nut nut))
        {
            nut.DisableNut();
            _nutEaten?.Invoke();
        }
    }
}
