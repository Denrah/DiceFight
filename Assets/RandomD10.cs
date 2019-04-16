using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Helpers;

public class RandomD10 : AbstractDice
{
    readonly Dictionary<int, Vector3> dicePositions = new Dictionary<int, Vector3>
    {
        [1] = new Vector3(-44.688F, 91.702F, -216.354F),
        [2] = new Vector3(48.975F, 91.843F, 37.182F),
        [3] = new Vector3(-44.688F, 91.702F, -72.23F),
        [4] = new Vector3(48.975F, 91.843F, 181.975F),
        [5] = new Vector3(-44.688F, 91.702F, -0.022F),
        [6] = new Vector3(48.975F, 91.843F, 109.232F),
        [7] = new Vector3(-44.688F, 91.702F, -144.492F),
        [8] = new Vector3(48.975F, 91.843F, -33.52F),
        [9] = new Vector3(-44.688F, 91.702F, -74.759F),
        [10] = new Vector3(48.975F, 91.843F, -105.182F),
    };
    public int diceNumber = 1;

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
        this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 600, 0));
        diceNumber = Random.Range(1, 11);
        EventManager.TriggerEvent("diceRolled", DiceType.D10, diceNumber);
    }

}
