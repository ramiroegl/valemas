namespace Valemas.Domain.Shared
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; init; } = default!;
    }
}
