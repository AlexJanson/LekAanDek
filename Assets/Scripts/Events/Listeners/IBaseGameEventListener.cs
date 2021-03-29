namespace Beweegmaatje.Events
{
    public interface IBaseGameEventListener<T>
    {
        void OnEventRaised(T arg);
    }
}
