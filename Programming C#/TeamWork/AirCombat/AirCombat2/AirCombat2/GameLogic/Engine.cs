using System.Collections.Generic;

namespace AirCombat2.GameLogic
{
    public class Engine
    {
        readonly IRenderer renderer; // the interface which prints on the console.
        readonly IUserInterface userInterface; // the user control on the console via keyboard.
        readonly List<GameObject> allObjects; // the list of all objects currently on the console.
        readonly List<MovingObject> movingObjects; // the list of all MOVING objects currently on the console.
        readonly List<GameObject> staticObjects; // the list of all STATIC objects currently on the console.
        Ship _playerShip; // creation of the ship object.
        public Engine(IRenderer renderer, IUserInterface userInterface) // constructor - creates an on object of the Engine type
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        private void AddStaticObject(GameObject obj) // addition of a static object to the above-mentioned objects.
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj) // addition of a moving object to the above-mentioned objects.
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj) // we check whether this is a static, a moving object or our ship and we add it to the respective list of objects (containers).
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

        private void AddShip(GameObject obj) // addig the ship to the list of objects.
        {
            this._playerShip = obj as Ship;
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerShipLeft() // moving the ship to the left
        {
            this._playerShip.MoveLeft();
        }

        public virtual void MovePlayerShipRight() // moving the ship to the right
        {
            this._playerShip.MoveRight();
        }

        public virtual void MovePlayerShipDown() // moving the ship downwards
        {
            this._playerShip.MoveDown();
        }

        public virtual void MovePlayerShipUp() // moving the ship upwards
        {
            this._playerShip.MoveUp();
        }

        public virtual void PlayerShipAction(Engine gameEngine) // shooting in stead of movement (movement of the object).
        {
            this._playerShip.Shoot(gameEngine);
        }

        public virtual void Run(int sleepTime) // the engine of the game - this is where the starts.
        {
            while ( true )
            {
                List<GameObject> newObjects = StartGame.RuntimeCreatedObjects();

                foreach (var gameObject in newObjects)
                {
                   this.AddObject(gameObject); // we add newly created objects to the list of objects.
                }

                this.renderer.RenderAll(); // prints all objects on the console.

                System.Threading.Thread.Sleep(sleepTime); // delays the game so we coul play at a normal speed.

                this.userInterface.ProcessInput(); // checkes if a key is pressed and if so, it executes its function.

                this.renderer.ClearQueue(); // we clean the string which is printed on the whole console.

                foreach ( var obj in this.allObjects )
                {
                    obj.Update(); // we update all rellevant parameters for the specific objects.
                    this.renderer.EnqueueForRendering(obj); // the updated parameters are now added to the string containing all objects that are printed on theconsole at each iteration.
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects); // we check all collisions that have occured and we process them.

                List<GameObject> producedObjects = new List<GameObject>();

                foreach ( var obj in this.allObjects )
                {
                    producedObjects.AddRange(obj.ProduceObjects()); // we add the newly created objects to the list of objects
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed); // we check whether all objects have been deleted and the ones that have not been deleted are rempoved from the existing objects list. 
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed); // the same
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed); // the same

                foreach ( var obj in producedObjects )
                {
                    this.AddObject(obj); // we send the newly created objects to the respective class.
                }
            }
        }

        
    }
}