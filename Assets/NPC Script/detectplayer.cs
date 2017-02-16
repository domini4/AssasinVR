using UnityEngine;
using System.Collections;

public class detectplayer : MonoBehaviour {

    public Transform player;
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

        if (!collided)
        {
            Vector3 direction = player.position - this.transform.position;
            float angle = Vector3.Angle(direction, this.transform.forward);
            if (AKMShoot.Globals.GunFired)
            {
                direction.y = 0;

                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 0.1f);
                anim.SetBool("isIdle", false);
                if (direction.magnitude > 2)
                {
                    this.transform.Translate(0, 0, 0.05f);
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isAttack", false);
                }
                else
                {
                    anim.SetBool("isAttack", true);
                    anim.SetBool("isWalking", false);
                }

            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttack", false);
            }

        }

    }
}
