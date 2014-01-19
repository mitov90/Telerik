using System;
using System.Collections.Generic;

public abstract class GameObject : IRenderable, ICollidable, IObjectProducer
{
    public const string CollisionGroupString = "object"; // all objects inherit this class called GameObject.
    public ConsoleColor Color { get; set; }

    protected MatrixCoords topLeft; // this is the initial position from which the object starts getting drawn.
    public MatrixCoords TopLeft // property of the object - its top left point.
    {
        get
        {
            return new MatrixCoords(topLeft.Row, topLeft.Col); // returns the coordinates of the top left point of the object when required.
        }

        protected set
        {
            this.topLeft = new MatrixCoords(value.Row, value.Col); // through the coordinates we move the object to the desired place.
        }
    }

    protected char[,] body;
    public bool IsDestroyed { get; protected set; }

    protected GameObject(MatrixCoords topLeft, char[,] body) // constructor (template) - we create three properties to which we will give values on a later stage
    {
        this.TopLeft = topLeft;

        this.body = this.CopyBodyMatrix(body);

        this.IsDestroyed = false;
    }

    public abstract void Update(); // update which is used by 8 objects which inherit this class.

    public virtual List<MatrixCoords> GetCollisionProfile() // returns the profile containing the points at which a collision is posiible.
    {
        List<MatrixCoords> profile = new List<MatrixCoords>(); // a list containing all the collision positions

        int bodyRows = this.body.GetLength(0);
        int bodyCols = this.body.GetLength(1);

        for ( int row = 0; row < bodyRows; row++ )
        {
            for ( int col = 0; col < bodyCols; col++ )
            {
                if (body[row, col] == ' ') continue;
                profile.Add(new MatrixCoords(row + this.topLeft.Row, col + this.topLeft.Col));
            }
        }

        return profile;
    }

    public virtual void RespondToCollision(CollisionData collisionData) // this method returns an answer to what happens after collision.
    {
    }

    public virtual bool CanCollideWith(string otherCollisionGroupString) // this method returns an answer to whether collisions with other objects are possible.
    {
        return GameObject.CollisionGroupString == otherCollisionGroupString;
    }

    public virtual string GetCollisionGroupString() // returns the name the objects.
    {
        return GameObject.CollisionGroupString;
    }

    char[,] CopyBodyMatrix(char[,] matrixToCopy) // this method makes a copy of the matrix of the object body and returns a new matrix with a different name.
    {
        int rows = matrixToCopy.GetLength(0);
        int cols = matrixToCopy.GetLength(1);

        char[,] result = new char[rows, cols];

        for ( int row = 0; row < rows; row++ )
        {
            for ( int col = 0; col < cols; col++ )
            {
                result[row, col] = matrixToCopy[row, col];
            }
        }

        return result;
    }

    public virtual MatrixCoords GetTopLeft() // returns the top left point coordinates of the object.
    {
        return this.TopLeft;
    }

    public virtual char[,] GetImage()
    {
        return this.CopyBodyMatrix(this.body); // this method returns the same matrix as the previous method but as a public one, so other objects could also be able to use it. 
    }

    public virtual IEnumerable<GameObject> ProduceObjects() // this method returns a list of the game objects.
    {
        return new List<GameObject>();
    }
}
