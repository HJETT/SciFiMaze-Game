using System;
using UnityEngine;

public class LeverInteract : MonoBehaviour, IInteractable
{
    [SerializeField] Animator animator;

    public void Start()
    {
        GameManager.Instance.levers.Add(this);
    }

    public void OnClick()
    {
        this.GetComponent<Collider>().enabled = false;
        GameManager.Instance.LeverActivated();
        animator.SetTrigger("Open");
    }
}
