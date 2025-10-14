using System;

/// Base class for all shapes.
public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor() => _color;

    public void SetColor(string color) => _color = color;

    /// Virtual on purpose: derived classes override with their own formulas.
    public virtual double GetArea() => 0.0;
}
