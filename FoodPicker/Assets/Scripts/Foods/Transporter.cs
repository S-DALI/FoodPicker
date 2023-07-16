using UnityEngine;

public class Transporter : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float speedTexture = 10f;
    [SerializeField] private Material material;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            material.mainTextureOffset = new Vector2(material.mainTextureOffset.x, Time.time * speedTexture * Time.fixedDeltaTime);
            float trasporterVelocity = speed * Time.fixedDeltaTime;
            collision.gameObject.GetComponent<Rigidbody>().velocity = trasporterVelocity * transform.forward;
        }
    }
}
