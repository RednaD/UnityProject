using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour, IController
{
    Interactable                _hovered;
    RaycastHit                  hit;
    //public SelectionVariable    selection;

    //public IntVariable  delay;

    public InteractionTypeEnum  InteractionType;
    public BoolVariable         isButtonPressed;
    public ActionCharacter      controllable;

    public void HandleInput()
    {
        // Movements
        if (controllable.canMove) controllable.Move();

        if (Input.GetMouseButtonUp(1))
        {
            controllable.UseObject();
        }

        // Interactions
        if (isButtonPressed.v)
        {
            isButtonPressed.v = false;
            return;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            var interactable = hit.transform.GetComponent<Interactable>();

            if (interactable == null && _hovered != null)
            {
                _hovered.SetHover(false);
                _hovered = null;
            }
            if (interactable != null)
            {
                if (interactable != _hovered && _hovered != null) _hovered.SetHover(false);
                if (interactable.CheckIfInteractable())
                {
                    _hovered = interactable;
                    _hovered.SetHover(true);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    interactable.TryInteract(InteractionType.selection);
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    interactable.TryInteract(InteractionType.action);
                }
            }
        }

        // MOUSE WHEEL NAVIGATION
        /*if (_selection != null && float wheelAxis = Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (wheelAxis > 0)
            {
                WeaponNumber = (WeaponNumber + 1);
            }
            else
            {
                WeaponNumber = (WeaponNumber - 1);
            }
            CurrentWeapon = Weapons[WeaponNumber];
        }*/
    }
}
