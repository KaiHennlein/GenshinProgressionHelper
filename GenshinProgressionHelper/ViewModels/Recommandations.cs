using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinProgressionHelper.ViewModels
{
    public class Recommandations : ViewModelBase
    {
        private ObservableCollection<Character> _charactersWithDomainsAvailable;
        private ObservableCollection<Character> _charactersWithRespawnedMaterials;
        private ObservableCollection<Weapon> _weaponsWithDomainsAvailable;

        public ObservableCollection<Character> CharactersWithDomainsAvailable
        {
            get { return _charactersWithDomainsAvailable; }
            set 
            {
                _charactersWithDomainsAvailable = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Character> CharactersWithRespawnedMaterials
        {
            get { return _charactersWithRespawnedMaterials; }
            set
            {
                _charactersWithRespawnedMaterials = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Weapon> WeaponsWithDomainsAvailable
        {
            get { return _weaponsWithDomainsAvailable; }
            set
            {
                _weaponsWithDomainsAvailable = value;
                OnPropertyChanged();
            }
        }

        public Recommandations()
        {
            List<UserEntry> entries = App.UserDatabase.GetAllEntries();
            //
            ObservableCollection<Character> charactersWithDomainsAvailable = new ObservableCollection<Character>();
            ObservableCollection<Character> charactersWithRespawnedMaterials = new ObservableCollection<Character>();
            ObservableCollection<Weapon> weaponsWithDomainsAvailable = new ObservableCollection<Weapon>();
            DateTime dateTime = DateTime.Now;
            //
            foreach (var entry in entries)
            {
                Character character = App.CharacterDatabase.GetCharacterByName(entry.CharacterName);
                if (character != null)
                {
                    string currentWeekday = DateTime.Now.DayOfWeek.ToString();
                    //
                    if (character.TalentDomainFirstDay == currentWeekday ||
                        character.TalentDomainSecondDay == currentWeekday ||
                        character.TalentDomainThirdDay == currentWeekday)
                    {
                        charactersWithDomainsAvailable.Add(character);
                    }
                    //
                    TimeSpan dateDifference = dateTime - entry.LastFarmingDate;
                    if (dateDifference.Days >= 2)
                    {

                        if (character != null)
                        {
                            charactersWithRespawnedMaterials.Add(character);
                        }
                    }
                    //
                    if (entry.WeapponName != "No Weapon Selected")
                    {
                        Weapon weapon = App.WeaponDatabase.GetWeaponByName(entry.WeapponName);
                        if (weapon != null)
                        {
                            if (weapon.WeaponDomainFirstDay == currentWeekday ||
                                weapon.WeaponDomainSecondDay == currentWeekday ||
                                weapon.WeaponDomainThirdDay == currentWeekday)
                            {
                                weaponsWithDomainsAvailable.Add(weapon);
                            }
                        }
                    }
                }
            }
            _charactersWithDomainsAvailable = charactersWithDomainsAvailable;
            _charactersWithRespawnedMaterials = charactersWithRespawnedMaterials;
            _weaponsWithDomainsAvailable = weaponsWithDomainsAvailable;
        }

        public void UpdateRecommendations()
        {
            _charactersWithDomainsAvailable.Clear();
            _charactersWithRespawnedMaterials.Clear();
            _weaponsWithDomainsAvailable.Clear();
            //
            List<UserEntry> entries = App.UserDatabase.GetAllEntries();
            //
            ObservableCollection<Character> charactersWithDomainsAvailable = new ObservableCollection<Character>();
            ObservableCollection<Character> charactersWithRespawnedMaterials = new ObservableCollection<Character>();
            ObservableCollection<Weapon> weaponsWithDomainsAvailable = new ObservableCollection<Weapon>();
            DateTime dateTime = DateTime.Now;
            //
            foreach (var entry in entries)
            {
                Character character = App.CharacterDatabase.GetCharacterByName(entry.CharacterName);
                if (character != null)
                {
                    string currentWeekday = DateTime.Now.DayOfWeek.ToString();
                    //
                    if (character.TalentDomainFirstDay == currentWeekday ||
                        character.TalentDomainSecondDay == currentWeekday ||
                        character.TalentDomainThirdDay == currentWeekday)
                    {
                        charactersWithDomainsAvailable.Add(character);
                    }
                    //
                    TimeSpan dateDifference = dateTime - entry.LastFarmingDate;
                    if (dateDifference.Days >= 2)
                    {

                        if (character != null)
                        {
                            charactersWithRespawnedMaterials.Add(character);
                        }
                    }
                    //
                    if (entry.WeapponName != "No Weapon Selected")
                    {
                        Weapon weapon = App.WeaponDatabase.GetWeaponByName(entry.WeapponName);
                        if (weapon != null)
                        {
                            if (weapon.WeaponDomainFirstDay == currentWeekday ||
                                weapon.WeaponDomainSecondDay == currentWeekday ||
                                weapon.WeaponDomainThirdDay == currentWeekday)
                            {
                                weaponsWithDomainsAvailable.Add(weapon);
                            }
                        }
                    }
                }
            }

            foreach (var character in charactersWithDomainsAvailable)
            {
                _charactersWithDomainsAvailable.Add(character);
            }

            foreach (var character in charactersWithRespawnedMaterials)
            {
                _charactersWithRespawnedMaterials.Add(character);
            }

            foreach (var weapon in weaponsWithDomainsAvailable)
            {
                _weaponsWithDomainsAvailable.Add(weapon);
            }
        }
    }
}
