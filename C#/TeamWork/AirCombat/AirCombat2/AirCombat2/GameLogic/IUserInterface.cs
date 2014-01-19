using System;

public interface IUserInterface // definition of the use of keys.
{
    event EventHandler OnLeftPressed;

    event EventHandler OnRightPressed;

    event EventHandler OnDownPressed;

    event EventHandler OnUpPressed;

    event EventHandler OnActionPressed;

    void ProcessInput();
}
