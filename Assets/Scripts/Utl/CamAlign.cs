using UnityEngine;

/// <summary>
/// Aligns transform to the camera.
/// </summary>
namespace DungeonCrawler.Utl
{
    public class AlignCam : MonoBehaviour
    {
        private Camera mainCam;

        // Start is called before the first frame update
        void OnEnable()
        {
            mainCam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (mainCam != null)
            {
                Transform camTransform = mainCam.transform;
                transform.LookAt(transform.position + camTransform.forward);
            }
        }
    }
}