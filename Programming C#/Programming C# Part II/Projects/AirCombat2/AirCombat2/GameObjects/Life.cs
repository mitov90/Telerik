using System;
using System.Security.Claims;

class Life : MovingObject // similar to the Fire and fuel object.
{
    public new const string CollisionGroupString = "life";

    public Life(MatrixCoords topLeft, char[,] body, MatrixCoords speed) : base(topLeft, body, speed)
    {

    }
        public override bool CanCollideWith(string otherCollisionGroupString)
    {
        return otherCollisionGroupString == "ship" || otherCollisionGroupString == CollisionGroupString || 
            otherCollisionGroupString == "fire";
    }

    public override void Update()
    {
        this.UpdatePosition();
    }

      public override void RespondToCollision(CollisionData collisionData)
    {
        this.IsDestroyed = true;
    }

    public override string GetCollisionGroupString()
    {
        return CollisionGroupString;
    }
}