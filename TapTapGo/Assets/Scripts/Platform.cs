using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Rigidbody rb = null;

    private void Awake()
    {
        if (rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Co_PlatformFall());
        }
    }

    private IEnumerator Co_PlatformFall()
    {
        yield return new WaitForSeconds(0.2f);
        rb.isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
