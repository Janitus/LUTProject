using UnityEngine;

[CreateAssetMenu (fileName = "HealthCondition", menuName = "Conditions/HealthCondition")]
public class HealthCondition : Condition
{
    public float minimumHealthPercentage = 0f;
    public float maximumHealthPercentage = 1f;

    public override bool IsMet ( Character character ) {
        Health hp = character.GetComponent<Health> ();
        if (hp == null) return false;

        float healthPercentage = (float)hp.CurrentHealth / hp.maxHealth;
        return healthPercentage >= minimumHealthPercentage && healthPercentage <= maximumHealthPercentage;
    }
}
