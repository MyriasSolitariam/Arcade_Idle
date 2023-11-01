using UnityEngine;

public class PickUpRecoursesAction : MonoBehaviour
{
    private PlayerInventory _inventory;

    [SerializeField] private string[] _pickUpTags;
    [SerializeField] private string[] _pickUpInventoryKey;

    void Awake()
    {
        _inventory = GetComponent<PlayerInventory>();
    }

    private void OnParticleCollision(GameObject other)
    {
        PickUpRecourse(other);
    }

    private void PickUpRecourse(GameObject other)
    {
        for (int i = 0; i < _pickUpTags.Length; i++)
        {
            if (other.gameObject.CompareTag(_pickUpTags[i]))
            {
                Destroy(other);
                _inventory.RecoursesStorage[_pickUpInventoryKey[i]] += 1;
                _inventory.TotalRecoursesStorage[_pickUpInventoryKey[i]] += 1;
            }
        }
    }
}
