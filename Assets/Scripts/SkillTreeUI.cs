using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillTreeUI : MonoBehaviour {
    public GameObject armorPerk;
    public GameObject attackSpeedPerk;
    public GameObject invinciblePerk;
    public GameObject healthPerk;
    public GameObject luckPerk;
    public GameObject mistleDamagePerk;
    public GameObject mistlesizePerk;
    public GameObject shotgunDamagePerk;
    public GameObject shotgunWidthPerk;
    public GameObject moveSpeedPerk;
    public SkillTree st;
	// Use this for initialization
	void Start () {
        checkAvaliability();
    }
	
	public void checkAvaliability()
    {
        if (!st.canYouSkill(SkillTree.skill.armour))
            armorPerk.GetComponent<Button>().interactable = false;
        else
            armorPerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.attackSpeed))
            attackSpeedPerk.GetComponent<Button>().interactable = false;
        else
            attackSpeedPerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.invincible))
            invinciblePerk.GetComponent<Button>().interactable = false;
        else
            invinciblePerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.life))
            healthPerk.GetComponent<Button>().interactable = false;
        else
            healthPerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.luck))
            luckPerk.GetComponent<Button>().interactable = false;
        else
            luckPerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.mistelDmg))
            mistleDamagePerk.GetComponent<Button>().interactable = false;
        else
            mistleDamagePerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.mistelGroesse))
            mistlesizePerk.GetComponent<Button>().interactable = false;
        else
            mistlesizePerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.shotgunDmg))
            shotgunDamagePerk.GetComponent<Button>().interactable = false;
        else
            shotgunDamagePerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.shotgunWidth))
            shotgunWidthPerk.GetComponent<Button>().interactable = false;
        else
            shotgunWidthPerk.GetComponent<Button>().interactable = true;

        if (!st.canYouSkill(SkillTree.skill.walkSpeed))
            moveSpeedPerk.GetComponent<Button>().interactable = false;
        else
            moveSpeedPerk.GetComponent<Button>().interactable = true;
    }
}
