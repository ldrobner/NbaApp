namespace NbaApp.Core.Tools.Visitor;

public abstract class VisitorElement<T,U> 
    where T: class
    where U: class
{
    public List<U> Records { get => _records; }
    protected readonly List<U> _records;

    public VisitorElement() {
        _records = new List<U>();
    }

    public abstract void Accept(T visitor);
}