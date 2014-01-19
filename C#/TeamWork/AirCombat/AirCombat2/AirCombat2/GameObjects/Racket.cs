using System.Media;

class Racket : MovingObject
{
    public new const string CollisionGroupString = "racket"; // similar to the rest of the objects.

    public Racket(MatrixCoords topLeft, char[,] body, MatrixCoords speed)
        : base(topLeft, body, speed)
    {

    }
    public override bool CanCollideWith(string otherCollisionGroupString)
    {
        return otherCollisionGroupString == "ship" || otherCollisionGroupString == "fire"
            || otherCollisionGroupString == CollisionGroupString;
    }

    public override void Update()
    {
        this.UpdatePosition();
    }

    public override void RespondToCollision(CollisionData collisionData)
    {
        this.IsDestroyed = true;
          SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
    }

    public override string GetCollisionGroupString()
    {
        return CollisionGroupString;
    }
}