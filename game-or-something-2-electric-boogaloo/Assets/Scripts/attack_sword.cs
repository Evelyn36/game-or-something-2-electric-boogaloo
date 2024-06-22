using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_sword : MonoBehaviour
{

    [SerializeField] private GameObject sword;



    private GameObject Sword;

    public bool isAttacking = false;

    public int attackCounter;

    private player_movement movement;

    public int MaxAttackLength;

    private bool canBuffer = false;


    private Animator attackAnim;

    private GameObject pivot;

    private Sword_Damage sword_knock;
    private float default_knockback;

    private float attackMovement;

    private void Start()
    {
        movement = GetComponent<player_movement>();
        attackMovement = movement.AttackingMovementPercentage;
        pivot = GameObject.Find("Pivot point");

    }

    void Update()
    {

        

        if (Input.GetMouseButtonDown(1) && isAttacking == false)
        {

            if (canBuffer)
            {
                attackCounter++;

            }

            Sword = Instantiate(sword, gameObject.transform.position, Quaternion.identity, pivot.transform);
            attackAnim = Sword.GetComponent<Animator>();
            
            sword_knock = Sword.GetComponentInChildren<Sword_Damage>();


            StartCoroutine(wait(Sword));
        }

        if (canBuffer == false || attackCounter > MaxAttackLength)
        {

            attackCounter = 0;
        }


        if (Sword != null)
        {
            attackAnim.SetInteger("Counter", attackCounter);
        }


        if (attackCounter == 2)
        {
            movement.AttackingMovementPercentage = 1.1f;

        }
        else
        {
            movement.AttackingMovementPercentage = attackMovement;
        }



    }

    private IEnumerator wait(GameObject Sword)
    {

        isAttacking = true;
        movement.isAttacking = true;
        yield return new WaitForSeconds(0.25f);

        if (!canBuffer)
        {

            StartCoroutine(AttackBuffer());
        }


        movement.isAttacking = false;
        isAttacking = false;
    }


    private IEnumerator AttackBuffer()
    {
        canBuffer = true;
        yield return new WaitForSeconds(2f);
        attackCounter = 0;
        canBuffer = false;

    }


}
