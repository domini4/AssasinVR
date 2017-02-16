using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {

    Animator anim;
    private bool collided = false;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();

    }

    // Update on collide
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ball")
        {
            collided = true;
        }
    }

    // Update is called once per frame
    void Update () {


		if (collided)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isDie", true);
        }

    }


}
