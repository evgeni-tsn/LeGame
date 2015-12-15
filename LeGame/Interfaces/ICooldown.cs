
namespace LeGame.Interfaces
{
    public interface ICooldown
    {
        int CooldownTimer { get; set; }

        int TimeAtLastHit { get; set; }
    }
}
