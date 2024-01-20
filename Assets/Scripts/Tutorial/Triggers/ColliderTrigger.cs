using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : TutorialTrigger
{
    public Collider myCollider;
    [SerializeField]
    private GameObject collisionTriggerer;

    public override void Start()
    {
        base.Start();
        myCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (active)
        {
            myCollider.enabled = true;
        }
        else
        {
            myCollider.enabled = false;
        }
    }
    public virtual void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == collisionTriggerer.name)
        {
            Trigger();
        }
    }
}
