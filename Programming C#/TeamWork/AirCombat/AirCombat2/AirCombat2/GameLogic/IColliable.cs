using System.Collections.Generic;

public interface ICollidable
{
    bool CanCollideWith(string objectType); // when an object inherits this interface, it is capable of colliding.

    List<MatrixCoords> GetCollisionProfile();

    void RespondToCollision(CollisionData collisionData);

    string GetCollisionGroupString();
}
