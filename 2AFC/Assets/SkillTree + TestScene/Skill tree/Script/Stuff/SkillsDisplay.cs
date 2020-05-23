using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Script
{
    public class SkillsDisplay : MonoBehaviour
    {

        public Skills skill;
        // Start is called before the first frame update
        public Text skillName;
        public Text skillDescription;
        public Image skillIcon;
        public Text skillMonsterPointNeeded;
        public Text skillAttribute;
        public Text skillAttrAmount;
        public List<Skills> parentSkill;

        [SerializeField] private PlayerStats PlayerHandler;
        void Start()
        {
            PlayerHandler = this.GetComponentInParent<PlayerHandler>().Player;
            PlayerHandler.monsterPointChange += ReactToChange;

            if (skill)
                skill.SetValues(this.gameObject, PlayerHandler);

            this.transform.Find("Image").Find("Available").gameObject.SetActive(false);
            EnableSkills();
            skill.SkillIsUnlocked = false;
        }

        public void EnableSkills()
        {
            bool EachSkill = true;
            foreach (Skills _skill in parentSkill)
            {
                EachSkill = EachSkill && _skill.SkillIsUnlocked;
                _skill.skillUpdateChange += ReactToChange;
            }
            
            if (PlayerHandler && skill && skill.EnableSkill(PlayerHandler) /*&& skill.skillIsUnlocked*/)
            {
                TurnOnSkillIcon();
            }
            else if (PlayerHandler && skill && skill.CheckSkills(PlayerHandler) && EachSkill)
            {
                this.GetComponent<Button>().interactable = true;
                this.transform.Find("Image").Find("Disable").gameObject.SetActive(false);
                this.transform.Find("Image").Find("Available").gameObject.SetActive(true);
            }
            else
            {
                TurnOffSkillIcon();
            }
        }

        private void OnEnable()
        {
            EnableSkills();
        }

        public void GetSkill()
        {
            if (skill.GetSkill(PlayerHandler))
            {
                TurnOnSkillIcon();
                skill.SkillIsUnlocked = true;
            }
        }

        private void TurnOffSkillIcon()
        {
            this.GetComponent<Button>().interactable = false;
            this.transform.Find("Image").Find("Disable").gameObject.SetActive(true);
            this.transform.Find("Image").Find("Available").gameObject.SetActive(false);
        }

        private void TurnOnSkillIcon()
        {
            this.GetComponent<Button>().interactable = false;
            this.transform.Find("Image").Find("Disable").gameObject.SetActive(false);
            this.transform.Find("Image").Find("Available").gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            PlayerHandler.monsterPointChange -= ReactToChange;
        }

        void ReactToChange()
        {
            EnableSkills();
        }
    }
}