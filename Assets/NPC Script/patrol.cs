using UnityEngine;
using System.Collections;

public class patrol : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    Animator anim;
    private bool collided = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GotoNextPoint();

    }

    // Update on collide
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ball")
        {
            collided = true;
        }
    }

    void GotoNextPoint()
    {
		if (!collided) {
			// Returns if no points have been set up
			if (points.Length == 2)
				return;

			// Set the agent to go to the currently selected destination.
			agent.destination = points [destPoint].position;

			// Choose the next point in the array as the destination,
			// cycling to the start if necessary.
			destPoint = (destPoint + 1) % points.Length;

		}
    }

    // Update is called once per frame
    void Update()
    {
		if (collided == false) {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isDie", false);
			anim.SetBool ("isAttack", false);
			anim.SetBool ("isPatrol", true);
			if (agent.remainingDistance < 0.5f)
				GotoNextPoint ();
		} else {
			agent.speed = 0;
		}

    }
}
