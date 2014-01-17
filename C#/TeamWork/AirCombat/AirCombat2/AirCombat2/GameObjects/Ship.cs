using System;
using System.Text;
using AirCombat2.GameLogic;

public class Ship : GameObject
{

    private static int _health = 100;
    private static int _fuel = StartGame.FuelBonus * StartGame.ShootTimeout;
    private static int _timeOut; 

    public static int Distance { get; set; }
    public new const string CollisionGroupString = "ship";

    public Ship(MatrixCoords topLeft, char[,] body)
        : base(topLeft, body)
    {
    }

    public void Shoot(Engine gameEngine)
    {
        if (_timeOut <= 0)
        {
            gameEngine.AddObject(new Fire(new MatrixCoords(topLeft.Row,topLeft.Col + (this.body.GetLength(1)/2)),new char[,] {{'*'}},new MatrixCoords(-1,0) ));
            _timeOut = StartGame.ShootTimeout;
        }
        _fuel--;
    }

    #region Move
    public void MoveLeft()
    {
        if ( topLeft.Col > 0 )
            this.topLeft.Col--;
        _fuel--;
    }

    public void MoveRight()
    {
        if ( topLeft.Col + body.GetLength(1) < StartGame.WorldCols )
            this.topLeft.Col++;
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

    public override string GetCollisionGroupString()
    {
        return Ship.CollisionGroupString;
    }

    public override bool CanCollideWith(string otherCollisionGroupString)
    {
        return otherCollisionGroupString == Ship.CollisionGroupString || otherCollisionGroupString == "racket" || otherCollisionGroupString == "fuel" || otherCollisionGroupString == "life";
    }

    public override void Update()
    {
        if ( _health <= 0 || _fuel <= 0 )
        {
            //new exception EndGame
            throw new Exception();
        }
        Distance++;
        _timeOut--;
    }

    public override void RespondToCollision(CollisionData collisionData)
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

    public static string GetDetail()
    {
        StringBuilder scene = new StringBuilder();
        scene.AppendLine("Distance: " + Distance);
        scene.AppendLine("Fuel: " + _fuel);
        scene.Append("Health: " + _health);
        return scene.ToString();
    }

    private void RacketCollision()
    {
        _health -= StartGame.RacketDamage;
    }

    private void LifeCollision()
    {
        _health += StartGame.LifeSupport;
    }

    private void FuelCollision()
    {
        _fuel += StartGame.FuelBonus;
    }

}