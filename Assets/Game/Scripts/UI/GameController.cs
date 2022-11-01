using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Interactable    _hovered;
    Selectable      _selection;
    RaycastHit      hit;
    
    public void Update()
    {
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
                    /*if (interactable.CheckIfInteractable())                                          // TODO add clickable
                    {
                        if (_selection != null)
                        {
                            Debug.Log("Hello");
                            _selection.OnDeselect();
                            _selection = null;
                        }
                        interactable.OnSelect();
                    }
                    else
                    {
                        Debug.Log("Object not selectable");
                    }*/
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

    public void SetSelection(Selectable newSelection)
    {
        _selection = newSelection;
    }

    /*public void OnClick()
    {
        if (_selection != null) _selection = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform.GetComponent<ISelectable>();
            Debug.Log(selection);

            if (selection != null)
            {
                selection.OnSelect();
            }
            else
            {
                Debug.Log("Object not selectable");
            }
        }
    }*/
}
