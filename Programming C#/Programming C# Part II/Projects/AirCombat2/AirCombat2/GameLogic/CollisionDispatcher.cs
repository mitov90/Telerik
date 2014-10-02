using System.Collections.Generic;

public static class CollisionDispatcher
{
    public static void HandleCollisions(List<MovingObject> movingObjects, List<GameObject> staticObjects) // this method calls a second method for a collision of moving andstatic onjects
    {
        HandleMovingWithStaticCollisions(movingObjects, staticObjects);
    }

    private static void HandleMovingWithStaticCollisions(List<MovingObject> movingObjects, List<GameObject> staticObjects) // 
    {
        foreach ( var movingObject in movingObjects ) // there must be both a horizontal and vertical coincidence for a collision to happen.
        {
            int verticalIndex = VerticalCollisionIndex(movingObject, staticObjects);
            int horizontalIndex = HorizontalCollisionIndex(movingObject, staticObjects);

            MatrixCoords movingCollisionForceDirection = new MatrixCoords(0, 0);

            if ( verticalIndex != -1 )
            {
                movingCollisionForceDirection.Row = -movingObject.Speed.Row;
                staticObjects[verticalIndex].RespondToCollision(
                    new CollisionData(new MatrixCoords(movingObject.Speed.Row, 0),
                        movingObject.GetCollisionGroupString()));
            }

            if ( horizontalIndex != -1 )
            {
                movingCollisionForceDirection.Col = -movingObject.Speed.Col;
                staticObjects[horizontalIndex].RespondToCollision(
                    new CollisionData(new MatrixCoords(0, movingObject.Speed.Col),
                        movingObject.GetCollisionGroupString()));
            }

            int diagonalIndex = -1;
            if ( horizontalIndex == -1 && verticalIndex == -1 )
            {
                diagonalIndex = DiagonalCollisionIndex(movingObject, staticObjects);
                if ( diagonalIndex != -1 )
                {
                    movingCollisionForceDirection.Row = -movingObject.Speed.Row;
                    movingCollisionForceDirection.Col = -movingObject.Speed.Col;

                    staticObjects[diagonalIndex].RespondToCollision(
                        new CollisionData(new MatrixCoords(movingObject.Speed.Row, 0),
                            movingObject.GetCollisionGroupString()));
                }
            }

            List<string> hitByMovingCollisionGroups = new List<string>();

            if ( verticalIndex != -1 )
            {
                hitByMovingCollisionGroups.Add(staticObjects[verticalIndex].GetCollisionGroupString());
            }

            if ( horizontalIndex != -1 )
            {
                hitByMovingCollisionGroups.Add(staticObjects[horizontalIndex].GetCollisionGroupString());
            }

            if ( diagonalIndex != -1 )
            {
                hitByMovingCollisionGroups.Add(staticObjects[diagonalIndex].GetCollisionGroupString());
            }

            if ( verticalIndex != -1 || horizontalIndex != -1 || diagonalIndex != -1 )
            {
                movingObject.RespondToCollision(
                    new CollisionData(movingCollisionForceDirection,
                        hitByMovingCollisionGroups));
            }
        }
    }

    public static int VerticalCollisionIndex(MovingObject moving, List<GameObject> objects) // returns the profile of all vertical collisions. A profile includes a list of coordinates of points in the matrix.
    {
        List<MatrixCoords> profile = moving.GetCollisionProfile();

        List<MatrixCoords> verticalProfile = new List<MatrixCoords>();

        foreach ( var coord in profile )
        {
            verticalProfile.Add(new MatrixCoords(coord.Row + moving.Speed.Row, coord.Col));
        }

        int collisionIndex = GetCollisionIndex(moving, objects, verticalProfile);

        return collisionIndex;
    }

    public static int HorizontalCollisionIndex(MovingObject moving, List<GameObject> objects) // returns the profile of all horizontal collisions. A profile includes a list of coordinates of points in the matrix.
    {
        List<MatrixCoords> profile = moving.GetCollisionProfile();

        List<MatrixCoords> horizontalProfile = new List<MatrixCoords>();

        foreach ( var coord in profile )
        {
            horizontalProfile.Add(new MatrixCoords(coord.Row, coord.Col + moving.Speed.Col));
        }

        int collisionIndex = GetCollisionIndex(moving, objects, horizontalProfile);

        return collisionIndex;
    }

    public static int DiagonalCollisionIndex(MovingObject moving, List<GameObject> objects) // returns the profile of all diagonal collisions. Not in use.
    {
        List<MatrixCoords> profile = moving.GetCollisionProfile();

        List<MatrixCoords> horizontalProfile = new List<MatrixCoords>();

        foreach ( var coord in profile )
        {
            horizontalProfile.Add(new MatrixCoords(coord.Row + moving.Speed.Row, coord.Col + moving.Speed.Col));
        }

        int collisionIndex = GetCollisionIndex(moving, objects, horizontalProfile);

        return collisionIndex;
    }

    private static int GetCollisionIndex(MovingObject moving, ICollection<GameObject> objects, List<MatrixCoords> movingProfile) // returns the index of the current collision.
    {
        int collisionIndex = 0;

        foreach ( var obj in objects )
        {
            if ( moving.CanCollideWith(obj.GetCollisionGroupString()) || obj.CanCollideWith(moving.GetCollisionGroupString()) )
            {
                List<MatrixCoords> objProfile = obj.GetCollisionProfile();

                if ( ProfilesIntersect(movingProfile, objProfile) )
                {
                    return collisionIndex;
                }
            }

            collisionIndex++;
        }

        return -1;
    }

    private static bool ProfilesIntersect(List<MatrixCoords> firstProfile, List<MatrixCoords> secondProfile) // returns a bollean answer on whether a profile intersects with another profile.
    {
        foreach ( var firstCoord in firstProfile )
        {
            foreach ( var secondCoord in secondProfile )
            {
                if ( firstCoord.Equals(secondCoord) )
                {
                    return true;
                }
            }
        }

        return false;
    }
}
