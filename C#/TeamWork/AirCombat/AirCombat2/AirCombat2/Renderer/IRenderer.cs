using System;

public interface IRenderer // this interface defines methods which will afterwards be overridden.
{
    void EnqueueForRendering(IRenderable obj);

    void RenderAll();

    void ClearQueue();
}
