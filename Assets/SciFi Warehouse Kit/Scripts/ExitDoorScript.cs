using System;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorScript : MonoBehaviour
{
    #region Lights

    [SerializeField]
    public Gradient lightColor;
    public List<LightScript> lights = new List<LightScript>();
    
    public void ActivateLights(int nbLeverActivated)
    {
        for(int i = 0; i < nbLeverActivated; i++)
        {
            lights[i].SetColor(lightColor.Evaluate(1));
        }
    }

    #endregion

    #region Animation

    public void OpenDoor() => this.targetPos = 1f;

    [SerializeField]
    private Vector3 minPos;

    [SerializeField]
    private Vector3 maxPos;

    [SerializeField]
    private Transform moveTransform;

    private float currentPos;

    [SerializeField, Range(0, 1)]
    private float targetPos;

    [SerializeField, Min(0)]
    private float speed = 1;

    private void Update()
    {
        if (currentPos == targetPos)
            return;

        float step = Time.deltaTime * Mathf.Sign(targetPos - currentPos) * speed;

        if (step > 0 && currentPos + step > targetPos)
            currentPos = targetPos;
        else if (step < 0 && currentPos + step < targetPos)
            currentPos = targetPos;
        else
            currentPos += step;

        currentPos = Mathf.Clamp01(currentPos);

        moveTransform.localPosition = Vector3.Lerp(
            minPos,
            maxPos,
            currentPos
        );
    }

    #endregion

    #region Trigger

    private void OnTriggerEnter(Collider other) => GameManager.Instance.NextLevelSequence();
    
    #endregion
}
