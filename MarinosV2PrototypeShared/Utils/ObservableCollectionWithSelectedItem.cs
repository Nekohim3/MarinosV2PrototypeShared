using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DynamicData;

namespace MarinosV2PrototypeShared.Utils
{
    public class ObservableCollectionWithSelectedItem<T> : ObservableCollection<T> where T : class
    {
        #region EventDelegate

        public delegate void SelectedChangedHandler(ObservableCollectionWithSelectedItem<T> sender, T newSelection, T oldSelection);
        public event SelectedChangedHandler? SelectionChanged;

        #endregion

        #region Private properties
        
        private bool _raiseCollectionChange = true;

        #endregion

        #region Public properties
        

        private T? _selectedItem;
        public T? SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value) return;
                var oldSelection = _selectedItem;
                _selectedItem = value;

                SelectionChanged?.Invoke(this, _selectedItem, oldSelection);
                OnPropertyChanged();
                OnPropertyChanged("Position");
            }
        }

        public bool IsSelectedLast => Count > 0 && SelectedItem != null && IndexOf(SelectedItem) == Count - 1;
        public bool IsSelectedFirst => Count > 0 && SelectedItem != null && IndexOf(SelectedItem) == 0;

        public int Position
        {
            get
            {
                if (Count == 0 || SelectedItem == null)
                    return -1;
                return IndexOf(SelectedItem);
            }
        }

        #endregion

        #region Ctor

        public ObservableCollectionWithSelectedItem() : base()
        {
            SetSelectedToFirst();
        }

        public ObservableCollectionWithSelectedItem(IEnumerable<T> list) : base(list)
        {
            SetSelectedToFirst();
        }

        #endregion

        #region Public funcs

        public void SetSelectedToFirst()
        {
            SelectedItem = this.FirstOrDefault();
        }

        public void SetSelectedToLast()
        {
            SelectedItem = this.LastOrDefault();
        }

        public bool SetSelectedTo(T item)
        {
            var obj = this.FirstOrDefault(x => x.Equals(item));
            if (obj == null) return false;
            SelectedItem = obj;
            return true;
        }

        public bool SetSelectedToId(int id)
        {
            var prop = typeof(T).GetProperty("Id");
            if (prop == null) return false;
            foreach (var x in this)
            {
                if (!int.TryParse(prop.GetValue(x)?.ToString(), out var res) || res != id) continue;

                SelectedItem = x;
                return true;
            }

            return false;
        }

        public bool SetSelectedToPosition(int pos)
        {
            if (pos < 0 || pos > Count - 1) return false;

            SelectedItem = this[pos];
            return true;
        }

        public bool SetSelectedToNext()
        {
            var next = GetNext();
            return next != null && SetSelectedTo(next);
        }

        public bool SetSelectedToPrev()
        {
            var prev = GetPrev();
            return prev != null && SetSelectedTo(prev);
        }

        public T? GetPrev()
        {
            if (SelectedItem == null) return default;
            var ind = IndexOf(SelectedItem);
            return ind == 0 ? default : this[ind - 1];
        }

        public T? GetNext()
        {
            if (SelectedItem == null) return default;
            var ind = IndexOf(SelectedItem);
            return ind == Count - 1 ? default : this[ind + 1];
        }

        public new void Clear()
        {
            SelectedItem = null;
            base.Clear();
        }

        public void SetRange(IEnumerable<T> list, bool raise = true)
        {
            _raiseCollectionChange = raise;
            Clear();
            this.AddRange(list);
            SetSelectedToFirst();
            _raiseCollectionChange = true;
        }

        #endregion
        
        #region OnPropertyChange

        protected override event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
