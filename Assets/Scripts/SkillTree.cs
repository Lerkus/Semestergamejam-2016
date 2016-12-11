using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    //PlayerStats stats = GameMaster.getGameMaster().GetComponent<PlayerStats>();
    public enum skill { attackSpeed, shotgunWidth, shotgunDmg, mistelGroesse, mistelDmg, walkSpeed, armour, invincible, life, luck };

    [Header("Angriffstats")]
    public int attackSpeedLevel = 0;
    public int shotgunWidthLevel = 0;
    public int shotgunDmgLevel = 0;
    public int mistelGroesseLevel = 0;//Beim Instantiate vom Mistelobject abfragen
    public int mistelDmgLevel = 0;

    [Header("Verteidigungstats")]
    public int walkSpeedLevel = 0;
    public int armourLevel = 0;
    public int invincibleLevel = 0;
    public int lifeLevel = 0;
    public int luckLevel = 0;
    
    public int maxLevel = 1000000;

    public int[] upgradeCost = new int[10];

    public bool canYouSkill(skill skill)
    {
        switch (skill)
        {
            case skill.attackSpeed:
                if (attackSpeedLevel < maxLevel && Inventory.resources[0] > upgradeCost[0])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.shotgunWidth:
                if (shotgunWidthLevel < attackSpeedLevel && Inventory.resources[1] > upgradeCost[1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.shotgunDmg:
                if (shotgunDmgLevel < attackSpeedLevel && Inventory.resources[2] > upgradeCost[2])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.mistelGroesse:
                if (mistelGroesseLevel < attackSpeedLevel && Inventory.resources[3] > upgradeCost[3])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.mistelDmg:
                if (mistelDmgLevel < attackSpeedLevel && Inventory.resources[4] > upgradeCost[4])
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case skill.walkSpeed:
                if (walkSpeedLevel < maxLevel && Inventory.resources[5] > upgradeCost[5])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.armour:
                if (armourLevel < walkSpeedLevel && Inventory.resources[6] > upgradeCost[6])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.invincible:
                if (invincibleLevel < walkSpeedLevel && Inventory.resources[7] > upgradeCost[7])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.life:
                if (lifeLevel < walkSpeedLevel && Inventory.resources[8] > upgradeCost[8])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case skill.luck:
                if (luckLevel < walkSpeedLevel && Inventory.resources[9] > upgradeCost[9])
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
                    PlayerProgress.attackCoolDown *= 0.9f;
                    PlayerProgress.shotSpeed *= 1.1f;
                }
                break;
                
            case skill.shotgunWidth:
                if (canYouSkill(skill.shotgunWidth))
                {
                    shotgunWidthLevel++;
                    PlayerProgress.shotsToFire += 2;
                    PlayerProgress.shotgunWidthModifier *= 1.25f;
                }
                break;

            case skill.shotgunDmg:
                if (canYouSkill(skill.shotgunDmg))
                {
                    shotgunDmgLevel++;
                    PlayerProgress.shotDmg *= 1.5f;
                }
                break;

            case skill.mistelGroesse:
                if (canYouSkill(skill.mistelGroesse))
                {
                    mistelGroesseLevel++;
                    PlayerProgress.mistleSize += 0.25; 
                }
                break;

            case skill.mistelDmg:
                if (canYouSkill(skill.mistelDmg))
                {
                    mistelDmgLevel++;
                    PlayerProgress.mistelDmg *= 1.5f;
                }
                break;

            case skill.walkSpeed:
                if (canYouSkill(skill.walkSpeed))
                {
                    walkSpeedLevel++;
                    PlayerProgress.walkSpeed *= 1.2f;
                }
                break;

            case skill.armour:
                if (canYouSkill(skill.armour))
                {
                    armourLevel++;
                    PlayerProgress.dmgTakenMultiplier *= 0.95f;
                }
                break;

            case skill.invincible:
                if (canYouSkill(skill.invincible))
                {
                    invincibleLevel++;
                    PlayerProgress.invicibleTime *= 1.5f;
                }
                break;

            case skill.life:
                if (canYouSkill(skill.life))
                {
                    lifeLevel++;
                    PlayerProgress.maxHealth *= 1.75f;
                }
                break;

            case skill.luck:
                if (canYouSkill(skill.luck))
                {
                    luckLevel++;
                    PlayerProgress.presentDropChance *= 1.25f;
                }
                break;


            default: break;
        }
    }
}
