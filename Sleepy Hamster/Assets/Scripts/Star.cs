using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Star : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected;
    [SerializeField] private GameObject _destroyStarParticle;

    public event UnityAction Collected
    {
        add => _collected.AddListener(value);
        remove => _collected.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ConnectableObject connectableObject))
        {
            Instantiate(_destroyStarParticle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            _collected?.Invoke();
        }
    }
}
