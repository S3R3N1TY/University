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
        MyMatrix parentTransform = parentPosition.Multiply(parentRotationY.Multiply(parentRotationX.Multiply(parentRotationZ.Multiply(parentScale))));

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
        float angleIncrement = 12.25f;
        float startingAngle = -49f;

        for (int i = 1; i <= 9; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 1.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 57.25f, 0f);
        }
    }

    private void RenderPegsRow2(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -42.875f;

        for (int i = 1; i <= 8; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 2.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 52.25f, 0f);
        }
    }

    private void RenderPegsRow3(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -49f;

        for (int i = 1; i <= 9; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 3.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 47.25f, 0f);
        }
    }

    private void RenderPegsRow4(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -42.875f;

        for (int i = 1; i <= 8; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 4.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 42.25f, 0f);
        }
    }

    private void RenderPegsRow5(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -49f;

        for (int i = 1; i <= 9; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 5.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 37.25f, 0f);
        }
    }

    private void RenderPegsRow6(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -42.875f;

        for (int i = 1; i <= 8; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 6.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 32.25f, 0f);
        }
    }

    private void RenderPegsRow7(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -49f;

        for (int i = 1; i <= 9; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 7.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 27.25f, 0f);
        }
    }

    private void RenderPegsRow8(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -42.875f;

        for (int i = 1; i <= 8; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string pegName = $"Peg 8.{i}";

            GenerateShape(pParentTransform, pegName, PrimitiveType.Cylinder, Color.red, 2f, 5f, 2f,
                (float)Math.PI / 2, 0f, 0f, currentAngle, 22.25f, 0f);
        }
    }

    private void RenderDividers(MyMatrix pParentTransform)
    {
        float angleIncrement = 12.25f;
        float startingAngle = -42.875f;

        for (int i = 1; i <= 8; i++)
        {
            float currentAngle = startingAngle + (i - 1) * angleIncrement;
            string dividerName = $"Divider{i}";

            GenerateShape(pParentTransform, dividerName, PrimitiveType.Cube, Color.red, 20f, 2.25f, 10f,
                0f, 0f, (float)Math.PI / 2, currentAngle, 12.25f, 0f);
        }
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