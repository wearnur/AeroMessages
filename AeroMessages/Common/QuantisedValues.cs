using System.Numerics;
using System;
using Aero.Gen.Attributes;

namespace AeroMessages.Common
{
    /// <summary>
    /// A float in [-1, 1] as sign and magnitude: bit 15 the sign, the low 15 bits the magnitude * 32767 (the 1962
    /// client's reader; poses' full orientations and aims).
    /// </summary>
    [AeroBlock]
    public struct QuantisedFloat
    {
        public ushort Value;

        public static implicit operator float(QuantisedFloat d)
        {
            float magnitude = (d.Value & 0x7FFF) / 32767f;
            return (d.Value & 0x8000) != 0 ? -magnitude : magnitude;
        }

        public static implicit operator QuantisedFloat(float d)
        {
            ushort magnitude = (ushort)Math.Min(32767.0, Math.Ceiling(Math.Abs(d) * 32767.0));
            return new QuantisedFloat { Value = (ushort)(d < 0 ? magnitude | 0x8000 : magnitude) };
        }

        public override string ToString() => $"{(float)this}";
    }

    [AeroBlock]
    public struct QuantisedVector2
    {
        public QuantisedFloat X;
        public QuantisedFloat Y;
        
        public static implicit operator Vector2(QuantisedVector2 d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y
            };
        }

        public static implicit operator QuantisedVector2(Vector2 d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y
            };
        }
    }
    
    [AeroBlock]
    public struct QuantisedVector3
    {
        public QuantisedFloat X;
        public QuantisedFloat Y;
        public QuantisedFloat Z;
        
        public static implicit operator Vector3(QuantisedVector3 d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y,
                Z = d.Z
            };
        }

        public static implicit operator QuantisedVector3(Vector3 d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y,
                Z = d.Z
            };
        }
    }
    
    [AeroBlock]
    public struct QuantisedVector4
    {
        public QuantisedFloat X;
        public QuantisedFloat Y;
        public QuantisedFloat Z;
        public QuantisedFloat W;
        
        public static implicit operator Vector4(QuantisedVector4 d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y,
                Z = d.Z,
                W = d.W
            };
        }

        public static implicit operator QuantisedVector4(Vector4 d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y,
                Z = d.Z,
                W = d.W
            };
        }
    }
    
    [AeroBlock]
    public struct QuantisedQuaternion
    {
        public QuantisedFloat X;
        public QuantisedFloat Y;
        public QuantisedFloat Z;
        public QuantisedFloat W;
        
        public static implicit operator Quaternion(QuantisedQuaternion d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y,
                Z = d.Z,
                W = d.W
            };
        }

        public static implicit operator QuantisedQuaternion(Quaternion d)
        {
            return new()
            {
                X = d.X,
                Y = d.Y,
                Z = d.Z,
                W = d.W
            };
        }
    }
}