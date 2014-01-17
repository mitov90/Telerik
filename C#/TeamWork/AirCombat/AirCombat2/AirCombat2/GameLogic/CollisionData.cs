using System.Collections.Generic;

public class CollisionData
{
    public readonly MatrixCoords CollisionForceDirection;

    public readonly List<string> HitObjectsCollisionGroupStrings;
    public CollisionData(MatrixCoords collisionForceDirection, string objectCollisionGroupString)
    {
        this.CollisionForceDirection = collisionForceDirection;
        this.HitObjectsCollisionGroupStrings = new List<string> {objectCollisionGroupString};
    }

    public CollisionData(MatrixCoords collisionForceDirection, IEnumerable<string> hitObjectsCollisionGroupStrings)
    {
        this.CollisionForceDirection = collisionForceDirection;

        this.HitObjectsCollisionGroupStrings = new List<string>();

        foreach ( var str in hitObjectsCollisionGroupStrings )
        {
            this.HitObjectsCollisionGroupStrings.Add(str);
        }
    }
}
