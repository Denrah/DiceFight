using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using  UnityEngine.UI;
using static Helpers;

public class HealSkill : AbstractSkill
{
    protected override IEnumerator Skill(Text noteText, Action<SkillType, int> callback)
    {
        int moveHeal = 0;
        currentDice = DiceType.None;

        noteText.text = "1. Roll D20 to choose heal amount";

        while (currentDice != DiceType.D20)
        {
            yield return null;
        }

        moveHeal += currentDiceValue;
        currentDiceValue = 0;
        currentDice = DiceType.None;

        callback(SkillType.PlayerHeal, moveHeal);
    }
}
