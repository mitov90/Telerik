using System;

public class MovingObject : GameObject
{ 
    public MatrixCoords Speed { get; protected set; }
     protected virtual void UpdatePosition()
    {
        this.TopLeft += this.Speed;
    }

    public MovingObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed) : base(topLeft, body)
    {
        this.Speed = speed;
    }

   
    public override void Update()
    {
        this.UpdatePosition();
    }
}

