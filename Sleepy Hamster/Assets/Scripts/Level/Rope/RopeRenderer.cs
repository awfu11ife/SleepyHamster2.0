using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RopeRenderer : MonoBehaviour
{
    private List<Transform> _links = new List<Transform>();
    private Transform _connectedObject;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        //if (gameObject.TryGetComponent(out RopeCreator ropeCreator))
            //_connectedObject = ropeCreator.ConnectableObject.transform;
    }

    private void Start()
    {
        UpdateListOfLinks();

        //if (_connectedObject != null)
            //_links.Add(_connectedObject);
    }

    private void Update()
    {
        DrawRope(_links);
    }

    public void UpdateListOfLinks()
    {
        _links.Clear();

        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.TryGetComponent(out Link link))
                _links.Add(child);
        }
    }

    public void DrawRope(List<Transform> links)
    {
        _lineRenderer.positionCount = links.Count;

        for (int i = links.Count - 1; i >= 0; i--)
        {
            if (links[i] != null)
            {
                _lineRenderer.SetPosition(i, links[i].position);
            }
        }
    }
}
