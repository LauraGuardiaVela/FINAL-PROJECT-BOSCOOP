using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPosition : MonoBehaviour
{
    public Vector3 targetPosOffset;
    public float timeToReachTarget;
    private Vector3 startPos;
    private Vector3 targetPos;
    private float percentMoved;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = transform.position + targetPosOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentMoved < 1f)
        {
            percentMoved += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPos, targetPos, percentMoved);
        }
    }
}
