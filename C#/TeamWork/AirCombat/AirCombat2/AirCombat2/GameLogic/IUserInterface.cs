using System;

public interface IUserInterface
{
    event EventHandler OnLeftPressed;

    event EventHandler OnRightPressed;

    event EventHandler OnDownPressed;

    event EventHandler OnUpPressed;

    event EventHandler OnActionPressed;

    void ProcessInput();
}
