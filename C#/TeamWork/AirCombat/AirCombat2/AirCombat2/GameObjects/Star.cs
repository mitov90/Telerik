class Star : MovingObject
{
    public new const string CollisionGroupString = "star"; // the name of the static space dust on the console.

    public Star(MatrixCoords topLeft, char[,] body, MatrixCoords speed) // constructor (template)
        : base(topLeft, body, speed)
    {

    }

    public override void Update()
    {
        this.UpdatePosition();
    }

}