using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalController : MonoBehaviour, IController
{
    Interactable                _hovered;
    RaycastHit                  hit;
    //public SelectionVariable    selection;

    //public IntVariable  delay;
    public BoolVariable isButtonPressed;


    public void HandleInput()
    {
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
                    interactable.TryInteract();
                }
            }
        }

        // LEFT MOUSE BUTTON DESELECTION
        /*if (Input.GetMouseButtonUp(1))
        {
            if (_selection != null)
            {
                Debug.Log("You shouldn't be here... O.O");
                _selection.OnDeselect();
                _selection = null;
            }
            // else open contextual menu ?
        }*/

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
