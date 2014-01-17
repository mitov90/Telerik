class Fuel : MovingObject
{
    public new const string CollisionGroupString = "fuel";

    public Fuel(MatrixCoords topLeft, char[,] body, MatrixCoords speed) : base(topLeft, body, speed)
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