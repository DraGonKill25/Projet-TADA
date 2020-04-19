using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    [CreateAssetMenu(menuName = "RPG generator/player/Create Skills")]
    public class Skills : ScriptableObject
    {
        public string Description;
        public Sprite Icon;
        public int MonsterPointNeeded;
        private bool skillIsUnlocked ;

        public bool SkillIsUnlocked
        {
            get { return skillIsUnlocked;}
            set
            {
                skillIsUnlocked = value;
                if (skillUpdateChange != null)
                    skillUpdateChange();
            }
        }
        
        public delegate void SkillUpdateChange();

        public event SkillUpdateChange skillUpdateChange;

        public List<PlayerAttributes> AffectedPlayerAttributes = new List<PlayerAttributes>();

        public void SetValues(GameObject SkillDisplayObject, PlayerStats Player)
        {
            if (Player)
            {
                CheckSkills(Player);
            }
            if (SkillDisplayObject)
            {
                SkillsDisplay SD = SkillDisplayObject.GetComponent<SkillsDisplay>();
                SD.skillName.text = name;

                if (SD.skillDescription)
                    SD.skillDescription.text = Description;

                if (SD.skillIcon)
                    SD.skillIcon.sprite = Icon;

                if (SD.skillMonsterPointNeeded)
                    SD.skillMonsterPointNeeded.text = MonsterPointNeeded.ToString() + "MP";

                if (SD.skillAttribute)
                {
                    string attributeName = "";
                    for (int i = 0; i < AffectedPlayerAttributes.Count; i++)
                    {
                        string temporary = "";
                        for (int j = 0; j < AffectedPlayerAttributes[i].attributes.ToString().Length; j++)
                        {
                            if (AffectedPlayerAttributes[i].attributes.ToString()[j] == ' ')
                                j = AffectedPlayerAttributes[i].attributes.ToString().Length;
                            else
                                temporary += AffectedPlayerAttributes[i].attributes.ToString()[j];
                        }

                        if (i == AffectedPlayerAttributes.Count - 1)
                            attributeName += temporary;
                        else
                            attributeName += temporary + "\n";
                    }

                    SD.skillAttribute.text = attributeName;
                }

                if (SD.skillAttrAmount)
                {
                    string amountNumber = "";
                    for (int i = 0; i < AffectedPlayerAttributes.Count; i++)
                    {
                        string temporary = "";
                        for (int j = 0; j < AffectedPlayerAttributes[i].amount.ToString().Length; j++)
                        {
                            if (AffectedPlayerAttributes[i].amount.ToString()[j] == ' ')
                                j = AffectedPlayerAttributes[i].amount.ToString().Length;
                            else
                                temporary += AffectedPlayerAttributes[i].amount.ToString()[j];
                        }

                        if (i == AffectedPlayerAttributes.Count - 1)
                            amountNumber += "+" + temporary;
                        else
                            amountNumber += "+" + temporary + "\n";
                    }

                    SD.skillAttrAmount.text = amountNumber;
                }
            }
        }

        public bool CheckSkills(PlayerStats Player)
        {
            if (Player.monsterPoint < MonsterPointNeeded)
                return false;
            return true;
        }

        public bool EnableSkill(PlayerStats player)
        {
            List<Skills>.Enumerator skills = player.Skills.GetEnumerator();
            while (skills.MoveNext())
            {
                var CurrSkill = skills.Current;
                if (CurrSkill.name == this.name)
                {
                    return true;
                }
            }

            return false;
        }

        public bool GetSkill(PlayerStats Player)
        {
            int i = 0;
            List<PlayerAttributes>.Enumerator attributes = AffectedPlayerAttributes.GetEnumerator();
            while (attributes.MoveNext())
            {
                List<PlayerAttributes>.Enumerator PlayerAttr = Player.Attributes.GetEnumerator();
                while (PlayerAttr.MoveNext())
                {
                    if (attributes.Current.attributes.name.ToString() == PlayerAttr.Current.attributes.name.ToString())
                    {
                        PlayerAttr.Current.amount += attributes.Current.amount;
                        i++;
                    }
                }
            }
            if (i > 0)
            {
                Player.monsterPoint -= this.MonsterPointNeeded;
                Player.Skills.Add(this);
                return true;
            }

            return false;
        }
        
    }
}
