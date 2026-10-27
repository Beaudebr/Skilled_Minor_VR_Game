using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GunHandPose : MonoBehaviour
{
    [Header("Interactors")]
    public XRDirectInteractor leftHandInteractor;
    public XRDirectInteractor rightHandInteractor;

    [Header("Hand Models")]
    public GameObject leftHandNormal;
    public GameObject rightHandNormal;

    [Header("Grab Pose Models")]
    public GameObject leftHandGrabPose;
    public GameObject rightHandGrabPose;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        ResetHands();
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (args.interactorObject == leftHandInteractor)
        {
            leftHandNormal.SetActive(false);
            leftHandGrabPose.SetActive(true);
        }
        else if (args.interactorObject == rightHandInteractor)
        {
            rightHandNormal.SetActive(false);
            rightHandGrabPose.SetActive(true);
        }
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (args.interactorObject == leftHandInteractor)
        {
            leftHandNormal.SetActive(true);
            leftHandGrabPose.SetActive(false);
        }
        else if (args.interactorObject == rightHandInteractor)
        {
            rightHandNormal.SetActive(true);
            rightHandGrabPose.SetActive(false);
        }
    }

    private void ResetHands()
    {
        leftHandNormal.SetActive(true);
        rightHandNormal.SetActive(true);

        leftHandGrabPose.SetActive(false);
        rightHandGrabPose.SetActive(false);
    }
}
