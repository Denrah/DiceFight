using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Helpers;

public class RandomD4 : AbstractDice
{
    Dictionary<int, Vector3> dicePositions = new Dictionary<int, Vector3>
    {
        [1] = new Vector3(160, 0, 240),
        [2] = new Vector3(160, 0, 0),
        [3] = new Vector3(160, 0, 130),
        [4] = new Vector3(-90, 0, 0)
    };
    public int diceNumber = 4;

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
        diceNumber = Random.Range(1, 5);

        EventManager.TriggerEvent("diceRolled", DiceType.D4, diceNumber);
    }
}
