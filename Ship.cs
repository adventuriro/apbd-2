using apbd.ContainerTypes;

namespace apbd;

public class Ship
{
    private List<Container> _containers = new();
    private IReadOnlyList<Container> Containers => _containers;

    public int Add(Container container)
    {
        _containers.Add(container);
        return _containers.Count - 1;
    }

    public void Add(IEnumerable<Container> containers)
    {
        _containers.AddRange(containers);
    }

    public int IndexOf(Container container)
    {
        return _containers.IndexOf(container);
    }

    public void Remove(Container container)
    {
        _containers.Remove(container);
    }

    public void Replace(int index, Container b)
    {
        _containers[index] = b;
    }

    public void Replace(Container a, Container b)
    {
        Replace(IndexOf(a), b);
    }

    public void MoveTo(Container container, Ship ship)
    {
        Remove(container);
        ship.Add(container);
    }

    public override string ToString()
    {
        return $"Ship{{{string.Join(", ", _containers)}}}";
    }
}