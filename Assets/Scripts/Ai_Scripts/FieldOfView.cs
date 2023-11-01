using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float ViewRadius;
    [Range(0, 360)] public float ViewAngle;
    public LayerMask TargetMask;
    public LayerMask ObstacleMask;
    [HideInInspector] public List<Transform> VisibleTargets = new List<Transform>();
    
    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        VisibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, ViewRadius, TargetMask);
        
        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < ViewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, ObstacleMask))
                {
                    VisibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    
    public Transform ClosestTarget()
    {
        Transform closestTarget = transform;

        float currentDst;
        float lowestDst = float.MaxValue;

        foreach (var target in VisibleTargets)
        {
            float dst = Vector3.Distance(target.position, transform.position);
            currentDst = dst;

            if (currentDst < lowestDst)
            {
                lowestDst = currentDst;
                closestTarget = target;
            }
        }
        
        return closestTarget;
    }
}