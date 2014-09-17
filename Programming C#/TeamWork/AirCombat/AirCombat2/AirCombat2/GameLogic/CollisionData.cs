using System.Collections.Generic;

public class CollisionData
{
    public readonly MatrixCoords CollisionForceDirection;

    public readonly List<string> HitObjectsCollisionGroupStrings; //
    public CollisionData(MatrixCoords collisionForceDirection, string objectCollisionGroupString) // constructor - currently not in use
    {
        this.CollisionForceDirection = collisionForceDirection;
        this.HitObjectsCollisionGroupStrings = new List<string> {objectCollisionGroupString};
    }

    public CollisionData(MatrixCoords collisionForceDirection, IEnumerable<string> hitObjectsCollisionGroupStrings) // constructor - contains information in regrads to the coliisions, including force and direction.
    {
        this.CollisionForceDirection = collisionForceDirection;

        this.HitObjectsCollisionGroupStrings = new List<string>();

        foreach ( var str in hitObjectsCollisionGroupStrings )
        {
            this.HitObjectsCollisionGroupStrings.Add(str);
        }
    }
}
