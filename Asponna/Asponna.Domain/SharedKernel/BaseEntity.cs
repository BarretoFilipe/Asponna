namespace Asponna.Domain.SharedKernel
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }

        public bool IsTransient()
        {
            return Id == default;
        }
    }
}