using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Helpers;

public class RandomD6 : AbstractDice
{
    Dictionary<int, Vector3> dicePositions = new Dictionary<int, Vector3>
    {
        [2] = new Vector3(0, 0, 180),
        [6] = new Vector3(90, 0, 0),
        [4] = new Vector3(0, 0, 90),
        [3] = new Vector3(0, 0, -90),
        [1] = new Vector3(-90, 0, 0),
        [5] = new Vector3(0, 0, 0)
    };

    private int diceNumber = 6;

    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, Quaternion.Euler(dicePositions[diceNumber]), Time.deltaTime * 2);
    }


    protected override void RollDice()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 700, 0));
        diceNumber = Random.Range(1, 7);

        EventManager.TriggerEvent("diceRolled", DiceType.D6, diceNumber);
    }
}
