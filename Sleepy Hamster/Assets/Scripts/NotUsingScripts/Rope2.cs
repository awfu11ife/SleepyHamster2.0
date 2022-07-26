using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Rope2 : MonoBehaviour
{
    [SerializeField] private float _segmentLenght = .25f;
    [SerializeField] private float _ropeWidth = .1f;
    [SerializeField] private int _segmentsCount = 35;
    [SerializeField] private Transform _hook;

    private LineRenderer _lineRenderer;
    private List<RopeSegment> _ropeSegments = new List<RopeSegment>();

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = _hook.position;

        for (int i = 0; i < _segmentsCount; i++)
        {
            _ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= _segmentLenght;
        }
    }

    private void Update()
    {
        DrawRope();
    }

    private void FixedUpdate()
    {
        Simulate();
    }

    private void Simulate()
    {
        Vector2 forceGravity = new Vector2(0f, -1f);

        for (int i = 0; i < _segmentsCount; i++)
        {
            RopeSegment firstSegment = _ropeSegments[i];
            Vector2 velocity = firstSegment.NowPosition - firstSegment.PreviousPosition;
            firstSegment.PreviousPosition = firstSegment.NowPosition;
            firstSegment.NowPosition += velocity;
            firstSegment.NowPosition += forceGravity * Time.deltaTime;
            _ropeSegments[i] = firstSegment;
        }

        for (int i = 0; i < 50; i++)
        {
            ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        RopeSegment firstSegment = _ropeSegments[0];
        firstSegment.NowPosition = _hook.position;

        for (int i = 0; i < _segmentsCount - 1; i++)
        {
            RopeSegment firsSeg = _ropeSegments[i];
            RopeSegment secondSeg = _ropeSegments[i + 1];

            float dist = ((firsSeg.NowPosition - secondSeg.NowPosition).magnitude);
            float error = Mathf.Abs(dist - _segmentLenght);

            Vector2 changeDirecton = Vector2.zero;

            if (dist > _segmentLenght)
            {
                changeDirecton = (firsSeg.NowPosition - secondSeg.NowPosition).normalized;
            }
            else if(dist < _segmentLenght)
            {
                changeDirecton = (secondSeg.NowPosition - firsSeg.NowPosition).normalized;
            }

            Vector2 changeAmount = changeDirecton * error;

            if (i != 0)
            {
                firsSeg.NowPosition -= changeAmount * error;
                _ropeSegments[i] = firsSeg;
                secondSeg.NowPosition += changeAmount * .5f;
                _ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.NowPosition += changeAmount;
                _ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    private void DrawRope()
    {
        float lineWidth = _ropeWidth;
        _lineRenderer.startWidth = lineWidth;
        _lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[_segmentsCount];

        for (int i = 0; i < _segmentsCount; i++)
        {
            ropePositions[i] = _ropeSegments[i].NowPosition;
        }

        _lineRenderer.positionCount = ropePositions.Length;
        _lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector2 NowPosition;
        public Vector2 PreviousPosition;

        public RopeSegment(Vector2 position)
        {
            NowPosition = position;
            PreviousPosition = position;
        }
    }
}
