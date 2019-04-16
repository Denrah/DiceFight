using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using static Helpers;

public class BasicAttack : AbstractSkill
{
    protected override IEnumerator Skill(Text noteText, Action<SkillType, int> callback)
    {
        int moveDamage = 0;
        currentDice = DiceType.None;

        noteText.text = "1. Roll D20 to choose damage";

        while (currentDice != DiceType.D20)
        {
            yield return null;
        }

        moveDamage += currentDiceValue;
        currentDiceValue = 0;
        currentDice = DiceType.None;

        noteText.text = "2. Roll D6 to check critical damage";

        while (currentDice != DiceType.D6)
        {
            yield return null;
        }

        if (currentDiceValue > 4)
        {
            currentDice = DiceType.None;
            currentDiceValue = 0;
            noteText.text = "3. Roll D20 to add critical damage";

            while (currentDice != DiceType.D20)
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
