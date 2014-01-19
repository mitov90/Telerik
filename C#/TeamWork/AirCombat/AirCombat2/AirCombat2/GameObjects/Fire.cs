class Fire : GameObject
{
    public new const string CollisionGroupString = "fire";

     public MatrixCoords Speed { get; protected set; }
     protected virtual void UpdatePosition() // at each iteration - how the position is changed when moving.
    {
        this.TopLeft += this.Speed;
    }

    public Fire(MatrixCoords topLeft, char[,] body, MatrixCoords speed) // constructor - called each time the space key is pressed,
        // creates a new object which moves upwards and deletes the objects it collides with (racket, fuel, life).
        : base(topLeft, body)
    {
        Speed = speed;
    }

    public override bool CanCollideWith(string otherCollisionGroupString) // it returns a boolean variable which indicates whether the object collided can destroyed.
    {
        return otherCollisionGroupString == "racket" || otherCollisionGroupString == CollisionGroupString ||
            otherCollisionGroupString == "fuel" || otherCollisionGroupString == "life";
    }

    public override void Update() // position update at each iteration.
    {
        this.UpdatePosition();
    }

    public override void RespondToCollision(CollisionData collisionData) // returns the result of a collision - whether one of the objects or both of them disappear (true) or not (false).
    {
        this.IsDestroyed = true;
    }

    public override string GetCollisionGroupString() // returns the string at the most upper row only. Specifically in this case this method returns the "fire" object.
    {
        return CollisionGroupString;
    }
}