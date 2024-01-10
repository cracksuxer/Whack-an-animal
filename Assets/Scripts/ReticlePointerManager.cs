using UnityEngine;

public class ReticlePointerManager : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxDistancePointer = 14.5f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float distPointerObject = 0.95f;

    /// <summary>
    /// Mask used to indicate interactive objects.
    /// </summary>
    public LayerMask ReticleInteractionLayerMask = 1 << _RETICLE_INTERACTION_DEFAULT_LAYER;

    /// <summary>
    /// Default layer for interactive game objects.
    /// </summary>
    private const int _RETICLE_INTERACTION_DEFAULT_LAYER = 8;

    /// <summary>
    /// Maximum distance between the camera and the reticle (in meters).
    /// </summary>
    private const float _RETICLE_MAX_DISTANCE = 20.0f;

    /// <summary>
    /// The game object the reticle is pointing at.
    /// </summary>
    private GameObject _gazedAtObject = null;

    private float scaleSize = 0.025f;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    private void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _RETICLE_MAX_DISTANCE))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                if (_gazedAtObject != null)
                    _gazedAtObject.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection();
            }

            bool isInteractive = (1 << _gazedAtObject.layer & ReticleInteractionLayerMask) != 0;
            if (isInteractive)
            {
                PointerOnGaze(hit.point);
            }
            else
            {
                PointerOutGaze();
            }
            
        }
        else
        {
            // No GameObject detected in front of the camera.
            if (_gazedAtObject != null)
                _gazedAtObject.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
            GazeManager.Instance.CancelGazeSelection();
            PointerOutGaze();
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void PointerOnGaze(Vector3 hitPoint)
    {
        float scaleFactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scaleFactor;

        pointer.transform.parent.position = CalculatePointerPosition(transform.position, hitPoint, distPointerObject);
    }

    private void PointerOutGaze()
    {
        // Debug.Log("Mirando un objeto que no es interactivo");
        pointer.transform.localScale = Vector3.one * 0.05f;
        pointer.transform.parent.transform.localPosition = new Vector3(0, 0, maxDistancePointer);
        pointer.transform.parent.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection();
    }

    private Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t * (p1.x - p0.x);
        float y = p0.y + t * (p1.y - p0.y);
        float z = p0.z + t * (p1.z - p0.z);
        return new Vector3(x, y, z);
    }
}
