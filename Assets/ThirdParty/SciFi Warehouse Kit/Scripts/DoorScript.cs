using UnityEngine;

public class DoorScript : MonoBehaviour
{
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

        SetLight(lightColor.Evaluate(currentPos));
    }

    public void SetPosition(float position)
    {
        position = Mathf.Clamp01(position);
        targetPos = position;
    }

    #region Lights

    [Header("Lights")]
    [SerializeField]
    private LightScript[] lights;

    [SerializeField]
    private Gradient lightColor;

    private void SetLight(Color color)
    {
        foreach (var item in this.lights)
            item.SetColor(color);
    }

    #endregion
}
