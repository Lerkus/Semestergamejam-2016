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
    public int mistelGroesseLevel = 0;//Beim Instantiate vom Mistelobject abfragen
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
                    gameObject.GetComponent<PlayerStats>().attackCoolDown *= 0.9f;
                    gameObject.GetComponent<PlayerStats>().shotSpeed *= 1.1f;
                }
                break;
                
            case skill.shotgunWidth:
                if (canYouSkill(skill.shotgunWidth))
                {
                    shotgunWidthLevel++;
                    gameObject.GetComponent<PlayerStats>().shotsToFire += 2;
                    gameObject.GetComponent<PlayerStats>().shotgunWidthModifier *= 1.25f;
                }
                break;

            case skill.shotgunDmg:
                if (canYouSkill(skill.shotgunDmg))
                {
                    shotgunDmgLevel++;
                    gameObject.GetComponent<PlayerStats>().shotDmg *= 1.5f;
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
                    gameObject.GetComponent<PlayerStats>().strenght *= 1.5f;
                }
                break;

            case skill.walkSpeed:
                if (canYouSkill(skill.walkSpeed))
                {
                    walkSpeedLevel++;
                    gameObject.GetComponent<PlayerStats>().speed *= 1.2f;
                }
                break;

            case skill.armour:
                if (canYouSkill(skill.armour))
                {
                    armourLevel++;
                    gameObject.GetComponent<PlayerStats>().dmgTakenMultiplier *= 0.95f;
                }
                break;

            case skill.invincible:
                if (canYouSkill(skill.invincible))
                {
                    invincibleLevel++;
                    gameObject.GetComponent<PlayerStats>().invicibleTime *= 1.5f;
                }
                break;

            case skill.life:
                if (canYouSkill(skill.life))
                {
                    lifeLevel++;
                    gameObject.GetComponent<PlayerStats>().maxHealth *= 1.75f;
                }
                break;

            case skill.luck:
                if (canYouSkill(skill.luck))
                {
                    luckLevel++;
                    gameObject.GetComponent<PlayerStats>().presentDropChance *= 1.25f;
                }
                break;


            default: break;
        }
    }
}
