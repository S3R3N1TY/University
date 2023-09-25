using System;
using System.Collections.Generic;
using UnityEngine;

public class MyMatrix
{

    private float[,] elements;

    public MyMatrix(float pRow0Column0,
        float pRow0Column1,
        float pRow0Column2,
        float pRow0Column3,
        float pRow1Column0,
        float pRow1Column1,
        float pRow1Column2,
        float pRow1Column3,
        float pRow2Column0,
        float pRow2Column1,
        float pRow2Column2,
        float pRow2Column3,
        float pRow3Column0,
        float pRow3Column1,
        float pRow3Column2,
        float pRow3Column3)
    {
        elements = new float[4, 4] {{ pRow0Column0, pRow0Column1, pRow0Column2, pRow0Column3},
        {pRow1Column0, pRow1Column1, pRow1Column2, pRow1Column3},
        {pRow2Column0, pRow2Column1, pRow2Column2, pRow2Column3},
        {pRow3Column0, pRow3Column1, pRow3Column2, pRow3Column3}};
    }

    public float GetElement(int pRow, int pColumn)
    {
        float element = elements[pRow, pColumn];
        return element;
    }

    public static MyMatrix CreateIdentity()
    {
        MyMatrix Identity = new MyMatrix(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        return Identity;
    }

    public static MyMatrix CreateTranslation(MyVector pTranslation)
    {
        MyMatrix matrix = MyMatrix.CreateIdentity();
        matrix.elements[0, 3] = pTranslation.X;
        matrix.elements[1, 3] = pTranslation.Y;
        matrix.elements[2, 3] = pTranslation.Z;
        matrix.elements[3, 3] = pTranslation.W;

        return matrix;
    }

    public static MyMatrix CreateScale(MyVector pScale)
    {
        MyMatrix matrix = MyMatrix.CreateIdentity();
        float[] scales = new float[3] { pScale.X, pScale.Y, pScale.Z };
        for (int i = 0; i < 3; i++)
        {
            matrix.elements[i, i] = matrix.elements[i, i] * scales[i];
        }
        return matrix;

    }

    public static MyMatrix CreateRotationX(float pAngle)
    {
        MyMatrix matrix = MyMatrix.CreateIdentity();
        matrix.elements[1, 1] = MathF.Cos(pAngle);
        matrix.elements[1, 2] = -MathF.Sin(pAngle);
        matrix.elements[2, 1] = MathF.Sin(pAngle);
        matrix.elements[2, 2] = MathF.Cos(pAngle);

        return matrix;

    }

    public static MyMatrix CreateRotationY(float pAngle)
    {
        MyMatrix matrix = MyMatrix.CreateIdentity();
        matrix.elements[0, 0] = MathF.Cos(pAngle);
        matrix.elements[0, 2] = MathF.Sin(pAngle);
        matrix.elements[2, 0] = -MathF.Sin(pAngle);
        matrix.elements[2, 2] = MathF.Cos(pAngle);

        return matrix;

    }

    public static MyMatrix CreateRotationZ(float pAngle)
    {
        MyMatrix matrix = MyMatrix.CreateIdentity();
        matrix.elements[0, 0] = MathF.Cos(pAngle);
        matrix.elements[0, 1] = -MathF.Sin(pAngle);
        matrix.elements[1, 0] = MathF.Sin(pAngle);
        matrix.elements[1, 1] = MathF.Cos(pAngle);

        return matrix;
    }

    public MyVector Multiply(MyVector pVector)
    {
        float pVectorW = pVector.W;
        float tempX = this.elements[0, 0] * pVector.X + this.elements[0, 1] * pVector.Y + this.elements[0, 2] * pVector.Z + this.elements[0, 3];
        float tempY = this.elements[1, 0] * pVector.X + this.elements[1, 1] * pVector.Y + this.elements[1, 2] * pVector.Z + this.elements[1, 3];
        float tempZ = this.elements[2, 0] * pVector.X + this.elements[2, 1] * pVector.Y + this.elements[2, 2] * pVector.Z + this.elements[2, 3];
        float tempW = this.elements[3, 0] * pVector.X + this.elements[3, 1] * pVector.Y + this.elements[3, 2] * pVector.Z + this.elements[3, 3];

        MyVector vector = new MyVector(tempX, tempY, tempZ, tempW);
        return vector;

    }

    public MyMatrix Multiply(MyMatrix pMatrix)
    {
        //row and column

        MyMatrix matrix = MyMatrix.CreateIdentity();
        matrix.elements[0, 0] = this.elements[0, 0] * pMatrix.elements[0, 0] + this.elements[0, 1] * pMatrix.elements[1, 0] + this.elements[0, 2] * pMatrix.elements[2, 0] + this.elements[0, 3] * pMatrix.elements[3, 0];
        matrix.elements[0, 1] = this.elements[0, 0] * pMatrix.elements[0, 1] + this.elements[0, 1] * pMatrix.elements[1, 1] + this.elements[0, 2] * pMatrix.elements[2, 1] + this.elements[0, 3] * pMatrix.elements[3, 1];
        matrix.elements[0, 2] = this.elements[0, 0] * pMatrix.elements[0, 2] + this.elements[0, 1] * pMatrix.elements[1, 2] + this.elements[0, 2] * pMatrix.elements[2, 2] + this.elements[0, 3] * pMatrix.elements[3, 2];
        matrix.elements[0, 3] = this.elements[0, 0] * pMatrix.elements[0, 3] + this.elements[0, 1] * pMatrix.elements[1, 3] + this.elements[0, 2] * pMatrix.elements[2, 3] + this.elements[0, 3] * pMatrix.elements[3, 3];
        matrix.elements[1, 0] = this.elements[1, 0] * pMatrix.elements[0, 0] + this.elements[1, 1] * pMatrix.elements[1, 0] + this.elements[1, 2] * pMatrix.elements[2, 0] + this.elements[1, 3] * pMatrix.elements[3, 0];
        matrix.elements[1, 1] = this.elements[1, 0] * pMatrix.elements[0, 1] + this.elements[1, 1] * pMatrix.elements[1, 1] + this.elements[1, 2] * pMatrix.elements[2, 1] + this.elements[1, 3] * pMatrix.elements[3, 1];
        matrix.elements[1, 2] = this.elements[1, 0] * pMatrix.elements[0, 2] + this.elements[1, 1] * pMatrix.elements[1, 2] + this.elements[1, 2] * pMatrix.elements[2, 2] + this.elements[1, 3] * pMatrix.elements[3, 2];
        matrix.elements[1, 3] = this.elements[1, 0] * pMatrix.elements[0, 3] + this.elements[1, 1] * pMatrix.elements[1, 3] + this.elements[1, 2] * pMatrix.elements[2, 3] + this.elements[1, 3] * pMatrix.elements[3, 3];
        matrix.elements[2, 0] = this.elements[2, 0] * pMatrix.elements[0, 0] + this.elements[2, 1] * pMatrix.elements[1, 0] + this.elements[2, 2] * pMatrix.elements[2, 0] + this.elements[2, 3] * pMatrix.elements[3, 0];
        matrix.elements[2, 1] = this.elements[2, 0] * pMatrix.elements[0, 1] + this.elements[2, 1] * pMatrix.elements[1, 1] + this.elements[2, 2] * pMatrix.elements[2, 1] + this.elements[2, 3] * pMatrix.elements[3, 1];
        matrix.elements[2, 2] = this.elements[2, 0] * pMatrix.elements[0, 2] + this.elements[2, 1] * pMatrix.elements[1, 2] + this.elements[2, 2] * pMatrix.elements[2, 2] + this.elements[2, 3] * pMatrix.elements[3, 2];
        matrix.elements[2, 3] = this.elements[2, 0] * pMatrix.elements[0, 3] + this.elements[2, 1] * pMatrix.elements[1, 3] + this.elements[2, 2] * pMatrix.elements[2, 3] + this.elements[2, 3] * pMatrix.elements[3, 3];
        matrix.elements[3, 0] = this.elements[3, 0] * pMatrix.elements[0, 0] + this.elements[3, 1] * pMatrix.elements[1, 0] + this.elements[3, 2] * pMatrix.elements[2, 0] + this.elements[3, 3] * pMatrix.elements[3, 0];
        matrix.elements[3, 1] = this.elements[3, 0] * pMatrix.elements[0, 1] + this.elements[3, 1] * pMatrix.elements[1, 1] + this.elements[3, 2] * pMatrix.elements[2, 1] + this.elements[3, 3] * pMatrix.elements[3, 1];
        matrix.elements[3, 2] = this.elements[3, 0] * pMatrix.elements[0, 2] + this.elements[3, 1] * pMatrix.elements[1, 2] + this.elements[3, 2] * pMatrix.elements[2, 2] + this.elements[3, 3] * pMatrix.elements[3, 2];
        matrix.elements[3, 3] = this.elements[3, 0] * pMatrix.elements[0, 3] + this.elements[3, 1] * pMatrix.elements[1, 3] + this.elements[3, 2] * pMatrix.elements[2, 3] + this.elements[3, 3] * pMatrix.elements[3, 3];

        return matrix;
    }

    public MyMatrix Inverse()
    {
        //No.
        return null;
    }

    public void SetTransform(GameObject pObject)
    {
        Transform transform = pObject.transform;
        SetPosition(transform);
        SetRotation(transform);
        SetScale(transform);

    }

    private void SetPosition(Transform pTransform)
    {
        Vector3 positionVector;
        positionVector.x = GetElement(0, 3);
        positionVector.y = GetElement(1, 3);
        positionVector.z = GetElement(2, 3);

        pTransform.position = positionVector;
    }

    private void SetScale(Transform pTransform)
    {
        Vector3 scale;
        MyVector xColumn = new MyVector(GetElement(0, 0), GetElement(1, 0), GetElement(2, 0), GetElement(3, 0));
        float xScale = xColumn.Magnitude();
        MyVector yColumn = new MyVector(GetElement(0, 1), GetElement(1, 1), GetElement(2, 1), GetElement(3, 1));
        float yScale = yColumn.Magnitude();
        MyVector zColumn = new MyVector(GetElement(0, 2), GetElement(1, 2), GetElement(2, 2), GetElement(3, 2));
        float zScale = zColumn.Magnitude();

        scale.x = xScale;
        scale.y = yScale;
        scale.z = zScale;

        pTransform.localScale = scale;

    }

    private void SetRotation(Transform pTransform)
    {
        Vector3 forward;
        Vector3 upwards;

        forward.x = GetElement(0, 2);
        forward.y = GetElement(1, 2);
        forward.z = GetElement(2, 2);

        upwards.x = GetElement(0, 1);
        upwards.y = GetElement(1, 1);
        upwards.z = GetElement(2, 1);

        pTransform.rotation = Quaternion.LookRotation(forward, upwards);
    }
    public override string ToString()
    {
        string result = GetElement(0, 0) + GetElement(0, 1) + GetElement(0, 2) + GetElement(0, 3) + "\n" +
            GetElement(1, 0) + GetElement(1, 1) + GetElement(1, 2) + GetElement(1, 3) + "\n" +
            GetElement(2, 0) + GetElement(2, 1) + GetElement(2, 2) + GetElement(2, 3) + "\n" +
            GetElement(3, 0) + GetElement(3, 1) + GetElement(3, 2) + GetElement(3, 3) + "\n";
        return result;
    }
}