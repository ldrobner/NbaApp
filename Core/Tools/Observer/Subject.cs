namespace NbaApp.Core.Tools.Observer;

public abstract class Subject<T> where T: class {
    public List<Observer<T>> Observers { get => _observers; }
    private readonly List<Observer<T>> _observers;

    public Subject() {
        _observers = new List<Observer<T>>();
    }

    public void RegisterObserver(Observer<T> observer) {
        _observers.Add(observer);
    }

    public void UnregisterObserver(Observer<T> observer) {
        _observers.Remove(observer);
    }

    public void UpdateObservers(T update) {
        foreach(Observer<T> observer in _observers) {
            observer.Update(update);
        }
    }
}