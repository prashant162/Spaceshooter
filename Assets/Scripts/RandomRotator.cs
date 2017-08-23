using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
