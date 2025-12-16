using UnityEngine;

/// <summary>
/// This class generate an outline for a mesh by simply duplicating the mesh
/// with an unlid pure color material, scale it up a little and move it a little
/// away from the camera.
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class OutlineController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    [SerializeField]
    private Camera outlineCamera;
    [SerializeField]
    private Vector3 thickness = new Vector3(0.1f,0.1f,0.1f);
    [SerializeField]
    private float offset;
    [SerializeField]
    private MeshRenderer outLineMeshRenderer;
    [SerializeField]
    private Material outlineMaterial;

    public void SetOutlineActive(bool active)
    {
        if (active) {
            GenerateOutline();
        }
        else
        {
            if (outLineMeshRenderer != null)
            {
                Destroy(outLineMeshRenderer.gameObject);
            }
        }
    }

    private void GenerateOutline()
    {
        if(outLineMeshRenderer!= null)
        {
            Destroy(outLineMeshRenderer.gameObject);
        }
        if (outlineCamera == null)
        {
            outlineCamera = Camera.main;
        }
        meshRenderer = GetComponent<MeshRenderer>();
        outLineMeshRenderer = Instantiate<MeshRenderer>(meshRenderer);
        //Destroy OutlinController from the newly created object to avoid recursive calling
        Destroy(outLineMeshRenderer.gameObject.GetComponent<OutlineController>());
        outLineMeshRenderer.transform.position = transform.position;
        outLineMeshRenderer.transform.rotation = transform.rotation;
        outLineMeshRenderer.transform.position += (offset * (transform.position - outlineCamera.transform.position).normalized);
        Vector3 scale = outLineMeshRenderer.transform.localScale;
        outLineMeshRenderer.transform.localScale =
            new Vector3(scale.x * (1 + thickness.x), scale.y * (1 + thickness.y), 1f);
        outLineMeshRenderer.transform.SetParent(transform);
        outLineMeshRenderer.material = outlineMaterial;
    }


}
