using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float pullSpeed = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Coins"))
            return;

        
        // Detach from path so movement is visible
        if (other.transform.parent != null)
            other.transform.SetParent(null);

        // Pull coin toward player
        other.transform.position = Vector3.MoveTowards(
            other.transform.position,
            transform.parent.position,
            pullSpeed * Time.deltaTime
        );
    }
}
