using UnityEngine;

public class FireWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullets")
        {
            Destroy(other.gameObject);
        }
    }
}
