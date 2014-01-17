using System.Collections.Generic;

namespace AirCombat2.GameLogic
{
    public class Engine
    {
        readonly IRenderer renderer;
        readonly IUserInterface userInterface;
        readonly List<GameObject> allObjects;
        readonly List<MovingObject> movingObjects;
        readonly List<GameObject> staticObjects;
        Ship _playerShip;
        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if ( obj is Ship )
            {
                AddShip(obj);
            }
            else if ( obj is MovingObject )
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                this.AddStaticObject(obj);
            
            }
        }

        private void AddShip(GameObject obj)
        {
            this._playerShip = obj as Ship;
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerShipLeft()
        {
            this._playerShip.MoveLeft();
        }

        public virtual void MovePlayerShipRight()
        {
            this._playerShip.MoveRight();
        }

        public virtual void MovePlayerShipDown()
        {
            this._playerShip.MoveDown();
        }

        public virtual void MovePlayerShipUp()
        {
            this._playerShip.MoveUp();
        }

        public virtual void PlayerShipAction(Engine gameEngine)
        {
            this._playerShip.Shoot(gameEngine);
        }

        public virtual void Run(int sleepTime)
        {
            while ( true )
            {
                List<GameObject> newObjects = StartGame.RuntimeCreatedObjects();

                foreach (var gameObject in newObjects)
                {
                   this.AddObject(gameObject);
                }

                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(sleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach ( var obj in this.allObjects )
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach ( var obj in this.allObjects )
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach ( var obj in producedObjects )
                {
                    this.AddObject(obj);
                }
            }
        }

        
    }
}