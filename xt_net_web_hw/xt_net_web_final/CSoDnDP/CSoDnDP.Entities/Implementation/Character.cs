using CSoDnDP.Entities.Interfaces;
using CSoDnDP.Entities.Interfaces.CharacterStates;
using CSoDnDP.Entities.Implementation.CharacterStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSoDnDP.Entities.Implementation.CharacterInfo;
using CSoDnDP.Entities.Interfaces.CharacterInfo;
using CSoDnDP.Entities.Implementation.CharacterInventory;
using CSoDnDP.Entities.Interfaces.CharacterInventory;
using CSoDnDP.Entities.Implementation.CharacterMagic;
using CSoDnDP.Entities.Interfaces.CharacterMagic;

namespace CSoDnDP.Entities.Implementation
{
    public class Character : ICharacter
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public string Name { get; set; }
        public XElement InfoXML { get; set; }
        public XElement StatesXML { get; set; }
        public XElement MagicXML { get; set; }
        public XElement InventoryXML { get; set; }

        public ICharInfo Info { get; set; }
        public ICharStates States { get; set; }
        public ICharMagic Magic { get; set; }
        public ICharInventory Inventory { get; set; }

        public ICharInfo GetCharInfo()
        {
            try
            {
                CharInfo info = new CharInfo();

                info.Race = InfoXML.Element("Race").Value;

                info.Classes = new Dictionary<string, int>();
                foreach (XElement element in InfoXML.Element("Classes").Elements())
                {
                    info.Classes.Add(key: element.Element("Name").Value,
                        value: int.Parse(element.Element("Level").Value));
                }

                int level = 0;
                foreach (string key in info.Classes.Keys)
                {
                    level += info.Classes[key];
                }
                info.LevelMod = (level - 1) / 4 + 2;

                info.Alignment = InfoXML.Element("Alignment").Value;
                info.Background = InfoXML.Element("Background").Value;
                info.Exp = int.Parse(InfoXML.Element("Exp").Value);
                info.Hp = int.Parse(InfoXML.Element("Hp").Value);
                info.MaxHp = int.Parse(InfoXML.Element("MaxHP").Value);
                info.Speed = int.Parse(InfoXML.Element("Speed").Value);

                info.Traits = InfoXML.Element("Traits").Value;
                info.Ideals = InfoXML.Element("Ideals").Value;
                info.Bonds = InfoXML.Element("Bonds").Value;
                info.Flaws = InfoXML.Element("Flaws").Value;

                info.Features = new Dictionary<string, string>();
                foreach (XElement element in InfoXML.Element("Features").Elements())
                {
                    info.Features.Add(
                        key: element.Element("Name").Value,
                        value: element.Element("Description").Value);
                }

                return info;
            }
            catch
            {
                return null;
            }
        }

        private IState ParseState(XElement state_element, int level_bonus)
        {
            try
            {
                State state = new State();

                state.Value = int.Parse(state_element.Element("Value").Value);
                state.Bonus = int.Parse(state_element.Element("Bonus").Value);
                state.Modificator = (state.Value + state.Bonus - 10) / 2;

                state.Skills = new Dictionary<string, ISkill>();
                foreach (XElement element in state_element.Element("Skills").Elements())
                {
                    Skill skill = new Skill();

                    skill.Bonus = int.Parse(element.Element("Bonus").Value);
                    skill.Mastery = element.Element("Mastery").Value == "true";

                    skill.Value = state.Modificator + skill.Bonus;
                    if (skill.Mastery)
                    {
                        skill.Value += level_bonus;
                    }

                    state.Skills.Add(element.Name.ToString(), skill);
                }

                return state;
            }
            catch
            {
                return null;
            }
        }

        public ICharStates GetCharStates()
        {
            try
            {
                CharStates states = new CharStates();

                states.LevelBonus = Info.LevelMod;

                states.States = new Dictionary<string, IState>();
                foreach (XElement element in StatesXML.Elements("States").Elements())
                {
                    states.States.Add(element.Name.ToString(),
                        ParseState(element, states.LevelBonus));
                }

                states.Languages = new List<string>();
                foreach (XElement element in StatesXML.Element("Languages").Elements())
                {
                    states.Languages.Add(element.Value);
                }

                states.Proficiencies = new List<string>();
                foreach (XElement element in StatesXML.Element("Proficiencies").Elements())
                {
                    states.Proficiencies.Add(element.Value);
                }

                return states;
            }
            catch
            {
                return null;
            }
        }

        public ICharMagic GetMagic()
        {
            try
            {
                CharMagic magic = new CharMagic();

                magic.SpellCells = new Dictionary<int, int>();
                magic.Spells = new Dictionary<int, List<string>>();

                magic.Spells.Add(0, new List<string>());
                foreach(XElement element in MagicXML.Element("Сantrips").Elements())
                {
                    magic.Spells[0].Add(element.Value);
                }

                foreach (XElement element in MagicXML.Element("Spells").Elements())
                {
                    string name = element.Name.ToString();
                    int level = int.Parse(name[name.Length - 1].ToString());

                    magic.SpellCells.Add(
                        key: level,
                        value: int.Parse(element.Element("SpellCells").Value));

                    List<string> spells = new List<string>();
                    foreach (XElement spell in element.Elements("Spell"))
                    {
                        spells.Add(spell.Value);
                    }
                    magic.Spells.Add(level, spells);
                }

                return magic;
            }
            catch
            {
                return null;
            }
        }

        public ICharInventory GetCharInventory()
        {
            try
            {
                CharInventory inventory = new CharInventory();

                XElement equipment = InventoryXML.Element("Equipment");
                inventory.Weapons = new List<ICharWeapon>();
                foreach (XElement element in equipment.Elements("Weapon"))
                {
                    inventory.Weapons.Add(new CharWeapon
                    {
                        Name = element.Element("Name").Value,
                        Type = element.Element("Type").Value,
                        Modificator = int.Parse(element.Element("Mod").Value),
                        Damage = element.Element("Damage").Value,
                        Properties = element.Element("Properties").Value
                    });
                }

                inventory.Armors = new List<ICharArmor>();
                foreach (XElement element in equipment.Elements("Armor"))
                {
                    inventory.Armors.Add(new CharArmor
                    {
                        Name = element.Element("Name").Value,
                        Type = element.Element("Type").Value,
                        ArmorClass = int.Parse(element.Element("AC").Value),
                        Properties = element.Element("Properties").Value
                    });
                }

                inventory.Items = new List<ICharItem>();
                foreach (XElement element in equipment.Elements("Item"))
                {
                    inventory.Items.Add(new CharItem
                    {
                        Name = element.Element("Name").Value,
                        Description = element.Element("Description").Value
                    });
                }

                XElement money = InventoryXML.Element("Money");
                inventory.CopperMoney = int.Parse(money.Element("Copper").Value);
                inventory.SilverMoney = int.Parse(money.Element("Silver").Value);
                inventory.ElectrumMoney = int.Parse(money.Element("Electrum").Value);
                inventory.GoldMoney = int.Parse(money.Element("Gold").Value);
                inventory.PlatinumMoney = int.Parse(money.Element("Platinum").Value);

                return inventory;
            }
            catch
            {
                return null;
            }
        }

        public bool ParseXML()
        {
            try
            {
                Info = GetCharInfo();
                if (Info == null)
                {
                    return false;
                }

                States = GetCharStates();
                if (States == null)
                {
                    return false;
                }

                Magic = GetMagic();
                if (Magic == null)
                {
                    return false;
                }

                Inventory = GetCharInventory();
                if (Inventory == null)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
