using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public IInteract currentInteract {  get; private set; }

    public IPickUp currentPickUp {  get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        IInteract interact = other.GetComponent<IInteract>();
        IPickUp pickUp = other.GetComponent<IPickUp>();

        if (interact != null)
        {
            currentInteract = interact;
        }

        if (pickUp != null)
        {
            currentPickUp = pickUp;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<IInteract>() == currentInteract)
        {
            currentInteract = null;
        }

        if(other.GetComponent <IPickUp>() == currentPickUp)
        {
            currentPickUp = null;
        }
    }
}
