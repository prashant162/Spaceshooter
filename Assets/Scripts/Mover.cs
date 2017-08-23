using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    private void Start()
    {
        if(speed == 0)
        {
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
