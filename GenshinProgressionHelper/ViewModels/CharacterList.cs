using System.Collections.ObjectModel;

namespace GenshinProgressionHelper.ViewModels
{
    public class CharacterList : ViewModelBase
    {
        private ObservableCollection<Character> _characters;

        public ObservableCollection<Character> Characters
        {
            get { return _characters; }
            set
            {
                _characters = value;
                OnPropertyChanged();
            }
        }

        public CharacterList()
        {
            ObservableCollection<Character> tmp = new ObservableCollection<Character>();

            foreach (var character in App.CharacterDatabase.GetAllCharacters())
            {
                tmp.Add(character);
            }

            Characters = tmp;
        }
    }
}
