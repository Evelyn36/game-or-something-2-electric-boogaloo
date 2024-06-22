using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivot_rotation : MonoBehaviour
{

    private attack_sword sword;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponentInParent<attack_sword>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (sword.isAttacking == false)
        {
            

            Vector3 MousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3.6f));

            if (MousePos.y - 0.2f < transform.position.y  && transform.position.y < MousePos.y + 0.2f)
            {
               
            }
            
            else if (MousePos.y > transform.position.y)
            {
                MousePos.y += 0.5f;

            }
            else if (MousePos.y < transform.position.y)
            {
                MousePos.y -=0.5f;
            }

            Vector3 targetDir = MousePos - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }
}
