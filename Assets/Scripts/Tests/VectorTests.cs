using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class VectorTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void MyVectorConstructor()
    {
        // Use the Assert class to test conditions
        MyVector myVector = new MyVector(30, 40, 0);
        Assert.AreEqual(myVector.X, 30);
        Assert.AreEqual(myVector.Y, 40);
        Assert.AreEqual(myVector.Z, 0);
    }

    [Test]
    public void Add()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(20, 30, 0);
        MyVector thirdVector = firstVector.Add(secondVector);
        Assert.AreEqual(thirdVector.X, 50);
        Assert.AreEqual(thirdVector.Y, 70);
        Assert.AreEqual(thirdVector.Z, 0);
    }

    [Test]
    public void Subtract()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(5, 10, 0);
        MyVector thirdVector = firstVector.Subtract(secondVector);
        Assert.AreEqual(thirdVector.X, 25);
        Assert.AreEqual(thirdVector.Y, 30);
        Assert.AreEqual(thirdVector.Z, 0);
    }

    [Test]
    public void Multiply()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float scalar = 10;
        MyVector secondVector = firstVector.Multiply(scalar);
        Assert.AreEqual(secondVector.X, 300);
        Assert.AreEqual(secondVector.Y, 400);
        Assert.AreEqual(secondVector.Z, 0);
    }
    [Test]
    public void Divide()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float scalar = 10;
        MyVector secondVector = firstVector.Divide(scalar);
        Assert.AreEqual(secondVector.X, 3);
        Assert.AreEqual(secondVector.Y, 4);
        Assert.AreEqual(secondVector.Z, 0);
    }
    [Test]
    public void Magnitude()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float magnitude = firstVector.Magnitude();
        Assert.AreEqual(magnitude, 50);
    }

    [Test]
    public void Normalise()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector normalisedVector = firstVector.Normalise();
        float magnitude = normalisedVector.Magnitude();
        Assert.AreEqual(magnitude, 1);
        Assert.AreEqual(normalisedVector.X, 3.0f / 5);
        Assert.AreEqual(normalisedVector.Y, 4.0f / 5);
        Assert.AreEqual(normalisedVector.Z, 0);

    }

    [Test]
    public void LimitToBelowLimit()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector limitedVector = firstVector.LimitTo(60);
        float magnitude = limitedVector.Magnitude();
        Assert.AreEqual(magnitude, 50);

    }
    [Test]
    public void LimitToAboveLimit()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector limitedVector = firstVector.LimitTo(30);
        float magnitude = limitedVector.Magnitude();
        Assert.AreEqual(magnitude, 30);

    }

    [Test]
    public void DotProductIsZero()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(40, -30, 0);
        float dotProduct = firstVector.DotProduct(secondVector);
        Assert.AreEqual(dotProduct, 0);

    }
    [Test]
    public void DotProductIsPositive()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(50, 0, 0);
        float dotProduct = firstVector.DotProduct(secondVector);
        Assert.Greater(dotProduct, 0);

    }
    [Test]
    public void DotProductIsNegative()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(0, -50, 0);
        float dotProduct = firstVector.DotProduct(secondVector);
        Assert.Less(dotProduct, 0);

    }
    [Test]
    public void Interpolate()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(60, 80, 0);
        float interpolation = 0.25f;
        MyVector interpolatedVector = firstVector.Interpolate(secondVector, interpolation);
        Assert.AreEqual(interpolatedVector.X, 37.5f);
        Assert.AreEqual(interpolatedVector.Y, 50);
        Assert.AreEqual(interpolatedVector.Z, 0);

    }

    [Test]
    public void RotateX()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(0, 30, 40);
        float rotation = (float)Math.PI / 2;
        MyVector interpolatedVector = firstVector.RotateX(rotation);
        Assert.AreEqual(interpolatedVector.X, 0);
        Assert.AreEqual(interpolatedVector.Y, -40f, 0.001);
        Assert.AreEqual(interpolatedVector.Z, 30f, 0.001);

    }
    [Test]
    public void RotateY()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 0, 40);
        float rotation = (float)Math.PI / 2;
        MyVector interpolatedVector = firstVector.RotateY(rotation);
        Assert.AreEqual(interpolatedVector.X, 40f, 0.001);
        Assert.AreEqual(interpolatedVector.Y, 0);
        Assert.AreEqual(interpolatedVector.Z, -30f, 0.001);

    }
    [Test]
    public void RotateZ()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        float rotation = (float)Math.PI / 2;
        MyVector interpolatedVector = firstVector.RotateZ(rotation);
        Assert.AreEqual(interpolatedVector.X, -40f, 0.001);
        Assert.AreEqual(interpolatedVector.Y, 30f, 0.001);
        Assert.AreEqual(interpolatedVector.Z, 0);

    }
    [Test]
    public void AngleBetween()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(-40, 30, 0);
        float angleBetween = firstVector.AngleBetween(secondVector);
        Assert.AreEqual(angleBetween, Math.PI / 2, 0.001);

    }
    [Test]
    public void CrossProduct()
    {
        // Use the Assert class to test conditions
        MyVector firstVector = new MyVector(30, 40, 0);
        MyVector secondVector = new MyVector(-40, 30, 0);
        MyVector crossProduct = firstVector.CrossProduct(secondVector);
        Assert.AreEqual(crossProduct.X, 0f, 0.001);
        Assert.AreEqual(crossProduct.Y, 0f, 0.001);
        Assert.AreEqual(crossProduct.Z, 2500f, 0.001);

    }

}
