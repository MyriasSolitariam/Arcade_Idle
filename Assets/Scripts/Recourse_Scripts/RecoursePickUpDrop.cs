using UnityEngine;

public class RecoursePickUpDrop : MonoBehaviour
{
    [SerializeField] private GameObject _pickUpRecoursePS;
    [SerializeField] private int _minRecourses, _maxRecourses;

    public void InstantiatePickUpRecourse()
    {
        int numberOfRecourses = Random.Range(_minRecourses, _maxRecourses + 1);

        for (int i = 0; i < numberOfRecourses; i++)
        {
            Instantiate(_pickUpRecoursePS, transform.position, Quaternion.identity);
        }
    }
}
