using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProbabilityMachine
{
    private MyVector _Position { get; set; }
    private MyVector _Rotation { get; set; }
    private MyVector _Scale { get; set; }

    public ProbabilityMachine(MyVector pPosition, MyVector pRotation, MyVector pScale)
    {
        _Position = pPosition;
        _Rotation = pRotation;
        _Scale = pScale;

        InitialiseProbabilityMachine();
    }

    public void InitialiseProbabilityMachine()
    {
        MyMatrix parentScale = MyMatrix.CreateScale(_Scale);
        MyMatrix parentRotationX = MyMatrix.CreateRotationX(_Rotation.X);
        MyMatrix parentRotationY = MyMatrix.CreateRotationY(_Rotation.Y);
        MyMatrix parentRotationZ = MyMatrix.CreateRotationZ(_Rotation.Z);
        MyMatrix parentPosition = MyMatrix.CreateTranslation(_Position);
        MyMatrix parentTransform = parentPosition.Multiply(parentRotationX.Multiply(parentRotationY.Multiply(parentRotationZ.Multiply(parentScale))));

        RenderProbabilityMachine(parentTransform);
    }

    public void RenderProbabilityMachine(MyMatrix pParentTransform)
    {
        RenderBox(pParentTransform);
        RenderPegs(pParentTransform);
        RenderDividers(pParentTransform);
    }

    private void RenderBox(MyMatrix pParentTransform)
    {
        /*
        Uses one single function to generate and render shapes. Passes in the following values:
        - The Parent Transform value(s)
        - The desired name, shape and colour of the GameObject
        - The X, Y & Z values for the Scale
        - The X, Y & Z values for the Rotation
        - The X, Y & Z values for the Translation
        */
        
        GenerateShape(pParentTransform, "Base", PrimitiveType.Cube, Color.blue, 108f, 2.25f, 10f, 0f, 0f, 0f, 0f, 1.125f, 0f);
        GenerateShape(pParentTransform, "Lower Left Side", PrimitiveType.Cube, Color.blue, 72.5f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, -55.125f, 36.25f, 0f);
        GenerateShape(pParentTransform, "Lower Right Side", PrimitiveType.Cube, Color.blue, 72.5f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, 55.125f, 36.25f, 0f);
        GenerateShape(pParentTransform, "Left Top", PrimitiveType.Cube, Color.blue, 49f, 2.25f, 10f, 0f, 0f, 0f, -29.5f, 71.375f, 0f);
        GenerateShape(pParentTransform, "Right Top", PrimitiveType.Cube, Color.blue, 49f, 2.25f, 10f, 0f, 0f, 0f, 29.5f, 71.375f, 0f);
        GenerateShape(pParentTransform, "Upper Left Side", PrimitiveType.Cube, Color.blue, 17.75f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, -6.125f, 81.375f, 0f);
        GenerateShape(pParentTransform, "Upper Right Side", PrimitiveType.Cube, Color.blue, 17.75f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, 6.125f, 81.375f, 0f);
        GenerateShape(pParentTransform, "Middle Top", PrimitiveType.Cube, Color.blue, 14.5f, 2.25f, 10f, 0f, 0f, 0f, 0f, 91.375f, 0f);
        GenerateShape(pParentTransform, "Lower Back", PrimitiveType.Cube, Color.blue, 112.5f, 72.5f, 10f, 0f, 0f, 0f, 0f, 36.25f, 10f);
        GenerateShape(pParentTransform, "Upper Back", PrimitiveType.Cube, Color.blue, 14.5f, 20f, 10f, 0f, 0f, 0f, 0f, 82.5f, 10f);
    }

    private void RenderPegs(MyMatrix pParentTransform)
    {
        RenderPegsRow1(pParentTransform);
        RenderPegsRow2(pParentTransform);
        RenderPegsRow3(pParentTransform);
        RenderPegsRow4(pParentTransform);
        RenderPegsRow5(pParentTransform);
        RenderPegsRow6(pParentTransform);
        RenderPegsRow7(pParentTransform);
        RenderPegsRow8(pParentTransform);
    }

    private void RenderPegsRow1(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 1.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -49f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -36.75f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -24.5f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -12.25f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 0f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 12.25f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 24.5f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 36.75f, 57.25f, 0f);
        GenerateShape(pParentTransform, "Peg 1.9", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 49f, 57.25f, 0f);
    }

    private void RenderPegsRow2(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 2.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -42.875f, 52.25f, 0f);
        GenerateShape(pParentTransform, "Peg 2.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -30.625f, 52.25f, 0f);
        GenerateShape(pParentTransform, "Peg 2.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -18.375f, 52.25f, 0f);
        GenerateShape(pParentTransform, "Peg 2.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -6.125f, 52.25f, 0f);
        GenerateShape(pParentTransform, "Peg 2.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 6.125f, 52.25f, 0f);
        GenerateShape(pParentTransform, "Peg 2.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 18.375f, 52.25f, 0f);
        GenerateShape(pParentTransform, "Peg 2.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 30.625f, 52.25f, 0f);
        GenerateShape(pParentTransform, "Peg 2.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 42.875f, 52.25f, 0f);
    }

    private void RenderPegsRow3(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 3.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -49f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -36.75f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -24.5f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -12.25f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 0f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 12.25f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 24.5f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 36.75f, 47.25f, 0f);
        GenerateShape(pParentTransform, "Peg 3.9", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 49f, 47.25f, 0f);
    }

    private void RenderPegsRow4(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 4.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -42.875f, 42.25f, 0f);
        GenerateShape(pParentTransform, "Peg 4.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -30.625f, 42.25f, 0f);
        GenerateShape(pParentTransform, "Peg 4.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -18.375f, 42.25f, 0f);
        GenerateShape(pParentTransform, "Peg 4.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -6.125f, 42.25f, 0f);
        GenerateShape(pParentTransform, "Peg 4.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 6.125f, 42.25f, 0f);
        GenerateShape(pParentTransform, "Peg 4.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 18.375f, 42.25f, 0f);
        GenerateShape(pParentTransform, "Peg 4.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 30.625f, 42.25f, 0f);
        GenerateShape(pParentTransform, "Peg 4.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 42.875f, 42.25f, 0f);
    }

    private void RenderPegsRow5(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 5.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -49f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -36.75f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -24.5f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -12.25f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 0f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 12.25f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 24.5f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 36.75f, 37.25f, 0f);
        GenerateShape(pParentTransform, "Peg 5.9", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 49f, 37.25f, 0f);
    }

    private void RenderPegsRow6(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 6.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -42.875f, 32.25f, 0f);
        GenerateShape(pParentTransform, "Peg 6.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -30.625f, 32.25f, 0f);
        GenerateShape(pParentTransform, "Peg 6.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -18.375f, 32.25f, 0f);
        GenerateShape(pParentTransform, "Peg 6.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -6.125f, 32.25f, 0f);
        GenerateShape(pParentTransform, "Peg 6.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 6.125f, 32.25f, 0f);
        GenerateShape(pParentTransform, "Peg 6.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 18.375f, 32.25f, 0f);
        GenerateShape(pParentTransform, "Peg 6.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 30.625f, 32.25f, 0f);
        GenerateShape(pParentTransform, "Peg 6.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 42.875f, 32.25f, 0f);
    }

    private void RenderPegsRow7(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 7.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -49f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -36.75f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -24.5f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -12.25f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 0f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 12.25f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 24.5f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 36.75f, 27.25f, 0f);
        GenerateShape(pParentTransform, "Peg 7.9", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 49f, 27.25f, 0f);
    }

    private void RenderPegsRow8(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Peg 8.1", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -42.875f, 22.25f, 0f);
        GenerateShape(pParentTransform, "Peg 8.2", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -30.625f, 22.25f, 0f);
        GenerateShape(pParentTransform, "Peg 8.3", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -18.375f, 22.25f, 0f);
        GenerateShape(pParentTransform, "Peg 8.4", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, -6.125f, 22.25f, 0f);
        GenerateShape(pParentTransform, "Peg 8.5", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 6.125f, 22.25f, 0f);
        GenerateShape(pParentTransform, "Peg 8.6", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 18.375f, 22.25f, 0f);
        GenerateShape(pParentTransform, "Peg 8.7", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 30.625f, 22.25f, 0f);
        GenerateShape(pParentTransform, "Peg 8.8", PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f, (float)Math.PI / 2, 0f, 0f, 42.875f, 22.25f, 0f);
    }

    private void RenderDividers(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "Divider1", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, -42.875f, 12.25f, 0f);
        GenerateShape(pParentTransform, "Divider2", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, -30.625f, 12.25f, 0f);
        GenerateShape(pParentTransform, "Divider3", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, -18.375f, 12.25f, 0f);
        GenerateShape(pParentTransform, "Divider4", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, -6.125f, 12.25f, 0f);
        GenerateShape(pParentTransform, "Divider5", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, 6.125f, 12.25f, 0f);
        GenerateShape(pParentTransform, "Divider6", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, 18.375f, 12.25f, 0f);
        GenerateShape(pParentTransform, "Divider7", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, 30.625f, 12.25f, 0f);
        GenerateShape(pParentTransform, "Divider8", PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f, 0f, 0f, (float)Math.PI / 2, 42.875f, 12.25f, 0f);
    }

    private void GenerateShape(MyMatrix pParentTransform, string gameObjectName, PrimitiveType shape, Color color,
        float xScale, float yScale, float zScale,
        float xRotation, float yRotation, float zRotation,
        float xPosition, float yPosition, float zPosition)
    {
        GameObject localObject = GameObject.CreatePrimitive(shape);
        localObject.name = gameObjectName;
        localObject.GetComponent<Renderer>().material.color = color;

        MyMatrix localScale = MyMatrix.CreateScale(new MyVector(xScale, yScale, zScale));

        MyMatrix localRotationX = MyMatrix.CreateRotationX(xRotation);
        MyMatrix localRotationY = MyMatrix.CreateRotationY(yRotation);
        MyMatrix localRotationZ = MyMatrix.CreateRotationZ(zRotation);
        MyMatrix localRotation = localRotationZ.Multiply(localRotationY).Multiply(localRotationX);

        MyMatrix localTranslation = MyMatrix.CreateTranslation(new MyVector(xPosition, yPosition, zPosition));

        MyMatrix localTransform = localTranslation.Multiply(localRotation).Multiply(localScale);
        MyMatrix finalTransform = pParentTransform.Multiply(localTransform);

        finalTransform.SetTransform(localObject);
    }
}