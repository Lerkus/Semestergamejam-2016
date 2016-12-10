using UnityEngine;
using System.Collections;

public class SkillTree : MonoBehaviour
{
    PlayerStats stats = GameMaster.getGameMaster().GetComponent<PlayerStats>();
    public enum skill { attackSpeed, shotgunWidth, shotgunDmg, mistelGroesse, mistelDmg, walkSpeed, armour, invincible, life, luck };

    [Header("Angriffstats")]
    public int attackSpeedLevel = 0;
    public int shotgunWidthLevel = 0;
    public int shotgunDmgLevel = 0;
    public int mistelGroesseLevel = 0;
    public int mistelDmgLevel = 0;

    [Header("Verteidigungstats")]
    public int walkSpeedLevel = 0;
    public int armourLevel = 0;
    public int invincibleLevel = 0;
    public int lifeLevel = 0;
    public int luckLevel = 0;

    public int maxLevel = 1000000;

    public bool canYouSkill(skill skill)
    {
        switch (skill)
        {
            case skill.attackSpeed:
                if (attackSpeedLevel < maxLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.shotgunWidth:
                if (shotgunWidthLevel < attackSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.shotgunDmg:
                if (shotgunDmgLevel < attackSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.mistelGroesse:
                if (mistelGroesseLevel < attackSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.mistelDmg:
                if (mistelDmgLevel < attackSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case skill.walkSpeed:
                if (walkSpeedLevel < maxLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.armour:
                if (armourLevel < walkSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.invincible:
                if (invincibleLevel < walkSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.life:
                if (lifeLevel < walkSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.luck:
                if (luckLevel < walkSpeedLevel)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            default: return false;
        }
    }

    public void skillUp(skill skill)
    {
        switch (skill)
        {
            case skill.attackSpeed:
                if (canYouSkill(skill.attackSpeed))
                {
                    attackSpeedLevel++;
                }
                break;
                
            case skill.shotgunWidth:
                if (canYouSkill(skill.shotgunWidth))
                {
                    shotgunWidthLevel++;
                }
                break;

            case skill.shotgunDmg:
                if (canYouSkill(skill.shotgunDmg))
                {
                    shotgunDmgLevel++;
                }
                break;

            case skill.mistelGroesse:
                if (canYouSkill(skill.mistelGroesse))
                {
                    mistelGroesseLevel++;
                }
                break;

            case skill.mistelDmg:
                if (canYouSkill(skill.mistelDmg))
                {
                    mistelDmgLevel++;
                }
                break;

            case skill.walkSpeed:
                if (canYouSkill(skill.walkSpeed))
                {
                    walkSpeedLevel++;
                }
                break;

            case skill.armour:
                if (canYouSkill(skill.armour))
                {
                    armourLevel++;
                }
                break;

            case skill.invincible:
                if (canYouSkill(skill.invincible))
                {
                    invincibleLevel++;
                }
                break;

            case skill.life:
                if (canYouSkill(skill.life))
                {
                    lifeLevel++;
                }
                break;

            case skill.luck:
                if (canYouSkill(skill.luck))
                {
                    luckLevel++;
                }
                break;


            default: break;
        }
    }
}
