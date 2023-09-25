using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Please note - I used the Bus class to experiment with methods and find errors within my ProbabilityMachine class, so the following code may not generate an object.
public class Bus
{
    private MyVector _Position { get; set; }
    private MyVector _Rotation { get; set; }
    private MyVector _Scale { get; set; }

    public Bus(MyVector pPosition, MyVector pRotation, MyVector pScale)
    {
        _Position = pPosition;
        _Rotation = pRotation;
        _Scale = pScale;

        InitialiseBus();
    }

    public void InitialiseBus()
    {
        MyMatrix parentScale = MyMatrix.CreateScale(_Scale);
        MyMatrix parentRotationX = MyMatrix.CreateRotationX(_Rotation.X);
        MyMatrix parentRotationY = MyMatrix.CreateRotationY(_Rotation.Y);
        MyMatrix parentRotationZ = MyMatrix.CreateRotationZ(_Rotation.Z);
        MyMatrix parentPosition = MyMatrix.CreateTranslation(_Position);
        MyMatrix parentTransform = parentPosition.Multiply(parentRotationX.Multiply(parentRotationY.Multiply(parentRotationZ.Multiply(parentScale))));

        CreateBus(parentTransform);
    }

    public void CreateBus(MyMatrix pParentTransform)
    {
        GenerateShape(pParentTransform, "body", PrimitiveType.Cube, Color.red, 4f, 1.5f, 1.5f, 0f, 0f, 0f, 0f, 0f, 0f);
        GenerateShape(pParentTransform, "frontleftwheel", PrimitiveType.Cylinder, Color.black, 0.8f, 0.2f, 0.8f, (float)Math.PI / 2, 0f, 0f, -1.5f, -0.9f, -0.8f);
        GenerateShape(pParentTransform, "frontrightwheel", PrimitiveType.Cylinder, Color.black, 0.8f, 0.2f, 0.8f, (float)Math.PI / 2, 0f, 0f, -1.5f, -0.9f, 0.8f);
        GenerateShape(pParentTransform, "backleftwheel", PrimitiveType.Cylinder, Color.black, 0.8f, 0.2f, 0.8f, (float)Math.PI / 2, 0f, 0f, 1.5f, -0.9f, -0.8f);
        GenerateShape(pParentTransform, "backrightwheel", PrimitiveType.Cylinder, Color.black, 0.8f, 0.2f, 0.8f, (float)Math.PI / 2, 0f, 0f, 1.5f, -0.9f, 0.8f);
    }

    private void CreateBody(MyMatrix pParentTransform)
    {
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        body.GetComponent<Renderer>().material.color = Color.red;

        MyMatrix bodyScale = MyMatrix.CreateScale(new MyVector(4f, 1.5f, 1.5f));

        MyMatrix bodyTransform = pParentTransform.Multiply(bodyScale);
        bodyTransform.SetTransform(body);
    }

    private void CreateWheels(MyMatrix pParentTransform)
    {
        GameObject frontleftwheel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject frontrightwheel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject backleftwheel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject backrightwheel = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        frontleftwheel.GetComponent<Renderer>().material.color = Color.black;
        frontrightwheel.GetComponent<Renderer>().material.color = Color.black;
        backleftwheel.GetComponent<Renderer>().material.color = Color.black;
        backrightwheel.GetComponent<Renderer>().material.color = Color.black;

        MyMatrix wheelScale = MyMatrix.CreateScale(new MyVector(0.8f, 0.2f, 0.8f));

        MyMatrix wheelRotation = MyMatrix.CreateRotationX((float)Math.PI / 2);

        MyMatrix frontleftwheelTranslation = MyMatrix.CreateTranslation(new MyVector(-1.5f, -0.9f, -0.8f));
        MyMatrix frontrightwheelTranslation = MyMatrix.CreateTranslation(new MyVector(-1.5f, -0.9f, 0.8f));
        MyMatrix backleftwheelTranslation = MyMatrix.CreateTranslation(new MyVector(1.5f, -0.9f, -0.8f));
        MyMatrix backrightwheelTranslation = MyMatrix.CreateTranslation(new MyVector(1.5f, -0.9f, 0.8f));

        MyMatrix wheelRotationScale = wheelRotation.Multiply(wheelScale);

        MyMatrix frontleftwheelMatrix = frontleftwheelTranslation.Multiply(wheelRotationScale);
        MyMatrix frontrightwheelMatrix = frontrightwheelTranslation.Multiply(wheelRotationScale);
        MyMatrix backleftwheelMatrix = backleftwheelTranslation.Multiply(wheelRotationScale);
        MyMatrix backrightwheelMatrix = backrightwheelTranslation.Multiply(wheelRotationScale);

        MyMatrix frontleftwheelTransform = pParentTransform.Multiply(frontleftwheelMatrix);
        MyMatrix frontrightwheelTransform = pParentTransform.Multiply(frontrightwheelMatrix);
        MyMatrix backleftwheelTransform = pParentTransform.Multiply(backleftwheelMatrix);
        MyMatrix backrightwheelTransform = pParentTransform.Multiply(backrightwheelMatrix);

        frontleftwheelTransform.SetTransform(frontleftwheel);
        frontrightwheelTransform.SetTransform(frontrightwheel);
        backleftwheelTransform.SetTransform(backleftwheel);
        backrightwheelTransform.SetTransform(backrightwheel);

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

        /*if (xRotation != 0)
        {
            MyMatrix localRotationX = MyMatrix.CreateRotationX(xRotation);
        }
        if (yRotation != 0)
        {
            MyMatrix localRotationY = MyMatrix.CreateRotationY(yRotation);
        }
        if (zRotation != 0)
        {
            MyMatrix localRotationZ = MyMatrix.CreateRotationZ(zRotation);
        }*/

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