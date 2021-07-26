using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Transform finishPoint;

    private Camera cam;

    private NavMeshAgent agent;
    private Animator anim;

    private bool isMoving = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.desiredVelocity == Vector3.zero)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }

        anim.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            anim.speed = agent.velocity.magnitude / agent.speed;
        }
        else
        {
            anim.speed = 1;
        }
        
    }

    public void RunToFinish()
    {
        agent.SetDestination(finishPoint.position);
    }
}
