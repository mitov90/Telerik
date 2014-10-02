class Fuel : MovingObject
{
    public new const string CollisionGroupString = "fuel";

    public Fuel(MatrixCoords topLeft, char[,] body, MatrixCoords speed) : base(topLeft, body, speed) // constructor (template)
    {

    }
        public override bool CanCollideWith(string otherCollisionGroupString) // returns the possibility of a collision between the "fuel" object and three other objects.
    {
        return otherCollisionGroupString == "ship" || otherCollisionGroupString == CollisionGroupString || 
            otherCollisionGroupString == "fire";
    }

    public override void Update() // this method updates the current position.
    {
        this.UpdatePosition();
    }

      public override void RespondToCollision(CollisionData collisionData) // this method gives an answer on what happens to an object in a collision
          // (either deletion or existance continuation or capacity change).
    {
        this.IsDestroyed = true; // specifically in this case the object is deleted.
    }

      public override string GetCollisionGroupString() // returns the string at the most upper row only. Specifically in this case this method returns the "fuel" object.
    {
        return CollisionGroupString;
    }
}