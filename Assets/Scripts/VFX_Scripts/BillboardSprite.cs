using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    private Camera _mainCamera;
    
    void Awake()
    {
        _mainCamera = Camera.main;     
    }
    
    void Update()
    {
        transform.LookAt(_mainCamera.transform, Vector3.up);
    }
}
