using UnityEngine;
using System.Collections;

public class DestroyOnBoundaryLeave : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
