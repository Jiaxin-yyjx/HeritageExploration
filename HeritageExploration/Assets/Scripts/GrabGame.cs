using UnityEngine;

public class GrabGame : MonoBehaviour
{
    private GameObject grabbedObject;
    private bool isGrabbing = false;
    private Vector3 originalScale;

    void Update()
    {
        // Check for input from the Oculus Touch controller (A button)
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.5f) // "A" button on the right controller
        {
            if (!isGrabbing)
            {
                // If not currently grabbing, try to grab an object
                TryGrabObject();
            }
        }
        else
        {
            if (isGrabbing)
            {
                // If currently grabbing, release the object
                ReleaseObject();
            }
        }
        if (isGrabbing)
        {
            // Get input from the secondary thumbstick
            float thumbstickX = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;

            if (thumbstickX < -0.5f) // If thumbstick moved left
            {
                // Scale down the object
                ScaleObject(0.95f); // Decrease scale by 5% (adjust as needed)
            }
            else if (thumbstickX > 0.5f) // If thumbstick moved right
            {
                // Scale up the object
                ScaleObject(1.05f); // Increase scale by 5% (adjust as needed)
            }
        }
    }

    void TryGrabObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Grabbable"))
            {
                grabbedObject = hit.collider.gameObject;
                grabbedObject.transform.SetParent(transform); // Make the object a child of the hand controller
                isGrabbing = true;
            }
        }
    }

    void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.SetParent(null); // Unparent the object from the hand controller
            grabbedObject = null;
            isGrabbing = false;
        }
    }
    void ScaleObject(float scaleFactor)
    {
        if (grabbedObject != null)
        {
            // Get the current scale of the object
            Vector3 currentScale = grabbedObject.transform.localScale;

            // Scale the object uniformly in all dimensions
            Vector3 newScale = currentScale * scaleFactor;

            // Apply the new scale to the object
            grabbedObject.transform.localScale = newScale;
        }
    }
}
