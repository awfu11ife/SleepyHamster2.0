using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursoreMover : MonoBehaviour
{
    [SerializeField] private float _distanceFromCamera;
    [SerializeField] private GameObject _trail;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distanceFromCamera));
            _trail.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _trail.SetActive(false);
        }
    }
}
