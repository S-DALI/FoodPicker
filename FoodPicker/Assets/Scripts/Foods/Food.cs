using UnityEngine;

public class Food : MonoBehaviour
{
    public bool IsTaked;
    private void Start()
    {
        IsTaked = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GarbegCollector")
        {
            Destroy(gameObject);
        }
    }
}
