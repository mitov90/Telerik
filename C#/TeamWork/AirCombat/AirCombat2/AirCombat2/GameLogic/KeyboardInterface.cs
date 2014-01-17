using System;

public class KeyboardInterface : IUserInterface
{
    public void ProcessInput()
    {
        if (!Console.KeyAvailable) return;
        var keyInfo = Console.ReadKey();
        if ( keyInfo.Key.Equals(ConsoleKey.LeftArrow) )
        {
            if ( this.OnLeftPressed != null )
            {
                this.OnLeftPressed(this, new EventArgs());
            }
        }

        else if ( keyInfo.Key.Equals(ConsoleKey.RightArrow) )
        {
            if ( this.OnRightPressed != null )
            {
                this.OnRightPressed(this, new EventArgs());
            }
        }

        else if ( keyInfo.Key.Equals(ConsoleKey.UpArrow) )
        {
            if ( this.OnUpPressed != null )
            {
                this.OnUpPressed(this, new EventArgs());
            }
        }

        else if ( keyInfo.Key.Equals(ConsoleKey.DownArrow) )
        {
            if ( this.OnDownPressed != null )
            {
                this.OnDownPressed(this, new EventArgs());
            }
        }

        else if ( keyInfo.Key.Equals(ConsoleKey.Spacebar) )
        {
            if ( this.OnActionPressed != null )
            {
                this.OnActionPressed(this, new EventArgs());
            }
        }
        while ( Console.KeyAvailable )
        {
            Console.ReadKey();
        }
    }

    public event EventHandler OnLeftPressed;

    public event EventHandler OnRightPressed;

    public event EventHandler OnActionPressed;

    public event EventHandler OnUpPressed;

    public event EventHandler OnDownPressed;

}