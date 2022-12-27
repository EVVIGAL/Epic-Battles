public interface IHealth
{
    void TakeDamage(uint damage);
    bool IsAlive { get; }
}