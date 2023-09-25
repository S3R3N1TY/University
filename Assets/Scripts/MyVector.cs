using System;
using System.Collections.Generic;

public class MyVector
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    public float W { get; private set; }

    public MyVector(float pX, float pY, float pZ, float pW = 1)
    {
        X = pX;
        Y = pY;
        Z = pZ;
        W = pW;
    }
    public MyVector Copy()
    {
        return null;
    }
    public MyVector Add(MyVector pVector)
    {
        float tempX = pVector.X + this.X;
        float tempY = pVector.Y + this.Y;
        float tempZ = pVector.Z + this.Z;

        MyVector NewVector = new MyVector(tempX, tempY, tempZ);
        return NewVector;
    }
    public MyVector Subtract(MyVector pVector)
    {
        float tempX = this.X - pVector.X;
        float tempY = this.Y - pVector.Y;
        float tempZ = this.Z - pVector.Z;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public MyVector Multiply(float pScalar)
    {
        float tempX = this.X * pScalar;
        float tempY = this.Y * pScalar;
        float tempZ = this.Z * pScalar;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public MyVector Divide(float pScalar)
    {
        float tempX = this.X / pScalar;
        float tempY = this.Y / pScalar;
        float tempZ = this.Z / pScalar;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public float Magnitude()
    {
        float newMag = MathF.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        return newMag;
    }
    public MyVector Normalise()
    {
        float newMag = MathF.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);

        float normX = this.X / newMag;
        float normY = this.Y / newMag;
        float normZ = this.Z / newMag;

        MyVector newVector = new MyVector(normX, normY, normZ);
        return newVector;
    }
    public float DotProduct(MyVector pVector)
    {
        float tempX = this.X * pVector.X;
        float tempY = this.Y * pVector.Y;
        float tempZ = this.Z * pVector.Z;

        float dotProduct = tempX + tempY + tempZ;
        return dotProduct;
    }
    public MyVector RotateX(float pRadians)
    {
        float tempX = this.X;
        float tempY = MathF.Cos(pRadians) * this.Y - MathF.Sin(pRadians) * this.Z;
        float tempZ = MathF.Sin(pRadians) * this.Y + MathF.Cos(pRadians) * this.Z;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public MyVector RotateY(float pRadians)
    {
        float tempX = MathF.Cos(pRadians) * this.X + MathF.Sin(pRadians) * this.Z;
        float tempY = this.Y;
        float tempZ = -1 * MathF.Sin(pRadians) * this.X + MathF.Cos(pRadians) * this.Z;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public MyVector RotateZ(float pRadians)
    {
        float tempX = -1 * MathF.Sin(pRadians) * this.Y + MathF.Cos(pRadians) * this.X;
        float tempY = MathF.Sin(pRadians) * this.X + MathF.Cos(pRadians) * this.Y;
        float tempZ = this.Z;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public MyVector LimitTo(float pMax)
    {
        float tempX = this.X;
        float tempY = this.Y;
        float tempZ = this.Z;

        float newMag = Magnitude();
        if (newMag > pMax)
        {
            float ratio = pMax / newMag;
            tempX = tempX * ratio;
            tempY = tempY * ratio;
            tempZ = tempZ * ratio;
        }

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public MyVector Interpolate(MyVector pVector, float pInterpolation)
    {
        float tempX = this.X + (pVector.X - this.X) * pInterpolation;
        float tempY = this.Y + (pVector.Y - this.Y) * pInterpolation;
        float tempZ = this.Z + (pVector.Z - this.Z) * pInterpolation;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public float AngleBetween(MyVector pVector)
    {
        float tempX = this.X * pVector.X;
        float tempY = this.Y * pVector.Y;
        float tempZ = this.Z * pVector.Z;

        float dot = tempX + tempY + tempZ;

        float thisMag = MathF.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        float pMag = MathF.Sqrt(pVector.X * pVector.X + pVector.Y * pVector.Y + pVector.Z * pVector.Z);
        float mag = thisMag * pMag;

        float angle = MathF.Acos(dot / mag);
        return angle;

    }
    public MyVector CrossProduct(MyVector pVector)
    {
        float tempX = this.Y * pVector.Z - this.Z * pVector.Y;
        float tempY = this.Z * pVector.X - this.X * pVector.Z;
        float tempZ = this.X * pVector.Y - this.Y * pVector.X;

        MyVector newVector = new MyVector(tempX, tempY, tempZ);
        return newVector;
    }
    public override string ToString()
    {
        string result = "X: " + X + " " + "Y: " + Y + " " + "Z: " + Z;
        return result;
    }
}