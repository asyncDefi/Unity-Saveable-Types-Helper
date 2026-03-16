using System;
using System.Collections.Generic;
using UnityEngine;


namespace STypes
{
    #region Vectors

    [System.Serializable]
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator UnityEngine.Vector2(Vector2 customVector)
        {
            return new UnityEngine.Vector2(customVector.x, customVector.y);
        }
        public static implicit operator Vector2(UnityEngine.Vector2 unityVector)
        {
            return new Vector2(unityVector.x, unityVector.y);
        }
    }


    [System.Serializable]
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator UnityEngine.Vector3(Vector3 customVector)
        {
            return new UnityEngine.Vector3(customVector.x, customVector.y, customVector.z);
        }

        public static implicit operator Vector3(UnityEngine.Vector3 unityVector)
        {
            return new Vector3(unityVector.x, unityVector.y, unityVector.z);
        }
    }

    [System.Serializable]
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static implicit operator UnityEngine.Vector4(Vector4 customVector)
        {
            return new UnityEngine.Vector4(customVector.x, customVector.y, customVector.z, customVector.w);
        }

        public static implicit operator Vector4(UnityEngine.Vector4 unityVector)
        {
            return new Vector4(unityVector.x, unityVector.y, unityVector.z, unityVector.w);
        }
    }

    #endregion

    #region Unity


    [System.Serializable]
    public struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        // Implicit conversion from custom Quaternion to Unity's Quaternion
        public static implicit operator UnityEngine.Quaternion(Quaternion customQuaternion)
        {
            return new UnityEngine.Quaternion(customQuaternion.x, customQuaternion.y, customQuaternion.z, customQuaternion.w);
        }

        // Implicit conversion from Unity's Quaternion to custom Quaternion
        public static implicit operator Quaternion(UnityEngine.Quaternion unityQuaternion)
        {
            return new Quaternion(unityQuaternion.x, unityQuaternion.y, unityQuaternion.z, unityQuaternion.w);
        }
    }

    [System.Serializable]
    public struct Transform
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public Transform(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        // Explicit factory from Unity Transform (world-space snapshot)
        public static Transform FromUnity(UnityEngine.Transform unityTransform)
        {
            return new Transform(
                unityTransform.position,
                unityTransform.rotation,
                unityTransform.localScale
            );
        }

        // Apply stored state back to an existing Transform
        public void ApplyTo(UnityEngine.Transform unityTransform)
        {
            unityTransform.position = position;
            unityTransform.rotation = rotation;
            unityTransform.localScale = scale;
        }

        // Implicit conversion from Unity's Transform to custom Transform (read-only, no allocations)
        public static implicit operator Transform(UnityEngine.Transform unityTransform)
        {
            return FromUnity(unityTransform);
        }
    }

    #region Rigibody
    [System.Serializable]
    public struct Rigidbody2D
    {
        public Vector2 velocity;
        public float mass;
        public float drag;
        public bool isKinematic;

        public Rigidbody2D(Vector2 velocity, float mass, float drag, bool isKinematic)
        {
            this.velocity = velocity;
            this.mass = mass;
            this.drag = drag;
            this.isKinematic = isKinematic;
        }

        // Explicit factory from Unity's Rigidbody2D (state snapshot)
        public static Rigidbody2D FromUnity(UnityEngine.Rigidbody2D unityRb)
        {
            return new Rigidbody2D(
                unityRb.linearVelocity,
                unityRb.mass,
                unityRb.linearDamping,
                unityRb.isKinematic
            );
        }

        // Apply stored state back to an existing Rigidbody2D
        public void ApplyTo(UnityEngine.Rigidbody2D unityRb)
        {
            unityRb.linearVelocity = velocity;
            unityRb.mass = mass;
            unityRb.linearDamping = drag;
            unityRb.isKinematic = isKinematic;
        }

        // Implicit conversion from Unity's Rigidbody2D to custom Rigidbody2D (read-only, no allocations)
        public static implicit operator Rigidbody2D(UnityEngine.Rigidbody2D unityRb)
        {
            return FromUnity(unityRb);
        }
    }

    [System.Serializable]
    public struct Rigidbody
    {
        public Vector3 velocity;
        public float mass;
        public float drag;
        public bool isKinematic;

        public Rigidbody(Vector3 velocity, float mass, float drag, bool isKinematic)
        {
            this.velocity = velocity;
            this.mass = mass;
            this.drag = drag;
            this.isKinematic = isKinematic;
        }

        // Explicit factory from Unity's Rigidbody (state snapshot)
        public static Rigidbody FromUnity(UnityEngine.Rigidbody unityRb)
        {
            return new Rigidbody(
                unityRb.linearVelocity,
                unityRb.mass,
                unityRb.linearDamping,
                unityRb.isKinematic
            );
        }

        // Apply stored state back to an existing Rigidbody
        public void ApplyTo(UnityEngine.Rigidbody unityRb)
        {
            unityRb.linearVelocity = velocity;
            unityRb.mass = mass;
            unityRb.linearDamping = drag;
            unityRb.isKinematic = isKinematic;
        }

        // Implicit conversion from Unity's Rigidbody to custom Rigidbody (read-only, no allocations)
        public static implicit operator Rigidbody(UnityEngine.Rigidbody unityRb)
        {
            return FromUnity(unityRb);
        }
    }

    #endregion



    [System.Serializable]
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        // Implicit conversion from Color to Unity Color
        public static implicit operator UnityEngine.Color(Color customColor)
        {
            return new UnityEngine.Color(customColor.r, customColor.g, customColor.b, customColor.a);
        }

        // Implicit conversion from Unity Color to Color
        public static implicit operator Color(UnityEngine.Color unityColor)
        {
            return new Color(unityColor.r, unityColor.g, unityColor.b, unityColor.a);
        }
    }


    #region Matrix

    [System.Serializable]
    public struct Matrix4x4
    {
        public float m00, m01, m02, m03;
        public float m10, m11, m12, m13;
        public float m20, m21, m22, m23;
        public float m30, m31, m32, m33;

        public Matrix4x4(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33)
        {
            this.m00 = m00; this.m01 = m01; this.m02 = m02; this.m03 = m03;
            this.m10 = m10; this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m20 = m20; this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m30 = m30; this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        // Implicit conversion to Unity Matrix4x4
        public static implicit operator UnityEngine.Matrix4x4(Matrix4x4 customMatrix)
        {
            UnityEngine.Matrix4x4 matrix = new UnityEngine.Matrix4x4
            {
                m00 = customMatrix.m00,
                m01 = customMatrix.m01,
                m02 = customMatrix.m02,
                m03 = customMatrix.m03,
                m10 = customMatrix.m10,
                m11 = customMatrix.m11,
                m12 = customMatrix.m12,
                m13 = customMatrix.m13,
                m20 = customMatrix.m20,
                m21 = customMatrix.m21,
                m22 = customMatrix.m22,
                m23 = customMatrix.m23,
                m30 = customMatrix.m30,
                m31 = customMatrix.m31,
                m32 = customMatrix.m32,
                m33 = customMatrix.m33
            };
            return matrix;
        }

        // Implicit conversion from Unity Matrix4x4
        public static implicit operator Matrix4x4(UnityEngine.Matrix4x4 unityMatrix)
        {
            return new Matrix4x4(
                unityMatrix.m00, unityMatrix.m01, unityMatrix.m02, unityMatrix.m03,
                unityMatrix.m10, unityMatrix.m11, unityMatrix.m12, unityMatrix.m13,
                unityMatrix.m20, unityMatrix.m21, unityMatrix.m22, unityMatrix.m23,
                unityMatrix.m30, unityMatrix.m31, unityMatrix.m32, unityMatrix.m33
            );
        }
    }


    [System.Serializable]
    public struct Matrix3x3
    {
        public float m00, m01, m02;
        public float m10, m11, m12;
        public float m20, m21, m22;

        public Matrix3x3(
            float m00, float m01, float m02,
            float m10, float m11, float m12,
            float m20, float m21, float m22)
        {
            this.m00 = m00; this.m01 = m01; this.m02 = m02;
            this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m20 = m20; this.m21 = m21; this.m22 = m22;
        }

        // Conversion from Matrix3x3 to a Unity Matrix4x4 (as Unity doesn't have a built-in Matrix3x3)
        public static implicit operator UnityEngine.Matrix4x4(Matrix3x3 customMatrix)
        {
            return new UnityEngine.Matrix4x4
            {
                m00 = customMatrix.m00,
                m01 = customMatrix.m01,
                m02 = customMatrix.m02,
                m10 = customMatrix.m10,
                m11 = customMatrix.m11,
                m12 = customMatrix.m12,
                m20 = customMatrix.m20,
                m21 = customMatrix.m21,
                m22 = customMatrix.m22,
                m33 = 1f // Fill the unused part with identity elements
            };
        }

        // Conversion from Unity Matrix4x4 (top-left 3x3 portion) to Matrix3x3
        public static implicit operator Matrix3x3(UnityEngine.Matrix4x4 unityMatrix)
        {
            return new Matrix3x3(
                unityMatrix.m00, unityMatrix.m01, unityMatrix.m02,
                unityMatrix.m10, unityMatrix.m11, unityMatrix.m12,
                unityMatrix.m20, unityMatrix.m21, unityMatrix.m22
            );
        }
    }

    [System.Serializable]
    public struct Matrix2x2
    {
        public float m00, m01;
        public float m10, m11;

        public Matrix2x2(float m00, float m01, float m10, float m11)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m10 = m10;
            this.m11 = m11;
        }

        // Convert from Matrix2x2 to Unity Matrix4x4
        public static implicit operator UnityEngine.Matrix4x4(Matrix2x2 customMatrix)
        {
            return new UnityEngine.Matrix4x4
            {
                m00 = customMatrix.m00,
                m01 = customMatrix.m01,
                m10 = customMatrix.m10,
                m11 = customMatrix.m11,
                m22 = 1f, // Set to identity
                m33 = 1f
            };
        }

        // Convert from Unity Matrix4x4 to Matrix2x2 (top-left 2x2 portion)
        public static implicit operator Matrix2x2(UnityEngine.Matrix4x4 unityMatrix)
        {
            return new Matrix2x2(
                unityMatrix.m00, unityMatrix.m01,
                unityMatrix.m10, unityMatrix.m11
            );
        }
    }



    [System.Serializable]
    public struct CustomMatrix
    {
        // Unity serializes fields, not auto-properties, so keep explicit fields
        public int rows;    // Number of rows
        public int columns; // Number of columns
        public float[] data;  // Matrix data

        public int Rows => rows;
        public int Columns => columns;

        public CustomMatrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.data = new float[rows * columns];  // Initialize data array
        }

        // Get or set elements of the matrix
        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                    throw new System.IndexOutOfRangeException("Matrix index out of range.");
                return data[row * Columns + column];  // Access element via calculated index
            }
            set
            {
                if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                    throw new System.IndexOutOfRangeException("Matrix index out of range.");
                data[row * Columns + column] = value;  // Set the element
            }
        }

        // Transpose the matrix (swap rows and columns)
        public CustomMatrix Transpose()
        {
            CustomMatrix transposed = new CustomMatrix(Columns, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    transposed[j, i] = this[i, j];
                }
            }
            return transposed;
        }

        // Multiply two matrices
        public static CustomMatrix Multiply(CustomMatrix a, CustomMatrix b)
        {
            if (a.Columns != b.Rows)
                throw new System.InvalidOperationException("Number of columns in the first matrix must match the number of rows in the second matrix.");

            CustomMatrix result = new CustomMatrix(a.Rows, b.Columns);

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < a.Columns; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        // Implicit cast to float array for serialization
        public static implicit operator float[](CustomMatrix matrix)
        {
            return matrix.data;
        }
    }

    #endregion


    #endregion

    #region Numeric

    [System.Serializable]
    public class BigInteger
    {
        [SerializeField] private string _numberString;

        /// <summary>
        /// The BigInteger value of this instance.
        /// </summary>
        public System.Numerics.BigInteger Value
        {
            get
            {
                if (string.IsNullOrEmpty(_numberString))
                    _numberString = "0";

                if (!System.Numerics.BigInteger.TryParse(_numberString, out var parsed))
                {
                    throw new FormatException($"Invalid BigInteger serialized value: '{_numberString}'");
                }

                return parsed;
  
            }
            set
            {
                _numberString = value.ToString();
            }
        }

        public BigInteger(string initialValue = "0")
        {
            _numberString = initialValue;
        }

        /// <summary>
        /// Implicit conversion from BigInteger to BigSten.
        /// </summary>
        public static implicit operator BigInteger(System.Numerics.BigInteger value)
        {
            return new BigInteger(value.ToString());
        }

        /// <summary>
        /// Implicit conversion from BigSten to BigInteger.
        /// </summary>
        public static implicit operator System.Numerics.BigInteger(BigInteger bigInteger)
        {
            return bigInteger.Value;
        }

        /// <summary>
        /// Implicit conversion from int to BigSten.
        /// </summary>
        public static implicit operator BigInteger(int value)
        {
            return new BigInteger(value.ToString());
        }

        /*
        /// <summary>
        /// Implicit conversion from BigSten to int.
        /// </summary>
        public static implicit operator int(BigSten bigSten)
        {
            BigInteger value = bigSten.Value;

            if (value > int.MaxValue || value < int.MinValue)
            {
                throw new OverflowException($"[BigSten] Value {value} exceeds int range.");
            }
            return (int)value;
        }
        */

        /// <summary>
        /// Implicit conversion from long to BigSten.
        /// </summary>
        public static implicit operator BigInteger(long value)
        {
            return new BigInteger(value.ToString());
        }

        /*
        /// <summary>
        /// Implicit conversion from BigSten to long.
        /// </summary>
        public static implicit operator long(BigSten bigSten)
        {
            BigInteger value = bigSten.Value;
            if (value > long.MaxValue || value < long.MinValue)
            {
                throw new OverflowException($"[BigSten] Value {value} exceeds long range.");
            }
            return (long)value;
        }
        */

        /// <summary>
        /// Override arithmetic operators for direct manipulation.
        /// </summary>
        public static BigInteger operator +(BigInteger a, BigInteger b)
        {
            return new BigInteger((a.Value + b.Value).ToString());
        }

        public static BigInteger operator +(BigInteger a, System.Numerics.BigInteger b)
        {
            return new BigInteger((a.Value + b).ToString());
        }

        public static BigInteger operator +(BigInteger a, long b)
        {
            return new BigInteger((a.Value + b).ToString());
        }

        public static BigInteger operator +(BigInteger a, int b)
        {
            return new BigInteger((a.Value + b).ToString());
        }

        public static BigInteger operator -(BigInteger a, BigInteger b)
        {
            return new BigInteger((a.Value - b.Value).ToString());
        }

        public static BigInteger operator -(BigInteger a, System.Numerics.BigInteger b)
        {
            return new BigInteger((a.Value - b).ToString());
        }

        public static BigInteger operator -(BigInteger a, long b)
        {
            return new BigInteger((a.Value - b).ToString());
        }

        public static BigInteger operator -(BigInteger a, int b)
        {
            return new BigInteger((a.Value - b).ToString());
        }

        public static BigInteger operator *(BigInteger a, BigInteger b)
        {
            return new BigInteger((a.Value * b.Value).ToString());
        }

        public static BigInteger operator /(BigInteger a, BigInteger b)
        {
            if (b.Value == 0)
            {
                throw new DivideByZeroException("[BigSten] Division by zero.");
            }
            return new BigInteger((a.Value / b.Value).ToString());
        }

        /// <summary>
        /// ToString override for easy debugging and logging.
        /// </summary>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_numberString))
                _numberString = "0";

            return _numberString;
        }
    }


    #endregion

    #region MultidimensionalList

    [System.Serializable]
    public class MultiDimensionalList<T>
    {
        [SerializeField] private List<T> _data;
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;

        public int Rows => _rows;
        public int Columns => _columns;

        public MultiDimensionalList(int rows, int columns, T defaultValue = default)
        {
            if (rows < 0) throw new ArgumentOutOfRangeException(nameof(rows));
            if (columns < 0) throw new ArgumentOutOfRangeException(nameof(columns));

            _rows = rows;
            _columns = columns;
            _data = new List<T>(rows * columns);

            for (int i = 0; i < rows * columns; i++)
            {
                _data.Add(defaultValue);
            }
        }

        public T this[int row, int column]
        {
            get
            {
                if (!IsValidIndex(row, column))
                    throw new IndexOutOfRangeException($"Index ({row}, {column}) is out of range.");

                return _data[GetIndex(row, column)];
            }
            set
            {
                if (!IsValidIndex(row, column))
                    throw new IndexOutOfRangeException($"Index ({row}, {column}) is out of range.");

                _data[GetIndex(row, column)] = value;
            }
        }

        public void Resize(int newRows, int newColumns, T defaultValue = default)
        {
            if (newRows < 0) throw new ArgumentOutOfRangeException(nameof(newRows));
            if (newColumns < 0) throw new ArgumentOutOfRangeException(nameof(newColumns));

            var newData = new List<T>(newRows * newColumns);

            for (int r = 0; r < newRows; r++)
            {
                for (int c = 0; c < newColumns; c++)
                {
                    if (IsValidIndex(r, c))
                    {
                        newData.Add(this[r, c]);
                    }
                    else
                    {
                        newData.Add(defaultValue);
                    }
                }
            }

            _rows = newRows;
            _columns = newColumns;
            _data = newData;
        }

        public bool IsValidIndex(int row, int column)
        {
            return row >= 0 && row < _rows && column >= 0 && column < _columns;
        }

        private int GetIndex(int row, int column)
        {
            return row * _columns + column;
        }

 
    }

    #endregion

}
