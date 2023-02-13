using System.Collections.ObjectModel;

namespace GenshinProgressionHelper.ViewModels
{
    public class UserEntries : ViewModelBase
    {
        private ObservableCollection<UserEntry> _entries;

        public ObservableCollection<UserEntry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public UserEntries()
        {
            ObservableCollection<UserEntry> tmp = new ObservableCollection<UserEntry>();

            foreach (var user in App.UserDatabase.GetAllEntries())
            {
                tmp.Add(user);
            }

            _entries = tmp;
        }

        public void UpdateEntries()
        {
            _entries.Clear();

            foreach (var user in App.UserDatabase.GetAllEntries())
            {
                _entries.Add(user);
            }
        }
    }
}
