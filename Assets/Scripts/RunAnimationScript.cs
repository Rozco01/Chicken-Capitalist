using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimationScript : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("speed", true);
        }
        else
        {
            animator.SetBool("speed", false);

        }
    }
}
