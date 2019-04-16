using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using static Helpers;

public class TrippleAttack : AbstractSkill
{
    protected override IEnumerator Skill(Text noteText, Action<SkillType, int> callback)
    {
        int moveDamage = 0;
        currentDice = DiceType.None;

        noteText.text = "1. Roll D4 to choose hits count";

        while (currentDice != DiceType.D4)
        {
            yield return null;
        }

        int hitsCount = currentDiceValue;
        currentDiceValue = 0;
        currentDice = DiceType.None;

        for(int i = 2; i < hitsCount + 2; i++)
        {
            noteText.text = i + ". Roll D10 to choose damage";

            while (currentDice != DiceType.D10)
            {
                yield return null;
            }

            moveDamage += currentDiceValue;
            currentDiceValue = 0;
            currentDice = DiceType.None;
        }

        callback(SkillType.EnemyDamage, moveDamage);
    }
}
