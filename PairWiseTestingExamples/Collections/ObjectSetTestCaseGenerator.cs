namespace PairWiseTestingExamples.NewFolder;

public class ObjectSetTestCaseGenerator
{
    private ObjectSetGroup _objectSetGroup;

    public ObjectSetGroup ObjectSetGroup
    {
        get => _objectSetGroup;
        set => _objectSetGroup = value;
    }

    public ObjectSetTestCaseGenerator()
    {
        FirstInitObjectSetGroup();
    }

    private void FirstInitObjectSetGroup()
    {
        ObjectSetGroup = new ObjectSetGroup();
    }

    public void InitializeSetData(ObjectSetGroup objectSetGroup)
    {
        if (objectSetGroup is null)
        {
            FirstInitObjectSetGroup();
        }
        else
        {
            _objectSetGroup.Clear();
            _objectSetGroup = objectSetGroup;
        }
    }
}