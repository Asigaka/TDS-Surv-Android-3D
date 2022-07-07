using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private float interactionsRange = 2;
    [SerializeField] private LayerMask interactionsLayers;

    [SerializeField] private Interactable currentInteractable;
    private Session session;

    public Interactable CurrentInteractable { get => currentInteractable;
        private set
        {
            currentInteractable = value;
            session.UI.HUD.SetInteractiveBtnActive(value != null);
        }
    }

    public void Initialize()
    {
        session = Session.Instance;
        session.UI.HUD.InteractBtn.onClick.AddListener(InteractWithCurrent);
    }

    public void CheckInteractablesAround()
    {
        Collider[] checkColliders = Physics.OverlapSphere(transform.position, interactionsRange, interactionsLayers);

        if (checkColliders.Length == 0)
        {
            if (CurrentInteractable)
            {
                CurrentInteractable.OnInvisible();
            }

            CurrentInteractable = null;
            return;
        }

        foreach (Collider collider in checkColliders)
        {
            Interactable newInteractable = collider.GetComponent<Interactable>();

            if (newInteractable)
            {
                if (CurrentInteractable)
                {
                    CurrentInteractable.OnInvisible();
                }

                CurrentInteractable = newInteractable;
                CurrentInteractable.OnVisible();
                return;
            }
        }

        if (CurrentInteractable)
        {
            CurrentInteractable.OnInvisible();
            CurrentInteractable = null;
        }
    }

    public void InteractWithCurrent()
    {
        if (CurrentInteractable)
        {
            Debug.Log("Interact with " + CurrentInteractable);
            CurrentInteractable.Interactive();
            CurrentInteractable = null;
        }
    }
}
