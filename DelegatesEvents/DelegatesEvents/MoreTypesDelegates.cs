namespace DelegatesEvents
{
    public delegate void Notification();
    public class MoreTypesDelegates
    {
        private List<MoreTypesDelegates> _items = new();
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime CreatedDate => DateTime.Now;
        public IReadOnlyCollection<MoreTypesDelegates> GetMoreTypesDelegates => _items;
        public event Notification Notify;

        #region Event Delegate
        public void Add(string item)
        {
            var itemList = new MoreTypesDelegates();
            itemList.Id += this._items.Count;
            itemList.Item = item;
            this._items.Add(itemList);
            EventHandler();
        }

        private void EventHandler()
        {
            Notify();
        }
        #endregion
        public override string ToString()
        {
            return $"{this.Id} - {this.Item} - {this.CreatedDate}";
        }

        #region Func
        public MoreTypesDelegates GetItemById(Func<MoreTypesDelegates, bool> func)
        {
            return this._items.FirstOrDefault(func);
        }
        #endregion
        #region Action
        public void PrintAllItems(Action<MoreTypesDelegates> action)
        {
            this._items.ForEach(action);
        }
        #endregion

        #region Predicate
        public bool ExistItem(Predicate<MoreTypesDelegates> pred)
        {
            return this._items.Exists(pred);
        }
        #endregion



    }
}
