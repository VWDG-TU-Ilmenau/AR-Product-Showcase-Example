using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public InputAction touchInput;
    public Slider RotationSlider;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void OnEnable()
    {
        touchInput.Enable();
    }

    private void OnDisable()
    {
        touchInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchInput.triggered)
        {
            Vector2 touchPosition = touchInput.ReadValue<Vector2>();

            if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                ProductSpawnManager.Instance.SpawnProduct(hitPose);
            }
        }
    }

    public void RotateProduct()
    {
        if (ProductSpawnManager.Instance.CurrentProduct == null)
            return;
            
        ProductSpawnManager.Instance.CurrentProduct.transform.eulerAngles = new Vector3(0f, RotationSlider.value, 0f);
    }
}
