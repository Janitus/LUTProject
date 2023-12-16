using UnityEngine;

[CreateAssetMenu (fileName = "DistanceCondition", menuName = "Conditions/DistanceCondition")]
public class DistanceCondition : Condition
{
    public float maximumDistance;

    public DistanceCondition(float distance)
    {
        maximumDistance = distance;
    }

    public override bool IsMet(Character character)
    {
        float distanceToPlayer = Vector2.Distance(character.transform.position, Player.instance.transform.position);
        return distanceToPlayer <= maximumDistance;
    }
}
