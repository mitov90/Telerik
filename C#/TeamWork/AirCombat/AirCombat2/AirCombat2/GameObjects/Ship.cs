using System;
using System.Text;
using AirCombat2.GameLogic;

public class Ship : GameObject
{

    private static int _health = 100;
    private static int _fuel = StartGame.FuelBonus * StartGame.ShootTimeout; // initial parameters.
    private static int _timeOut; 

    public static int Distance { get; set; } // at each iteration this variable is increased by one.
    public new const string CollisionGroupString = "ship";

    public Ship(MatrixCoords topLeft, char[,] body) // constructor (template)
        : base(topLeft, body)
    {
    }

    public void Shoot(Engine gameEngine) // this methods creates a new objec of the shooting type and checks the time passed after a shooting.
    {
        if (_timeOut <= 0)
        {
            gameEngine.AddObject(new Fire(new MatrixCoords(topLeft.Row,topLeft.Col + (this.body.GetLength(1)/2)),Init.Shoot,new MatrixCoords(-1,0) ));
            _timeOut = StartGame.ShootTimeout;
        }
        _fuel--;
    }

    #region Move
    public void MoveLeft() // the four movement methids follow below:
    {
        if ( topLeft.Col > 0 )
            this.topLeft.Col -= 3;
        _fuel--;
    }

    public void MoveRight()
    {
        if ( topLeft.Col + body.GetLength(1) < StartGame.WorldCols )
            this.topLeft.Col += 3;
        _fuel--;

    }

    public void MoveDown()
    {
        if ( topLeft.Row + body.GetLength(0) < StartGame.WorldRows )
            this.topLeft.Row++;
        _fuel--;

    }

    public void MoveUp()
    {
        if ( this.topLeft.Row > 0 )
            this.topLeft.Row--;
        _fuel--;

    }
    #endregion

    public override string GetCollisionGroupString() // returns the name of the object (ship)
    {
        return Ship.CollisionGroupString;
    }

    public override bool CanCollideWith(string otherCollisionGroupString) // with which object it is possible to collide.
    {
        return otherCollisionGroupString == Ship.CollisionGroupString || otherCollisionGroupString == "racket" || otherCollisionGroupString == "fuel" || otherCollisionGroupString == "life";
    }

    public override void Update() // checks and updates life and fuel capacity and ends game if necessary.
    {
        if ( _health <= 0 || _fuel <= 0 )
        {
            //new exception EndGame
            throw new Exception();
        }
        Distance++;
        _timeOut--;
    }

    public override void RespondToCollision(CollisionData collisionData) // reaction after collision.
    {
        foreach ( var str in collisionData.HitObjectsCollisionGroupStrings )
        {
            if ( str == "racket" )
                RacketCollision();
            else if ( str == "life" )
                LifeCollision();
            else if ( str == "fuel" )
                FuelCollision();
        }
    }

    public static string GetDetail() // returns the names and the values of the game tracker menu. 
    {
        StringBuilder scene = new StringBuilder();
        scene.AppendLine("Distance: " + Distance);
        scene.AppendLine("Fuel: " + _fuel);
        scene.Append("Health: " + _health);
        return scene.ToString();
    }

    private void RacketCollision() // reduces the life capacity at collision with a torpedo.
    {
        _health -= StartGame.RacketDamage;
    }

    private void LifeCollision() // increases the life capacity at collision with a life object.
    {
        _health += StartGame.LifeSupport;
    }

    private void FuelCollision() // reduces the life capacity at collision with a fuel tank.
    {
        _fuel += StartGame.FuelBonus;
    }

}