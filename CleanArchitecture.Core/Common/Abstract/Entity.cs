namespace CleanArchitecture.Core.Common.Abstract;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
