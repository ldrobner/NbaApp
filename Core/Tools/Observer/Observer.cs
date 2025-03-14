namespace NbaApp.Core.Tools.Observer;

public abstract class Observer<T> where T : class {
    public abstract void Update(T update);
}