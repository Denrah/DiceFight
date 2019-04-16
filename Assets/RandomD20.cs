using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Helpers;

public class RandomD20 : AbstractDice
{
    readonly Dictionary<int, Vector3> dicePositions = new Dictionary<int, Vector3>
    {
        [1] = new Vector3(-169.208F, 0, -0),
        [2] = new Vector3(-307.071F, 0, 0),
        [3] = new Vector3(232.632F, -328.739F, -432.41F),
        [4] = new Vector3(169.245F, -295.899F, -611.71f),
        [5] = new Vector3(127.278F, 42.478F, -325.277F),
        [6] = new Vector3(233.316F, -35.28998F, -215.422F),
        [7] = new Vector3(168.412F, 92.57999F, -36.34399F),
        [8] = new Vector3(190.744F, 29.60599F, 215.928F),
        [9] = new Vector3(233.086F, -165.447F, 72.686F),
        [10] = new Vector3(168.895F, -298.639F, -468.271F),
        [11] = new Vector3(190.713F, -239.363F, -288.439F),
        [12] = new Vector3(126.731F, -239.61F, -468.507F),
        [13] = new Vector3(170.055F, -180.436F, -323.456F),
        [14] = new Vector3(191.003F, -180.191F, -216.11F),
        [15] = new Vector3(52.926F, -179.689F, -215.899F),
        [16] = new Vector3(-52.504F, -7.494F, -323.644F),
        [17] = new Vector3(-10.362F, 60.292F, -251.716F),
        [18] = new Vector3(52.809F, -120.001F, -71.71301F),
        [19] = new Vector3(-127.235F, 0, 0),
        [20] = new Vector3(10.778F, 0, 0)
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
        diceNumber = Random.Range(1, 21);
        EventManager.TriggerEvent("diceRolled", DiceType.D20, diceNumber);
    }

}
