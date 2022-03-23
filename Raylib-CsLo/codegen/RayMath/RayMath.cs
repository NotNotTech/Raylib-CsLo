// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class RayMath
{
    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Clamp(float value, float min, float max);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Lerp(float start, float end, float amount);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Normalize(float value, float start, float end);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Remap(float value, float inputStart, float inputEnd, float outputStart, float outputEnd);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Zero();

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2One();

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Add(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2AddValue(Vector2 v, float add);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Subtract(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2SubtractValue(Vector2 v, float sub);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector2Length(Vector2 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector2LengthSqr(Vector2 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector2DotProduct(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector2Distance(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector2DistanceSqr(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector2Angle(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Scale(Vector2 v, float scale);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Multiply(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Negate(Vector2 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Divide(Vector2 v1, Vector2 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Normalize(Vector2 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Transform(Vector2 v, Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Lerp(Vector2 v1, Vector2 v2, float amount);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Reflect(Vector2 v, Vector2 normal);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2Rotate(Vector2 v, float angle);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector2 Vector2MoveTowards(Vector2 v, Vector2 target, float maxDistance);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Zero();

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3One();

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Add(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3AddValue(Vector3 v, float add);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Subtract(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3SubtractValue(Vector3 v, float sub);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Scale(Vector3 v, float scalar);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Multiply(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3CrossProduct(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Perpendicular(Vector3 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector3Length(Vector3 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector3LengthSqr(Vector3 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector3DotProduct(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector3Distance(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector3DistanceSqr(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float Vector3Angle(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Negate(Vector3 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Divide(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Normalize(Vector3 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void Vector3OrthoNormalize(Vector3* v1, Vector3* v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Transform(Vector3 v, Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3RotateByQuaternion(Vector3 v, Quaternion q);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Lerp(Vector3 v1, Vector3 v2, float amount);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Reflect(Vector3 v, Vector3 normal);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Min(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Max(Vector3 v1, Vector3 v2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Barycenter(Vector3 p, Vector3 a, Vector3 b, Vector3 c);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 Vector3Unproject(Vector3 source, Matrix4x4 projection, Matrix4x4 view);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Float3 Vector3ToFloatV(Vector3 v);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float MatrixDeterminant(Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float MatrixTrace(Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixTranspose(Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixInvert(Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixNormalize(Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixIdentity();

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixAdd(Matrix4x4 left, Matrix4x4 right);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixSubtract(Matrix4x4 left, Matrix4x4 right);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixMultiply(Matrix4x4 left, Matrix4x4 right);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixTranslate(float x, float y, float z);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixRotate(Vector3 axis, float angle);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixRotateX(float angle);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixRotateY(float angle);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixRotateZ(float angle);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixRotateXYZ(Vector3 ang);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixRotateZYX(Vector3 ang);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixScale(float x, float y, float z);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixFrustum(double left, double right, double bottom, double top, double near, double far);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixPerspective(double fovy, double aspect, double near, double far);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixOrtho(double left, double right, double bottom, double top, double near, double far);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 MatrixLookAt(Vector3 eye, Vector3 target, Vector3 up);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Float16 MatrixToFloatV(Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionAdd(Quaternion q1, Quaternion q2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionAddValue(Quaternion q, float add);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionSubtract(Quaternion q1, Quaternion q2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionSubtractValue(Quaternion q, float sub);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionIdentity();

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float QuaternionLength(Quaternion q);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionNormalize(Quaternion q);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionInvert(Quaternion q);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionMultiply(Quaternion q1, Quaternion q2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionScale(Quaternion q, float mul);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionDivide(Quaternion q1, Quaternion q2);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionLerp(Quaternion q1, Quaternion q2, float amount);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionNlerp(Quaternion q1, Quaternion q2, float amount);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionSlerp(Quaternion q1, Quaternion q2, float amount);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionFromVector3ToVector3(Vector3 from, Vector3 to);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionFromMatrix(Matrix4x4 mat);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 QuaternionToMatrix(Quaternion q);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionFromAxisAngle(Vector3 axis, float angle);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void QuaternionToAxisAngle(Quaternion q, Vector3* outAxis, float* outAngle);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionFromEuler(float pitch, float yaw, float roll);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Vector3 QuaternionToEuler(Quaternion q);

    /// <summary>  </summary>
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Quaternion QuaternionTransform(Quaternion q, Matrix4x4 mat);

}

#pragma warning restore
