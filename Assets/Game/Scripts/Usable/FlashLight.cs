using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Activable     //Create class Equipable or Usable
{
    //public UsableCollectable    type;
    public GameObject           bulb;
    public Material             lightON;
    public Material             lightOFF;
    public bool                 isOn;

    public Transform            pivot;
    public float                rotationSpeed;
    private float               pivotAngle;
    private float               lightAngle;

    public override void OnSelect()
    {
        isOn = isOn ? false : true;
        SwitchLight();
    }

    public void ForceState(bool state)
    {
        isOn = state;
        SwitchLight();
    }

    private void SwitchLight()
    {
        bulb.GetComponent<Renderer>().material = (isOn ? lightON : lightOFF);
        gameObject.SetActive(isOn);
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) pivot.LookAt(hit.point);
    }
}
