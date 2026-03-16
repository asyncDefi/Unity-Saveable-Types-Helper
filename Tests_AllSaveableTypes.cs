using NUnit.Framework;
using UnityEngine;
using STypes;

public class Tests_AllSaveableTypes
{
    [Test]
    public void TransformState_RoundTrip_Works()
    {
        var go = new GameObject("TransformTest");
        var tr = go.transform;

        tr.position = new UnityEngine.Vector3(1, 2, 3);
        tr.rotation = UnityEngine.Quaternion.Euler(10, 20, 30);
        tr.localScale = new UnityEngine.Vector3(2, 2, 2);

        Transform state = Transform.FromUnity(tr);

        tr.position = Vector3.zero;
        tr.rotation = UnityEngine.Quaternion.identity;
        tr.localScale = Vector3.one;

        state.ApplyTo(tr);

        Assert.AreEqual(new UnityEngine.Vector3(1, 2, 3), tr.position);
        Assert.AreEqual(Quaternion.Euler(10, 20, 30).x, tr.rotation.x, 1e-4f);
        Assert.AreEqual(Quaternion.Euler(10, 20, 30).y, tr.rotation.y, 1e-4f);
        Assert.AreEqual(Quaternion.Euler(10, 20, 30).z, tr.rotation.z, 1e-4f);
        Assert.AreEqual(new UnityEngine.Vector3(2, 2, 2), tr.localScale);

        Object.DestroyImmediate(go);
    }

    [Test]
    public void BigInteger_RoundTrip_String_Based()
    {
        var big = new BigInteger("123456789012345678901234567890");
        System.Numerics.BigInteger value = big;

        Assert.AreEqual("123456789012345678901234567890", value.ToString());

        BigInteger again = value;
        Assert.AreEqual(value.ToString(), again.ToString());
    }

    [Test]
    public void CustomMatrix_Multiply_Works()
    {
        var a = new CustomMatrix(2, 2);
        a[0, 0] = 1;
        a[0, 1] = 2;
        a[1, 0] = 3;
        a[1, 1] = 4;

        var b = new CustomMatrix(2, 2);
        b[0, 0] = 5;
        b[0, 1] = 6;
        b[1, 0] = 7;
        b[1, 1] = 8;

        var c = CustomMatrix.Multiply(a, b);

        Assert.AreEqual(19, c[0, 0], 1e-4f);
        Assert.AreEqual(22, c[0, 1], 1e-4f);
        Assert.AreEqual(43, c[1, 0], 1e-4f);
        Assert.AreEqual(50, c[1, 1], 1e-4f);
    }

    [Test]
    public void MultiDimensionalList_RoundTrip_Works()
    {
        var list = new MultiDimensionalList<int>(2, 3, 0);

        list[0, 0] = 1;
        list[0, 1] = 2;
        list[0, 2] = 3;
        list[1, 0] = 4;
        list[1, 1] = 5;
        list[1, 2] = 6;

        Assert.AreEqual(2, list.Rows);
        Assert.AreEqual(3, list.Columns);

        list.Resize(3, 2, -1);

        Assert.AreEqual(3, list.Rows);
        Assert.AreEqual(2, list.Columns);

        Assert.AreEqual(1, list[0, 0]);
        Assert.AreEqual(2, list[0, 1]);
        Assert.AreEqual(4, list[1, 0]);
        Assert.AreEqual(5, list[1, 1]);
        Assert.AreEqual(3, list[2, 0]);
        Assert.AreEqual(6, list[2, 1]);
    }
}

