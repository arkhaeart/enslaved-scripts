using System;

public class HeapQueue<T> where T : IHeap<T>
{

    T[] items;
    int itemCount;
    public HeapQueue(int maxSize)
    {
        items = new T[maxSize];
    }

    public int Count { get => itemCount; set => itemCount = value; }
    public bool Contains(T item)
    {
        return Equals(items[item.HeapIndex], item);
    }
    public T Dequeue()
    {
        T first = items[0];
        itemCount--;
        items[0] = items[itemCount];
        items[0].HeapIndex = 0;
        SortDown(items[0]);
        return first;
    }
    public void Enqueue(T item)
    {
        item.HeapIndex = itemCount;
        items[itemCount] = item;
        SortUp(item);
        itemCount++;
    }
    public void Update(T item)
    {
        SortUp(item);
    }

    void Swap(T first, T second)
    {
        items[first.HeapIndex] = second;
        items[second.HeapIndex] = first;
        int firstIndex = first.HeapIndex;
        first.HeapIndex = second.HeapIndex;
        second.HeapIndex = firstIndex;
    }
    void SortUp(T item)
    {
        int pi = (item.HeapIndex - 1) / 2;
        while (item.CompareTo(items[pi]) > 0)
        {
            T parent = items[pi];
            Swap(item, parent);
            pi = (item.HeapIndex - 1) / 2;
        }
    }
    void SortDown(T item)
    {
        while (true)
        {
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex = 0;

            if (childIndexLeft < itemCount)
            {
                swapIndex = childIndexLeft;

                if (childIndexRight < itemCount)
                {
                    if (items[childIndexLeft].CompareTo(items[childIndexRight]) < 0)
                    {
                        swapIndex = childIndexRight;
                    }
                }

                if (item.CompareTo(items[swapIndex]) < 0)
                {
                    Swap(item, items[swapIndex]);
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }

        }
    }
}
public interface IHeap<T>:IComparable<T>
{
    int HeapIndex { get; set; }
}
