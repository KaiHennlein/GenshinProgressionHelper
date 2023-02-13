namespace GenshinProgressionHelper
{
    public class ListFunctions
    {
        internal static List<Character> MergeCharacterLists(List<JsonClassForCharacter> characterList, List<JsonClassforCharacterTalents> characterTalentsList, List<JsonClassForTalentMaterialTypes> talentMaterialTypes)
        {
            List<Character> list = new List<Character>();

            foreach (JsonClassForCharacter c in characterList)
            {
                if (c.name != "Aether" && c.name != "Lumine")
                {
                    Character character = new Character();
                    character.Name = c.name;
                    character.Fullname = c.fullname;
                    character.Title = c.title;
                    character.Rarity = c.rarity;
                    character.Element = c.element;
                    character.Weapontype = c.weapontype;

                    if (c.images != null)
                    {
                        if (c.images.portrait != null)
                            character.PortraitLink = c.images.portrait;
                        if (c.images.icon != null)
                            character.IconLink = c.images.icon;
                    }

                    if (c.url != null)
                        character.WikiLink = c.url.fandom;
                    else
                        character.WikiLink = "Not available";

                    //Ascention 1
                    character.MoraCount = c.costs.ascend1[0].count;
                    character.GemstoneSliver = c.costs.ascend1[1].name;
                    character.GemstoneSliverCount = c.costs.ascend1[1].count;
                    character.LocalSpecialty = c.costs.ascend1[2].name;
                    character.LocalSpecialtyCount = c.costs.ascend1[2].count;
                    character.EnemyDropTier1 = c.costs.ascend1[3].name;
                    character.EnemyDropTier1Count = c.costs.ascend1[3].count;
                    //Ascention 2
                    character.MoraCount += c.costs.ascend2[0].count;
                    character.GemstoneFragment = c.costs.ascend2[1].name;
                    character.GemstoneFragmentCount = c.costs.ascend2[1].count;
                    character.BossMaterial = c.costs.ascend2[2].name;
                    character.BossMaterialCount = c.costs.ascend2[2].count;
                    character.LocalSpecialtyCount += c.costs.ascend2[3].count;
                    character.EnemyDropTier1Count += c.costs.ascend2[4].count;
                    //Ascention 3
                    character.MoraCount += c.costs.ascend3[0].count;
                    character.GemstoneFragmentCount += c.costs.ascend3[1].count;
                    character.BossMaterialCount += c.costs.ascend3[2].count;
                    character.LocalSpecialtyCount += c.costs.ascend3[3].count;
                    character.EnemyDropTier2 = c.costs.ascend3[4].name;
                    character.EnemyDropTier2Count = c.costs.ascend3[4].count;
                    //Ascention 4
                    character.MoraCount += c.costs.ascend4[0].count;
                    character.GemstoneChunk = c.costs.ascend4[1].name;
                    character.GemstoneChunkCount = c.costs.ascend4[1].count;
                    character.BossMaterialCount += c.costs.ascend4[2].count;
                    character.LocalSpecialtyCount += c.costs.ascend4[3].count;
                    character.EnemyDropTier2Count += c.costs.ascend4[4].count;
                    //Ascention 5
                    character.MoraCount += c.costs.ascend5[0].count;
                    character.GemstoneChunkCount += c.costs.ascend5[1].count;
                    character.BossMaterialCount += c.costs.ascend5[2].count;
                    character.LocalSpecialtyCount += c.costs.ascend5[3].count;
                    character.EnemyDropTier3 = c.costs.ascend5[4].name;
                    character.EnemyDropTier3Count = c.costs.ascend5[4].count;
                    //Ascention 6
                    character.MoraCount += c.costs.ascend6[0].count;
                    character.Gemstone = c.costs.ascend6[1].name;
                    character.GemstoneCount = c.costs.ascend6[1].count;
                    character.BossMaterialCount += c.costs.ascend6[2].count;
                    character.LocalSpecialtyCount += c.costs.ascend6[3].count;
                    character.EnemyDropTier3Count += c.costs.ascend6[4].count;

                    //
                    //Add character talents materials
                    //
                    //Find talent materials for the current character
                    JsonClassforCharacterTalents characterTalents = new JsonClassforCharacterTalents();

                    foreach (var ct in characterTalentsList)
                    {
                        if (ct != null)
                        {
                            if (character.Name == ct.name)
                            {
                                characterTalents = ct;
                                break;
                            }
                        }
                    }

                    //Talent level 2
                    character.MoraTalentCountLvl9 = characterTalents.costs.lvl2[0].count;
                    character.TalentTeachingType = characterTalents.costs.lvl2[1].name;
                    character.TalentTeachingCountLvl9 = characterTalents.costs.lvl2[1].count;
                    character.TalentEnemyDropTier1 = characterTalents.costs.lvl2[2].name;
                    character.TalentEnemyDropTier1Count = characterTalents.costs.lvl2[2].count;

                    //Talent level 3
                    character.MoraTalentCountLvl9 += characterTalents.costs.lvl3[0].count;
                    character.TalentGuideType = characterTalents.costs.lvl3[1].name;
                    character.TalentGuideCountLvl9 = characterTalents.costs.lvl3[1].count;
                    character.TalentEnemyDropTier2 = characterTalents.costs.lvl3[2].name;
                    character.TalentEnemyDropTier2Count = characterTalents.costs.lvl3[2].count;

                    //Talent level 4
                    character.MoraTalentCountLvl9 += characterTalents.costs.lvl4[0].count;
                    character.TalentGuideCountLvl9 += characterTalents.costs.lvl4[1].count;
                    character.TalentEnemyDropTier2Count += characterTalents.costs.lvl4[2].count;

                    //Talent level 5
                    character.MoraTalentCountLvl9 += characterTalents.costs.lvl5[0].count;
                    character.TalentGuideCountLvl9 += characterTalents.costs.lvl5[1].count;
                    character.TalentEnemyDropTier2Count += characterTalents.costs.lvl5[2].count;


                    //Talent level 6
                    character.MoraTalentCountLvl9 += characterTalents.costs.lvl6[0].count;
                    character.TalentGuideCountLvl9 += characterTalents.costs.lvl6[1].count;
                    character.TalentEnemyDropTier2Count += characterTalents.costs.lvl6[2].count;

                    //Talent level 7
                    character.MoraTalentCountLvl9 += characterTalents.costs.lvl7[0].count;
                    character.TalentPhilosophyType = characterTalents.costs.lvl7[1].name;
                    character.TalentPhilosophyCountLvl9 = characterTalents.costs.lvl7[1].count;
                    character.TalentEnemyDropTier3 = characterTalents.costs.lvl7[2].name;
                    character.TalentEnemyDropTier3Lvl9Count = characterTalents.costs.lvl7[2].count;
                    character.TalentBossMaterial = characterTalents.costs.lvl7[3].name;
                    character.TalentBossMaterialCountLvl9 = characterTalents.costs.lvl7[3].count;

                    //Talent level 8
                    character.MoraTalentCountLvl9 += characterTalents.costs.lvl8[0].count;
                    character.TalentPhilosophyCountLvl9 += characterTalents.costs.lvl8[1].count;
                    character.TalentEnemyDropTier3Lvl9Count += characterTalents.costs.lvl8[2].count;
                    character.TalentBossMaterialCountLvl9 += characterTalents.costs.lvl8[3].count;

                    //Talent level 9
                    character.MoraTalentCountLvl9 += characterTalents.costs.lvl9[0].count;
                    character.TalentPhilosophyCountLvl9 += characterTalents.costs.lvl9[1].count;
                    character.TalentEnemyDropTier3Lvl9Count += characterTalents.costs.lvl9[2].count;
                    character.TalentBossMaterialCountLvl9 += characterTalents.costs.lvl9[3].count;

                    //Talent level 10
                    character.MoraTalentCountLvl10 = character.MoraTalentCountLvl9 + characterTalents.costs.lvl10[0].count;
                    character.TalentPhilosophyCountLvl10 = character.TalentPhilosophyCountLvl9 + characterTalents.costs.lvl10[1].count;
                    character.TalentEnemyDropTier3Lvl10Count = character.TalentEnemyDropTier3Lvl9Count + characterTalents.costs.lvl10[2].count;
                    character.TalentBossMaterialCountvl10 = character.TalentBossMaterialCountLvl9 + characterTalents.costs.lvl10[3].count;

                    //
                    //Add possible farming days for the Talent materials
                    //
                    foreach (var talentMaterialType in talentMaterialTypes)
                    {
                        if (talentMaterialType != null)
                        {
                            if (talentMaterialType._2starname == character.TalentTeachingType)
                            {
                                character.TalentDomain = talentMaterialType.domainofmastery;
                                character.TalentDomainFirstDay = talentMaterialType.day[0];
                                character.TalentDomainSecondDay = talentMaterialType.day[1];
                                character.TalentDomainThirdDay = talentMaterialType.day[2];
                                break;
                            }
                        }

                        if (character.TalentDomain == null)
                        {
                            if (character.TalentTeachingType == "Teachings of Admonition")
                            {
                                character.TalentDomain = "Steeple of Ignorance";
                                character.TalentDomainFirstDay = "Monday";
                                character.TalentDomainSecondDay = "Thursday";
                                character.TalentDomainThirdDay = "Sunday";
                            }
                            else if (character.TalentTeachingType == "Teachings of Ingenuity")
                            {
                                character.TalentDomain = "Steeple of Ignorance";
                                character.TalentDomainFirstDay = "Tuesday";
                                character.TalentDomainSecondDay = "Friday";
                                character.TalentDomainThirdDay = "Sunday";
                            }
                            else if (character.TalentTeachingType == "Teachings of Praxis")
                            {
                                character.TalentDomain = "Steeple of Ignorance";
                                character.TalentDomainFirstDay = "Wednesday";
                                character.TalentDomainSecondDay = "Saturday";
                                character.TalentDomainThirdDay = "Sunday";
                            }
                            else
                            {
                                character.TalentDomain = "Missing Data";
                                character.TalentDomainFirstDay = "Missing Data";
                                character.TalentDomainSecondDay = "Missing Data";
                                character.TalentDomainThirdDay = "Sunday";
                            }
                        }
                        
                    }

                    list.Add(character);
                }
            }

            return list;
        }

        internal static List<Weapon> ConvertWeaponList(List<JsonClassForWeapon> weaponList, List<JsonClassForWeaponMaterialTypes> weaponMaterialTypes)
        {
            List<Weapon> list = new List<Weapon>();

            foreach (JsonClassForWeapon w in weaponList)
            {
                if (w.rarity >= 3 && w.costs.ascend1.Count == 4)
                {
                    Weapon weapon = new Weapon();
                    weapon.Name = w.name;
                    weapon.Weapontype = w.weapontype;
                    weapon.Rarity = w.rarity;
                    weapon.BaseAtk = w.baseatk;
                    weapon.SubStat = w.substat;
                    //
                    if (w.images.icon != null)
                        weapon.IconLink = w.images.icon;
                    if (w.images.awakenicon != null)
                        weapon.AwakenIconLink = w.images.awakenicon;
                    if (w.url != null)
                    {
                        if (w.url.fandom != null)
                            weapon.WikiLink = w.url.fandom;
                    }
                    else
                    {
                        weapon.WikiLink = "Not available";
                    }
                        
                    //
                    if (weapon.Rarity == 3)
                    {
                        weapon.MoraCount = 398880;
                        weapon.MysticOreCount = 395;
                        weapon.AscentionMoraCost = 105000;
                    }
                    else if (weapon.Rarity == 4)
                    {
                        weapon.MoraCount = 604320;
                        weapon.MysticOreCount = 600;
                        weapon.AscentionMoraCost = 150000;
                    }
                    else
                    {
                        weapon.MoraCount = 906480;
                        weapon.MysticOreCount = 903;
                        weapon.AscentionMoraCost = 225000;
                    }
                    //
                    //Ascention materials
                    //
                    weapon.WeaponMaterialType = w.weaponmaterialtype;

                    //Ascend 1
                    weapon.WeaponDomainTier2 = w.costs.ascend1[1].name;
                    weapon.WeaponDomainTier2Cost = w.costs.ascend1[1].count;
                    weapon.FirstEnemyDropTier2 = w.costs.ascend1[2].name;
                    weapon.FirstEnemyDropTier2Cost = w.costs.ascend1[2].count;
                    weapon.SecondEnemyDropTier1 = w.costs.ascend1[3].name;
                    weapon.SecondEnemyDropTier1Cost = w.costs.ascend1[3].count;
                    //Ascend 2
                    weapon.WeaponDomainTier3 = w.costs.ascend2[1].name;
                    weapon.WeaponDomainTier3Cost = w.costs.ascend2[1].count;
                    weapon.FirstEnemyDropTier2Cost += w.costs.ascend2[2].count;
                    weapon.SecondEnemyDropTier1Cost += w.costs.ascend2[3].count;
                    //Ascend 3
                    weapon.WeaponDomainTier3Cost += w.costs.ascend3[1].count;
                    weapon.FirstEnemyDropTier3 = w.costs.ascend3[2].name;
                    weapon.FirstEnemyDropTier3Cost = w.costs.ascend3[2].count;
                    weapon.SecondEnemyDropTier2 = w.costs.ascend3[3].name;
                    weapon.SecondEnemyDropTier2Cost = w.costs.ascend3[3].count;
                    //Ascend 4
                    weapon.WeaponDomainTier4 = w.costs.ascend4[1].name;
                    weapon.WeaponDomainTier4Cost = w.costs.ascend4[1].count;
                    weapon.FirstEnemyDropTier3Cost += w.costs.ascend4[2].count;
                    weapon.SecondEnemyDropTier2Cost += w.costs.ascend4[3].count;
                    //Ascend 5
                    weapon.WeaponDomainTier4Cost += w.costs.ascend5[1].count;
                    weapon.FirstEnemyDropTier4 = w.costs.ascend5[2].name;
                    weapon.FirstEnemyDropTier4Cost = w.costs.ascend5[2].count;
                    weapon.SecondEnemyDropTier3 = w.costs.ascend5[3].name;
                    weapon.SecondEnemyDropTier3Cost = w.costs.ascend5[3].count;
                    //Ascend 6
                    weapon.WeaponDomainTier5 = w.costs.ascend6[1].name;
                    weapon.WeaponDomainTier5Cost = w.costs.ascend6[1].count;
                    weapon.FirstEnemyDropTier4Cost += w.costs.ascend6[2].count;
                    weapon.SecondEnemyDropTier3Cost += w.costs.ascend6[3].count;

                    foreach (var weaponMaterialType in weaponMaterialTypes)
                    {
                        if (weaponMaterialType != null)
                        {
                            if (weaponMaterialType.name == weapon.WeaponMaterialType)
                            {
                                weapon.WeaponDomain = weaponMaterialType.domainofforgery;
                                weapon.WeaponDomainFirstDay = weaponMaterialType.day[0];
                                weapon.WeaponDomainSecondDay = weaponMaterialType.day[1];
                                weapon.WeaponDomainThirdDay = weaponMaterialType.day[2];
                                break;
                            }
                        }

                        if (weapon.WeaponDomain == null)
                        {
                            if (weapon.WeaponDomainTier2 == "Copper Talisman of the Forest Dew")
                            {
                                weapon.WeaponDomain = "Tower of Abject Pride";
                                weapon.WeaponDomainFirstDay = "Monday";
                                weapon.WeaponDomainSecondDay = "Thursday";
                                weapon.WeaponDomainThirdDay = "Sunday";
                            }
                            else if (weapon.WeaponDomainTier2 == "Oasis Garden's Reminiscence")
                            {
                                weapon.WeaponDomain = "Tower of Abject Pride";
                                weapon.WeaponDomainFirstDay = "Tuesday";
                                weapon.WeaponDomainSecondDay = "Friday";
                                weapon.WeaponDomainThirdDay = "Sunday";
                            }
                            else if (weapon.WeaponDomainTier2 == "Echo of Scorching Might")
                            {
                                weapon.WeaponDomain = "Tower of Abject Pride";
                                weapon.WeaponDomainFirstDay = "Wednesday";
                                weapon.WeaponDomainSecondDay = "Saturday";
                                weapon.WeaponDomainThirdDay = "Sunday";
                            }
                            else
                            {
                                weapon.WeaponDomain = "Missing Data";
                                weapon.WeaponDomainFirstDay = "Missing Data";
                                weapon.WeaponDomainSecondDay = "Missing Data";
                                weapon.WeaponDomainThirdDay = "Sunday";
                            }
                        }
                    }

                    list.Add(weapon);
                }
            }

            return list;
        }
    }
}
