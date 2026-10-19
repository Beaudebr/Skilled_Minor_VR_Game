using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int HP;

    public Animator animator;

    private bool isHit = false;

    private void Start()
    {
        animator = GetComponent<Animator>();

        animator.enabled = true;
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

        if(HP <= 0)
        {
            animator.enabled = false;
        }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1);
        isHit = false;
    }
}
