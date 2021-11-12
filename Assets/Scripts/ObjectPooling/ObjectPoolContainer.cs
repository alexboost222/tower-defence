namespace ObjectPooling
{
    public class ObjectPoolContainer<T>
    {
        public bool IsUsed { get; private set; }

        public T Item { get; set; }

        public void Consume() => IsUsed = true;

        public void Release() => IsUsed = false;
    }
}