using System.Collections.ObjectModel;

namespace GenshinProgressionHelper.ViewModels
{
    class WeaponList : ViewModelBase
    {
        private ObservableCollection<Weapon> _weapons;
        public ObservableCollection<Weapon> Weapons
        {
            get { return _weapons; }
            set 
            { 
                _weapons = value;
                OnPropertyChanged();
            }
        }

        public WeaponList()
        {
            ObservableCollection<Weapon> tmp = new ObservableCollection<Weapon>();

            foreach (var weapon in App.WeaponDatabase.GetAllWeapons())
            {
                tmp.Add(weapon);
            }

            Weapons = tmp;
        }

    }
}
