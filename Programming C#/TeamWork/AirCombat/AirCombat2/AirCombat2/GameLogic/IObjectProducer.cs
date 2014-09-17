using System;
using System.Collections.Generic;

public interface IObjectProducer // creation of the new objects.
{
    IEnumerable<GameObject> ProduceObjects();
}