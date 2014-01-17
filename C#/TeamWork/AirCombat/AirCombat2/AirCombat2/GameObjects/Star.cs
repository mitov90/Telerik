class Star : MovingObject
{
    public new const string CollisionGroupString = "star";

    public Star(MatrixCoords topLeft,char[,] body, MatrixCoords speed)
        : base(topLeft, body, speed)
    {

    }

    public override void Update()
    {
        this.UpdatePosition();
    }

}