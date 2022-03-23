// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class RayMathS
{
    /// <summary>  </summary>
    public static float Clamp(float value, float min, float max)
    {
        return RayMath.Clamp(value, min, max);
    }

    /// <summary>  </summary>
    public static float Lerp(float start, float end, float amount)
    {
        return RayMath.Lerp(start, end, amount);
    }

    /// <summary>  </summary>
    public static float Normalize(float value, float start, float end)
    {
        return RayMath.Normalize(value, start, end);
    }

    /// <summary>  </summary>
    public static float Remap(float value, float inputStart, float inputEnd, float outputStart, float outputEnd)
    {
        return RayMath.Remap(value, inputStart, inputEnd, outputStart, outputEnd);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Zero()
    {
        return RayMath.Vector2Zero();
    }

    /// <summary>  </summary>
    public static Vector2 Vector2One()
    {
        return RayMath.Vector2One();
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Add(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2Add(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2AddValue(Vector2 v, float add)
    {
        return RayMath.Vector2AddValue(v, add);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Subtract(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2Subtract(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2SubtractValue(Vector2 v, float sub)
    {
        return RayMath.Vector2SubtractValue(v, sub);
    }

    /// <summary>  </summary>
    public static float Vector2Length(Vector2 v)
    {
        return RayMath.Vector2Length(v);
    }

    /// <summary>  </summary>
    public static float Vector2LengthSqr(Vector2 v)
    {
        return RayMath.Vector2LengthSqr(v);
    }

    /// <summary>  </summary>
    public static float Vector2DotProduct(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2DotProduct(v1, v2);
    }

    /// <summary>  </summary>
    public static float Vector2Distance(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2Distance(v1, v2);
    }

    /// <summary>  </summary>
    public static float Vector2DistanceSqr(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2DistanceSqr(v1, v2);
    }

    /// <summary>  </summary>
    public static float Vector2Angle(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2Angle(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Scale(Vector2 v, float scale)
    {
        return RayMath.Vector2Scale(v, scale);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Multiply(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2Multiply(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Negate(Vector2 v)
    {
        return RayMath.Vector2Negate(v);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Divide(Vector2 v1, Vector2 v2)
    {
        return RayMath.Vector2Divide(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Normalize(Vector2 v)
    {
        return RayMath.Vector2Normalize(v);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Transform(Vector2 v, Matrix4x4 mat)
    {
        return RayMath.Vector2Transform(v, mat);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Lerp(Vector2 v1, Vector2 v2, float amount)
    {
        return RayMath.Vector2Lerp(v1, v2, amount);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Reflect(Vector2 v, Vector2 normal)
    {
        return RayMath.Vector2Reflect(v, normal);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2Rotate(Vector2 v, float angle)
    {
        return RayMath.Vector2Rotate(v, angle);
    }

    /// <summary>  </summary>
    public static Vector2 Vector2MoveTowards(Vector2 v, Vector2 target, float maxDistance)
    {
        return RayMath.Vector2MoveTowards(v, target, maxDistance);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Zero()
    {
        return RayMath.Vector3Zero();
    }

    /// <summary>  </summary>
    public static Vector3 Vector3One()
    {
        return RayMath.Vector3One();
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Add(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Add(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3AddValue(Vector3 v, float add)
    {
        return RayMath.Vector3AddValue(v, add);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Subtract(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Subtract(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3SubtractValue(Vector3 v, float sub)
    {
        return RayMath.Vector3SubtractValue(v, sub);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Scale(Vector3 v, float scalar)
    {
        return RayMath.Vector3Scale(v, scalar);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Multiply(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Multiply(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3CrossProduct(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3CrossProduct(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Perpendicular(Vector3 v)
    {
        return RayMath.Vector3Perpendicular(v);
    }

    /// <summary>  </summary>
    public static float Vector3Length(Vector3 v)
    {
        return RayMath.Vector3Length(v);
    }

    /// <summary>  </summary>
    public static float Vector3LengthSqr(Vector3 v)
    {
        return RayMath.Vector3LengthSqr(v);
    }

    /// <summary>  </summary>
    public static float Vector3DotProduct(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3DotProduct(v1, v2);
    }

    /// <summary>  </summary>
    public static float Vector3Distance(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Distance(v1, v2);
    }

    /// <summary>  </summary>
    public static float Vector3DistanceSqr(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3DistanceSqr(v1, v2);
    }

    /// <summary>  </summary>
    public static float Vector3Angle(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Angle(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Negate(Vector3 v)
    {
        return RayMath.Vector3Negate(v);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Divide(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Divide(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Normalize(Vector3 v)
    {
        return RayMath.Vector3Normalize(v);
    }

    /// <summary>  </summary>
    public static void Vector3OrthoNormalize(Vector3* v1, Vector3* v2)
    {
        RayMath.Vector3OrthoNormalize(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Transform(Vector3 v, Matrix4x4 mat)
    {
        return RayMath.Vector3Transform(v, mat);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3RotateByQuaternion(Vector3 v, Quaternion q)
    {
        return RayMath.Vector3RotateByQuaternion(v, q);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Lerp(Vector3 v1, Vector3 v2, float amount)
    {
        return RayMath.Vector3Lerp(v1, v2, amount);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Reflect(Vector3 v, Vector3 normal)
    {
        return RayMath.Vector3Reflect(v, normal);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Min(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Min(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Max(Vector3 v1, Vector3 v2)
    {
        return RayMath.Vector3Max(v1, v2);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Barycenter(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
    {
        return RayMath.Vector3Barycenter(p, a, b, c);
    }

    /// <summary>  </summary>
    public static Vector3 Vector3Unproject(Vector3 source, Matrix4x4 projection, Matrix4x4 view)
    {
        return RayMath.Vector3Unproject(source, projection, view);
    }

    /// <summary>  </summary>
    public static Float3 Vector3ToFloatV(Vector3 v)
    {
        return RayMath.Vector3ToFloatV(v);
    }

    /// <summary>  </summary>
    public static float MatrixDeterminant(Matrix4x4 mat)
    {
        return RayMath.MatrixDeterminant(mat);
    }

    /// <summary>  </summary>
    public static float MatrixTrace(Matrix4x4 mat)
    {
        return RayMath.MatrixTrace(mat);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixTranspose(Matrix4x4 mat)
    {
        return RayMath.MatrixTranspose(mat);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixInvert(Matrix4x4 mat)
    {
        return RayMath.MatrixInvert(mat);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixNormalize(Matrix4x4 mat)
    {
        return RayMath.MatrixNormalize(mat);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixIdentity()
    {
        return RayMath.MatrixIdentity();
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixAdd(Matrix4x4 left, Matrix4x4 right)
    {
        return RayMath.MatrixAdd(left, right);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixSubtract(Matrix4x4 left, Matrix4x4 right)
    {
        return RayMath.MatrixSubtract(left, right);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixMultiply(Matrix4x4 left, Matrix4x4 right)
    {
        return RayMath.MatrixMultiply(left, right);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixTranslate(float x, float y, float z)
    {
        return RayMath.MatrixTranslate(x, y, z);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixRotate(Vector3 axis, float angle)
    {
        return RayMath.MatrixRotate(axis, angle);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixRotateX(float angle)
    {
        return RayMath.MatrixRotateX(angle);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixRotateY(float angle)
    {
        return RayMath.MatrixRotateY(angle);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixRotateZ(float angle)
    {
        return RayMath.MatrixRotateZ(angle);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixRotateXYZ(Vector3 ang)
    {
        return RayMath.MatrixRotateXYZ(ang);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixRotateZYX(Vector3 ang)
    {
        return RayMath.MatrixRotateZYX(ang);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixScale(float x, float y, float z)
    {
        return RayMath.MatrixScale(x, y, z);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixFrustum(double left, double right, double bottom, double top, double near, double far)
    {
        return RayMath.MatrixFrustum(left, right, bottom, top, near, far);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixPerspective(double fovy, double aspect, double near, double far)
    {
        return RayMath.MatrixPerspective(fovy, aspect, near, far);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixOrtho(double left, double right, double bottom, double top, double near, double far)
    {
        return RayMath.MatrixOrtho(left, right, bottom, top, near, far);
    }

    /// <summary>  </summary>
    public static Matrix4x4 MatrixLookAt(Vector3 eye, Vector3 target, Vector3 up)
    {
        return RayMath.MatrixLookAt(eye, target, up);
    }

    /// <summary>  </summary>
    public static Float16 MatrixToFloatV(Matrix4x4 mat)
    {
        return RayMath.MatrixToFloatV(mat);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionAdd(Quaternion q1, Quaternion q2)
    {
        return RayMath.QuaternionAdd(q1, q2);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionAddValue(Quaternion q, float add)
    {
        return RayMath.QuaternionAddValue(q, add);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionSubtract(Quaternion q1, Quaternion q2)
    {
        return RayMath.QuaternionSubtract(q1, q2);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionSubtractValue(Quaternion q, float sub)
    {
        return RayMath.QuaternionSubtractValue(q, sub);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionIdentity()
    {
        return RayMath.QuaternionIdentity();
    }

    /// <summary>  </summary>
    public static float QuaternionLength(Quaternion q)
    {
        return RayMath.QuaternionLength(q);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionNormalize(Quaternion q)
    {
        return RayMath.QuaternionNormalize(q);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionInvert(Quaternion q)
    {
        return RayMath.QuaternionInvert(q);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionMultiply(Quaternion q1, Quaternion q2)
    {
        return RayMath.QuaternionMultiply(q1, q2);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionScale(Quaternion q, float mul)
    {
        return RayMath.QuaternionScale(q, mul);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionDivide(Quaternion q1, Quaternion q2)
    {
        return RayMath.QuaternionDivide(q1, q2);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionLerp(Quaternion q1, Quaternion q2, float amount)
    {
        return RayMath.QuaternionLerp(q1, q2, amount);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionNlerp(Quaternion q1, Quaternion q2, float amount)
    {
        return RayMath.QuaternionNlerp(q1, q2, amount);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionSlerp(Quaternion q1, Quaternion q2, float amount)
    {
        return RayMath.QuaternionSlerp(q1, q2, amount);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionFromVector3ToVector3(Vector3 from, Vector3 to)
    {
        return RayMath.QuaternionFromVector3ToVector3(from, to);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionFromMatrix(Matrix4x4 mat)
    {
        return RayMath.QuaternionFromMatrix(mat);
    }

    /// <summary>  </summary>
    public static Matrix4x4 QuaternionToMatrix(Quaternion q)
    {
        return RayMath.QuaternionToMatrix(q);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionFromAxisAngle(Vector3 axis, float angle)
    {
        return RayMath.QuaternionFromAxisAngle(axis, angle);
    }

    /// <summary>  </summary>
    public static void QuaternionToAxisAngle(Quaternion q, Vector3* outAxis, float* outAngle)
    {
        RayMath.QuaternionToAxisAngle(q, outAxis, outAngle);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionFromEuler(float pitch, float yaw, float roll)
    {
        return RayMath.QuaternionFromEuler(pitch, yaw, roll);
    }

    /// <summary>  </summary>
    public static Vector3 QuaternionToEuler(Quaternion q)
    {
        return RayMath.QuaternionToEuler(q);
    }

    /// <summary>  </summary>
    public static Quaternion QuaternionTransform(Quaternion q, Matrix4x4 mat)
    {
        return RayMath.QuaternionTransform(q, mat);
    }

}

#pragma warning restore
