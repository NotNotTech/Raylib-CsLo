#pragma warning disable
namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class RaylibS
{
    /// <summary>
    /// Set texture and rectangle to be used on shapes drawing
    /// </summary>
    public void SetShapesTexture(Texture2D texture, Rectangle source)
    {
        Raylib.SetShapesTexture(texture, source);
    }

    /// <summary>
    /// Draw a pixel
    /// </summary>
    public void DrawPixel(int posX, int posY, Color color)
    {
        Raylib.DrawPixel(posX, posY, color);
    }

    /// <summary>
    /// Draw a pixel (Vector version)
    /// </summary>
    public void DrawPixelV(Vector2 position, Color color)
    {
        Raylib.DrawPixelV(position, color);
    }

    /// <summary>
    /// Draw a line
    /// </summary>
    public void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        Raylib.DrawLine(startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <summary>
    /// Draw a line (Vector version)
    /// </summary>
    public void DrawLineV(Vector2 startPos, Vector2 endPos, Color color)
    {
        Raylib.DrawLineV(startPos, endPos, color);
    }

    /// <summary>
    /// Draw a line defining thickness
    /// </summary>
    public void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        Raylib.DrawLineEx(startPos, endPos, thick, color);
    }

    /// <summary>
    /// Draw a line using cubic-bezier curves in-out
    /// </summary>
    public void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        Raylib.DrawLineBezier(startPos, endPos, thick, color);
    }

    /// <summary>
    /// Draw line using quadratic bezier curves with a control point
    /// </summary>
    public void DrawLineBezierQuad(Vector2 startPos, Vector2 endPos, Vector2 controlPos, float thick, Color color)
    {
        Raylib.DrawLineBezierQuad(startPos, endPos, controlPos, thick, color);
    }

    /// <summary>
    /// Draw line using cubic bezier curves with 2 control points
    /// </summary>
    public void DrawLineBezierCubic(Vector2 startPos, Vector2 endPos, Vector2 startControlPos, Vector2 endControlPos, float thick, Color color)
    {
        Raylib.DrawLineBezierCubic(startPos, endPos, startControlPos, endControlPos, thick, color);
    }

    /// <summary>
    /// Draw lines sequence
    /// </summary>
    public void DrawLineStrip(Vector2* points, int pointCount, Color color)
    {
        Raylib.DrawLineStrip(points, pointCount, color);
    }

    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    public void DrawCircle(int centerX, int centerY, float radius, Color color)
    {
        Raylib.DrawCircle(centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    public void DrawCircleSector(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    public void DrawCircleSectorLines(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    public void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2)
    {
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);
    }

    /// <summary>
    /// Draw a color-filled circle (Vector version)
    /// </summary>
    public void DrawCircleV(Vector2 center, float radius, Color color)
    {
        Raylib.DrawCircleV(center, radius, color);
    }

    /// <summary>
    /// Draw circle outline
    /// </summary>
    public void DrawCircleLines(int centerX, int centerY, float radius, Color color)
    {
        Raylib.DrawCircleLines(centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw ellipse
    /// </summary>
    public void DrawEllipse(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        Raylib.DrawEllipse(centerX, centerY, radiusH, radiusV, color);
    }

    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    public void DrawEllipseLines(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        Raylib.DrawEllipseLines(centerX, centerY, radiusH, radiusV, color);
    }

    /// <summary>
    /// Draw ring
    /// </summary>
    public void DrawRing(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw ring outline
    /// </summary>
    public void DrawRingLines(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public void DrawRectangle(int posX, int posY, int width, int height, Color color)
    {
        Raylib.DrawRectangle(posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle (Vector version)
    /// </summary>
    public void DrawRectangleV(Vector2 position, Vector2 size, Color color)
    {
        Raylib.DrawRectangleV(position, size, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public void DrawRectangleRec(Rectangle rec, Color color)
    {
        Raylib.DrawRectangleRec(rec, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    public void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color)
    {
        Raylib.DrawRectanglePro(rec, origin, rotation, color);
    }

    /// <summary>
    /// Draw a vertical-gradient-filled rectangle
    /// </summary>
    public void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        Raylib.DrawRectangleGradientV(posX, posY, width, height, color1, color2);
    }

    /// <summary>
    /// Draw a horizontal-gradient-filled rectangle
    /// </summary>
    public void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        Raylib.DrawRectangleGradientH(posX, posY, width, height, color1, color2);
    }

    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    public void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4)
    {
        Raylib.DrawRectangleGradientEx(rec, col1, col2, col3, col4);
    }

    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    public void DrawRectangleLines(int posX, int posY, int width, int height, Color color)
    {
        Raylib.DrawRectangleLines(posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    public void DrawRectangleLinesEx(Rectangle rec, float lineThick, Color color)
    {
        Raylib.DrawRectangleLinesEx(rec, lineThick, color);
    }

    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    public void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color)
    {
        Raylib.DrawRectangleRounded(rec, roundness, segments, color);
    }

    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    public void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, float lineThick, Color color)
    {
        Raylib.DrawRectangleRoundedLines(rec, roundness, segments, lineThick, color);
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        Raylib.DrawTriangle(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw triangle outline (vertex in counter-clockwise order!)
    /// </summary>
    public void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        Raylib.DrawTriangleLines(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    public void DrawTriangleFan(Vector2* points, int pointCount, Color color)
    {
        Raylib.DrawTriangleFan(points, pointCount, color);
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public void DrawTriangleStrip(Vector2* points, int pointCount, Color color)
    {
        Raylib.DrawTriangleStrip(points, pointCount, color);
    }

    /// <summary>
    /// Draw a regular polygon (Vector version)
    /// </summary>
    public void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        Raylib.DrawPoly(center, sides, radius, rotation, color);
    }

    /// <summary>
    /// Draw a polygon outline of n sides
    /// </summary>
    public void DrawPolyLines(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);
    }

    /// <summary>
    /// Draw a polygon outline of n sides with extended parameters
    /// </summary>
    public void DrawPolyLinesEx(Vector2 center, int sides, float radius, float rotation, float lineThick, Color color)
    {
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, lineThick, color);
    }

    /// <summary>
    /// Check collision between two rectangles
    /// </summary>
    public bool CheckCollisionRecs(Rectangle rec1, Rectangle rec2)
    {
        return Raylib.CheckCollisionRecs(rec1, rec2);
    }

    /// <summary>
    /// Check collision between two circles
    /// </summary>
    public bool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2)
    {
        return Raylib.CheckCollisionCircles(center1, radius1, center2, radius2);
    }

    /// <summary>
    /// Check collision between circle and rectangle
    /// </summary>
    public bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec)
    {
        return Raylib.CheckCollisionCircleRec(center, radius, rec);
    }

    /// <summary>
    /// Check if point is inside rectangle
    /// </summary>
    public bool CheckCollisionPointRec(Vector2 point, Rectangle rec)
    {
        return Raylib.CheckCollisionPointRec(point, rec);
    }

    /// <summary>
    /// Check if point is inside circle
    /// </summary>
    public bool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius)
    {
        return Raylib.CheckCollisionPointCircle(point, center, radius);
    }

    /// <summary>
    /// Check if point is inside a triangle
    /// </summary>
    public bool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        return Raylib.CheckCollisionPointTriangle(point, p1, p2, p3);
    }

    /// <summary>
    /// Check the collision between two lines defined by two points each, returns collision point by reference
    /// </summary>
    public bool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, Vector2* collisionPoint)
    {
        return Raylib.CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, collisionPoint);
    }

    /// <summary>
    /// Check if point belongs to line created between two points [p1] and [p2] with defined margin in pixels [threshold]
    /// </summary>
    public bool CheckCollisionPointLine(Vector2 point, Vector2 p1, Vector2 p2, int threshold)
    {
        return Raylib.CheckCollisionPointLine(point, p1, p2, threshold);
    }

    /// <summary>
    /// Get collision rectangle for two rectangles collision
    /// </summary>
    public Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2)
    {
        return Raylib.GetCollisionRec(rec1, rec2);
    }

}
#pragma warning restore
