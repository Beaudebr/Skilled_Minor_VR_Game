using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public EnemyBehaviour enemy;
    public bool isHead;

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();

        if (damager == null)
            return;

        enemy.TakeHit(damager, isHead);
    }
}
