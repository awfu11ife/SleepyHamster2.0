using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RopeCutter : MonoBehaviour
{
    [SerializeField] private GameObject _connectedObjectRopeRendererTemplate;

    private List<Transform> _links = new List<Transform>();
    private List<Transform> _cutLinks = new List<Transform>();
    private GameObject _currentConnectedObject;
    private GameObject _currentConnectedObjectRopeRenderer;
    private RopeRenderer _currentRopeRenderer;
    private bool _isCut = false;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Cut();
        }

        if (_isCut == true)
        {
            SplitRope();
            _currentRopeRenderer.UpdateListOfLinks();
            _currentConnectedObjectRopeRenderer.GetComponent<RopeRenderer>().UpdateListOfLinks();
        }
    }

    private void DestoryLink(Link link)
    {
        Destroy(link.gameObject);
        link.GetComponentInParent<RopeDestroyer>().DisableRope();
        _currentConnectedObjectRopeRenderer.GetComponent<RopeDestroyer>().DisableRope();
    }

    private void GetLinks(Link link)
    {
        _currentConnectedObject = link.GetComponentInParent<RopeCreator>().ConnectableObject.gameObject;
        var parent = link.transform.parent.gameObject; 

        foreach (var child in parent.GetComponentsInChildren<Transform>())
        {
            _links.Add(child);
        }
    }

    private void Cut()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.TryGetComponent(out Link link))
        {
            if (link.IsAbleToRemove == true)
            {
                _currentRopeRenderer = link.GetComponentInParent<RopeRenderer>();
                GetLinks(link);
                _currentConnectedObjectRopeRenderer = Instantiate(_connectedObjectRopeRendererTemplate, _currentConnectedObject.transform);
                DestoryLink(link);
                _isCut = true;
            }
        }
    }

    private void SplitRope()
    {
        for (int i = 0; i < _links.Count; i++)
        {
            if (_links[i] == null)
            {
                if (i < _links.Count - 1)
                {
                    _links[i + 1].transform.parent = _currentConnectedObjectRopeRenderer.transform;
                    _links.RemoveAt(i + 1);
                }
            }
        }

        if (_links[_links.Count - 1] == null)
        {
            _links.RemoveAt(_links.Count - 1);
            _isCut = false;
        }
    }
}
