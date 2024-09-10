using System;
using UnityEngine;

public class LeverInteract : MonoBehaviour, IInteractable
{
    public void Start()
    {
        GameManager.Instance.levers.Add(this);
    }
    public void Update()
    {
        //Debug.Log(GameManager.Instance.player);
    }
    public void OnClick()
    {
        this.GetComponent<Collider>().enabled = false;
        GameManager.Instance.LeverActivated();
    }
}
