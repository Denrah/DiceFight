using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using static Helpers;

public abstract class AbstractSkill : MonoBehaviour
{

    public DiceType currentDice = DiceType.None;

    public int currentDiceValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        EventManager.StartListening("diceRolled", DiceListener);
    }

    void DiceListener(DiceType dice, int value)
    {
        currentDice = dice;
        currentDiceValue = value;
    }

    protected abstract IEnumerator Skill(Text noteText, Action<SkillType, int> callback);

    public void ActivateSkill(Text noteText, Action<SkillType, int> callback)
    {
        StartCoroutine(Skill(noteText, callback));
    }
}
