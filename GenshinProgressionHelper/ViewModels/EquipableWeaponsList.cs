using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinProgressionHelper.ViewModels
{
    public class EquipableWeaponsList : ViewModelBase
    {
        private ObservableCollection<Weapon> _weapons;
        public ObservableCollection<Weapon> EquipableWeapons
        {
            get { return _weapons; }
            set
            {
                _weapons = value;
                OnPropertyChanged();
            }
        }

        public EquipableWeaponsList()
        {
            ObservableCollection<Weapon> tmp = new ObservableCollection<Weapon>();

            foreach (var weapon in App.WeaponDatabase.GetAllWeapons())
            {
                tmp.Add(weapon);
            }

            EquipableWeapons = tmp;
        }

        public void RemoveNoViableWeapons(string characterName)
        {
            _weapons.Clear();
            Character character = App.CharacterDatabase.GetCharacterByName(characterName);

            foreach (var weapon in App.WeaponDatabase.GetAllWeapons())
            {
                if (weapon.Weapontype == character.Weapontype)
                {
                    _weapons.Add(weapon);
                }
            }
        }
    }
}
