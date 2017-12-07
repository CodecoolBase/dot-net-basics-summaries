namespace CollectionsSummary
{
    public class CustomGenericClass<T> // generic class
    {
        T item;
        public void Add(T item)
        {
            this.item = item;
        }
        public override string ToString()
        {
            return item.ToString();
        }
    }
}
