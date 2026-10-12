using UnityEngine;

public class Damager : MonoBehaviour
{
    public int damageAmount;

    public Vector3 Velocity { get; private set; }
    public float Speed => Velocity.magnitude;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        Velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }
}
