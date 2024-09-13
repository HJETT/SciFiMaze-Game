using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class LightScript : MonoBehaviour
{
    [SerializeField]
    private Light _light;

    [SerializeField]
    private Material material;

    private Material _mat;

    private void Start()
    {
        var renderer = GetComponent<MeshRenderer>();
        
        for (int i = 0; i < renderer.materials.Length; i++)
        {
            if (renderer.materials[i].name.StartsWith(material.name))
            {
                _mat = renderer.materials[i];
                break;
            }
        }
    }

    public void SetColor(Color color)
    {
        _light.color = color;
        _mat.SetColor("_EmissionColor", color * Mathf.LinearToGammaSpace(2f));
    }
}
