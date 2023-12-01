using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{

    public GameObject StopSign;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public AudioClip attackSound;
    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if (canAttack)
            {
                SignAttack();
            }
        }
    }

    public void SignAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = StopSign.GetComponent<Animator>();
        anim.SetTrigger("attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(attackSound);
        StartCoroutine(resetAttackCooldown());
    }

    
    IEnumerator resetAttackCooldown()
    {
        StartCoroutine(resetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator resetAttackBool()
    {
        yield return new WaitForSeconds(20.0f);
        isAttacking = false;
    }
}
