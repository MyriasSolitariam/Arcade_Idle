using UnityEngine;

public class RotationHelper : MonoBehaviour
{
    public static void SmoothLookAtTarget(Transform transform, Transform target, float rotationSpeed)
    {
        Vector3 relativePos = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0, relativePos.z), Vector3.up);
        
        float rotationStep = rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationStep);
    }
}
