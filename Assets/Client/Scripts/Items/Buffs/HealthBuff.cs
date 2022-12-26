using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    [SerializeField] private float multiplier;
    [SerializeField] private int price;
    [SerializeField] private string description;

    public override void Apply(GameObject player)
    {
        Health playerHealth = player.GetComponentInParent(typeof(Health)) as Health;
        playerHealth.SetMaxHealth((int)(playerHealth.GetMaxHealth() * multiplier));
        playerHealth.SetHealth((int)(playerHealth.GetHealth() * multiplier));
    }
    public override int GetPrice()
    {
        return price;
    }

    public override string GetDescription()
    {
        return description;
    }

}