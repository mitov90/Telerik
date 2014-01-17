class Fire : GameObject
{
    public new const string CollisionGroupString = "fire";

     public MatrixCoords Speed { get; protected set; }
     protected virtual void UpdatePosition()
    {
        this.TopLeft += this.Speed;
    }

    public Fire(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
        : base(topLeft, body)
    {
        Speed = speed;
    }

    public override bool CanCollideWith(string otherCollisionGroupString)
    {
        return otherCollisionGroupString == "racket" || otherCollisionGroupString == CollisionGroupString ||
            otherCollisionGroupString == "fuel" || otherCollisionGroupString == "life";
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