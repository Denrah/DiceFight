using System.Collections;
using System.Collections.Generic;
using TinForge.AircraftDemo.TinForge.AircraftDemo;
using UnityEngine;

public abstract class AbstractDice : MonoBehaviour
{

    readonly Dictionary<int, Vector3> dicePositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        RollDice();
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }

    protected abstract void RollDice();
}
