using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int HP;

    public Animator animator;

    private bool isHit = false;

    private Rigidbody[] rigidbodies;

    public Transform enemyRoot;

    private bool isDead = false;

    private void Awake()
    {
        rigidbodies = enemyRoot.GetComponentsInChildren<Rigidbody>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();

        animator.enabled = true;

        isDead = false;
    }

    public void TakeHit(Damager damager, bool isHead)
    {
        if (damager.Speed < 2.5f)
            return;

        if (isHead && !isHit)
        {
            isHit = true;
            animator.SetTrigger("GotHitHead");

            HP -= damager.damageAmount * 2;
        }
        if(!isHead && !isHit)
        {
            isHit = true;
            animator.SetTrigger("GotHit");

            HP -= damager.damageAmount;
        }

        Debug.Log(isHead ? "HEAD HIT" : "BODY HIT");
    }

    private void Update()
    {
        if (isHit)
        {
            StartCoroutine(AttackDelay());
        }

        if(HP <= 0 && !isDead)
        {
            isDead = true;
            animator.enabled = false;
            foreach(Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.linearVelocity = Vector3.zero;
            }
        }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1);
        isHit = false;
    }
}
