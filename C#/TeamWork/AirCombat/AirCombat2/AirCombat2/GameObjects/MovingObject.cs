using System;

public class MovingObject : GameObject
{ 
    public MatrixCoords Speed { get; protected set; } // we define a speed property for all moving objects.
     protected virtual void UpdatePosition() // update of the current posiition at the speed predefined.
    {
        this.TopLeft += this.Speed;
    }

    public MovingObject(MatrixCoords topLeft, char[,] body, MatrixCoords speed) : base(topLeft, body) // property constructor (template)
    {
        this.Speed = speed; // specifically adds speed to the rest of the properties.
    }

   
    public override void Update() // this method is called at each iteration of the game
    {
        this.UpdatePosition(); // update of the current posiition at the speed predefined.
    }
}

