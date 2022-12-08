using System.Collections;

namespace PairWiseTestingExamples.NewFolder;

public class ObjectSetGroup : IList<List<Object>>
{
	public IList<List<Object>> ObjectSets { get; set; }
	public ObjectSetGroup()
    {
        var set1 = new List<Object>();
        var set2 = new List<Object>();

        this.ObjectSets = new List<List<Object>> { set1, set2};
    }

    public ObjectSetGroup(int capacity)
    {
        this.ObjectSets = new List<List<Object>>(capacity);

        //Enumerable.Repeat(0,count).Select(_ => this.ObjectSets.Add(new List<Object>()));
        this.ObjectSets =  Enumerable.Range(0, capacity)
            .Select(i => new List<object>())
            .ToList();

    }

    public void DefineObjectSet(int setNumber, List<Object> set)
    {
        ObjectSetGroup newSetGroup = new ObjectSetGroup(this.ObjectSets.Count);

        newSetGroup.AddRange(this.Select((sublist, index) => index == setNumber ? set : sublist));

        this.Clear();
        this.AddRange(newSetGroup);

        //ObjectSetGroup newSetGroup = new ObjectSetGroup(this.ObjectSets.Count);

        //for (int n = 0; n < this.ObjectSets.Count; n++)
        //{
        //    if (n == setNumber)
        //    {
        //        newSetGroup.Add(set);
        //        continue;
        //    }
        //    newSetGroup.Add(ObjectSets[n]);
        //}

        //this.ObjectSets = newSetGroup;
    }

    private void AddRange(IEnumerable<List<object>> sets)
    {
        this.ObjectSets = sets as IList<List<object>>;
    }

    public void AddObjectToSet(int setNumber, object value)
    {
        this.ObjectSets[setNumber].Add(value);
    }

    public IEnumerator<List<object>> GetEnumerator()
    {
        return ObjectSets.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)ObjectSets).GetEnumerator();
    }

    public void Add(List<object> item)
    {
        ObjectSets.Add(item);
    }

    public void Clear()
    {
        ObjectSets.Clear();
    }

    public bool Contains(List<object> item)
    {
        return ObjectSets.Contains(item);
    }

    public void CopyTo(List<object>[] array, int arrayIndex)
    {
        ObjectSets.CopyTo(array, arrayIndex);
    }

    public bool Remove(List<object> item)
    {
        return ObjectSets.Remove(item);
    }

    public int Count => ObjectSets.Count;

    public bool IsReadOnly => ObjectSets.IsReadOnly;

    public int IndexOf(List<object> item)
    {
        return ObjectSets.IndexOf(item);
    }

    public void Insert(int index, List<object> item)
    {
        ObjectSets.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        ObjectSets.RemoveAt(index);
    }

    public List<object> this[int index]
    {
        get => ObjectSets[index];
        set => ObjectSets[index] = value;
    }
}