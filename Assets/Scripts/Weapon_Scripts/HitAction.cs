using UnityEngine;

public class HitAction : MonoBehaviour
{
    public string TargetTag;
    public float Damage;
    public float DealDamageDelay = 0.2f;
    
    public GameObject PsOnCollision;
    
    private float _delay = float.MinValue;

    void Update()
    {
        _delay -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TargetTag))
        {
            DealDamage(other.GetComponent<HealthProperty>());

            if (PsOnCollision != null)
            {
                Vector3 psPoint = other.ClosestPoint(transform.position);
                Instantiate(PsOnCollision, psPoint, Quaternion.identity);
            }
        }
    }

    private void DealDamage(HealthProperty health)
    {
        if (_delay <= 0f)
        {
            health.CurrentHealth -= Damage;

            _delay = DealDamageDelay;
        }
    }
}
