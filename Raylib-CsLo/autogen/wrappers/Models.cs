#pragma warning disable
namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class RaylibS
{
    /// <summary>
    /// Draw a line in 3D world space
    /// </summary>
    public void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLine3D(startPos, endPos, color);
    }

    /// <summary>
    /// Draw a point in 3D space, actually a small line
    /// </summary>
    public void DrawPoint3D(Vector3 position, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPoint3D(position, color);
    }

    /// <summary>
    /// Draw a circle in 3D world space
    /// </summary>
    public void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircle3D(center, radius, rotationAxis, rotationAngle, color);
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangle3D(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public void DrawTriangleStrip3D(Vector3* points, int pointCount, Color color)
    {
        /*|  Vector3 * => Vector3*  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangleStrip3D(points, pointCount, color);
    }

    /// <summary>
    /// Draw cube
    /// </summary>
    public void DrawCube(Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCube(position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube (Vector version)
    /// </summary>
    public void DrawCubeV(Vector3 position, Vector3 size, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeV(position, size, color);
    }

    /// <summary>
    /// Draw cube wires
    /// </summary>
    public void DrawCubeWires(Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeWires(position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube wires (Vector version)
    /// </summary>
    public void DrawCubeWiresV(Vector3 position, Vector3 size, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeWiresV(position, size, color);
    }

    /// <summary>
    /// Draw cube textured
    /// </summary>
    public void DrawCubeTexture(Texture2D texture, Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeTexture(texture, position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube with a region of a texture
    /// </summary>
    public void DrawCubeTextureRec(Texture2D texture, Rectangle source, Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeTextureRec(texture, source, position, width, height, length, color);
    }

    /// <summary>
    /// Draw sphere
    /// </summary>
    public void DrawSphere(Vector3 centerPos, float radius, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawSphere(centerPos, radius, color);
    }

    /// <summary>
    /// Draw sphere with extended parameters
    /// </summary>
    public void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawSphereEx(centerPos, radius, rings, slices, color);
    }

    /// <summary>
    /// Draw sphere wires
    /// </summary>
    public void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawSphereWires(centerPos, radius, rings, slices, color);
    }

    /// <summary>
    /// Draw a cylinder/cone
    /// </summary>
    public void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinder(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <summary>
    /// Draw a cylinder with base at startPos and top at endPos
    /// </summary>
    public void DrawCylinderEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinderEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <summary>
    /// Draw a cylinder/cone wires
    /// </summary>
    public void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinderWires(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <summary>
    /// Draw a cylinder wires with base at startPos and top at endPos
    /// </summary>
    public void DrawCylinderWiresEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinderWiresEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <summary>
    /// Draw a plane XZ
    /// </summary>
    public void DrawPlane(Vector3 centerPos, Vector2 size, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPlane(centerPos, size, color);
    }

    /// <summary>
    /// Draw a ray line
    /// </summary>
    public void DrawRay(Ray ray, Color color)
    {
        /*|  Ray => Ray  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRay(ray, color);
    }

    /// <summary>
    /// Draw a grid (centered at (0, 0, 0))
    /// </summary>
    public void DrawGrid(int slices, float spacing)
    {
        /*|  int => int  |*/
        /*|  float => float  |*/
        Raylib.DrawGrid(slices, spacing);
    }

    /// <summary>
    /// Load model from files (meshes and materials)
    /// </summary>
    public Model LoadModel(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadModel(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load model from generated mesh (default material)
    /// </summary>
    public Model LoadModelFromMesh(Mesh mesh)
    {
        /*|  Mesh => Mesh  |*/
        return Raylib.LoadModelFromMesh(mesh);
    }

    /// <summary>
    /// Unload model (including meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public void UnloadModel(Model model)
    {
        /*|  Model => Model  |*/
        Raylib.UnloadModel(model);
    }

    /// <summary>
    /// Unload model (but not meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public void UnloadModelKeepMeshes(Model model)
    {
        /*|  Model => Model  |*/
        Raylib.UnloadModelKeepMeshes(model);
    }

    /// <summary>
    /// Compute model bounding box limits (considers all meshes)
    /// </summary>
    public BoundingBox GetModelBoundingBox(Model model)
    {
        /*|  Model => Model  |*/
        return Raylib.GetModelBoundingBox(model);
    }

    /// <summary>
    /// Draw a model (with texture if set)
    /// </summary>
    public void DrawModel(Model model, Vector3 position, float scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModel(model, position, scale, tint);
    }

    /// <summary>
    /// Draw a model with extended parameters
    /// </summary>
    public void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModelEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <summary>
    /// Draw a model wires (with texture if set)
    /// </summary>
    public void DrawModelWires(Model model, Vector3 position, float scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModelWires(model, position, scale, tint);
    }

    /// <summary>
    /// Draw a model wires (with texture if set) with extended parameters
    /// </summary>
    public void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModelWiresEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <summary>
    /// Draw bounding box (wires)
    /// </summary>
    public void DrawBoundingBox(BoundingBox box, Color color)
    {
        /*|  BoundingBox => BoundingBox  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBoundingBox(box, color);
    }

    /// <summary>
    /// Draw a billboard texture
    /// </summary>
    public void DrawBillboard(Camera camera, Texture2D texture, Vector3 position, float size, Color tint)
    {
        /*|  Camera => Camera  |*/
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBillboard(camera, texture, position, size, tint);
    }

    /// <summary>
    /// Draw a billboard texture defined by source
    /// </summary>
    public void DrawBillboardRec(Camera camera, Texture2D texture, Rectangle source, Vector3 position, Vector2 size, Color tint)
    {
        /*|  Camera => Camera  |*/
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBillboardRec(camera, texture, source, position, size, tint);
    }

    /// <summary>
    /// Draw a billboard texture defined by source and rotation
    /// </summary>
    public void DrawBillboardPro(Camera camera, Texture2D texture, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint)
    {
        /*|  Camera => Camera  |*/
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBillboardPro(camera, texture, source, position, up, size, origin, rotation, tint);
    }

    /// <summary>
    /// Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    public void UploadMesh(Mesh* mesh, bool dynamic)
    {
        /*|  Mesh * => Mesh*  |*/
        /*|  bool => bool  |*/
        Raylib.UploadMesh(mesh, dynamic);
    }

    /// <summary>
    /// Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    public void UpdateMeshBuffer(Mesh mesh, int index, IntPtr data, int dataSize, int offset)
    {
        /*|  Mesh => Mesh  |*/
        /*|  int => int  |*/
        /*|  void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.UpdateMeshBuffer(mesh, index, dataLocal, dataSize, offset);
    }

    /// <summary>
    /// Unload mesh data from CPU and GPU
    /// </summary>
    public void UnloadMesh(Mesh mesh)
    {
        /*|  Mesh => Mesh  |*/
        Raylib.UnloadMesh(mesh);
    }

    /// <summary>
    /// Draw a 3d mesh with material and transform
    /// </summary>
    public void DrawMesh(Mesh mesh, Material material, Matrix transform)
    {
        /*|  Mesh => Mesh  |*/
        /*|  Material => Material  |*/
        /*|  Matrix => Matrix  |*/
        Raylib.DrawMesh(mesh, material, transform);
    }

    /// <summary>
    /// Draw multiple mesh instances with material and different transforms
    /// </summary>
    public void DrawMeshInstanced(Mesh mesh, Material material, Matrix* transforms, int instances)
    {
        /*|  Mesh => Mesh  |*/
        /*|  Material => Material  |*/
        /*|  Matrix * => Matrix*  |*/
        /*|  int => int  |*/
        Raylib.DrawMeshInstanced(mesh, material, transforms, instances);
    }

    /// <summary>
    /// Export mesh data to file, returns true on success
    /// </summary>
    public bool ExportMesh(Mesh mesh, string fileName)
    {
        /*|  Mesh => Mesh  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportMesh(mesh, fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Compute mesh bounding box limits
    /// </summary>
    public BoundingBox GetMeshBoundingBox(Mesh mesh)
    {
        /*|  Mesh => Mesh  |*/
        return Raylib.GetMeshBoundingBox(mesh);
    }

    /// <summary>
    /// Compute mesh tangents
    /// </summary>
    public void GenMeshTangents(Mesh* mesh)
    {
        /*|  Mesh * => Mesh*  |*/
        Raylib.GenMeshTangents(mesh);
    }

    /// <summary>
    /// Compute mesh binormals
    /// </summary>
    public void GenMeshBinormals(Mesh* mesh)
    {
        /*|  Mesh * => Mesh*  |*/
        Raylib.GenMeshBinormals(mesh);
    }

    /// <summary>
    /// Generate polygonal mesh
    /// </summary>
    public Mesh GenMeshPoly(int sides, float radius)
    {
        /*|  int => int  |*/
        /*|  float => float  |*/
        return Raylib.GenMeshPoly(sides, radius);
    }

    /// <summary>
    /// Generate plane mesh (with subdivisions)
    /// </summary>
    public Mesh GenMeshPlane(float width, float length, int resX, int resZ)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshPlane(width, length, resX, resZ);
    }

    /// <summary>
    /// Generate cuboid mesh
    /// </summary>
    public Mesh GenMeshCube(float width, float height, float length)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        return Raylib.GenMeshCube(width, height, length);
    }

    /// <summary>
    /// Generate sphere mesh (standard sphere)
    /// </summary>
    public Mesh GenMeshSphere(float radius, int rings, int slices)
    {
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshSphere(radius, rings, slices);
    }

    /// <summary>
    /// Generate half-sphere mesh (no bottom cap)
    /// </summary>
    public Mesh GenMeshHemiSphere(float radius, int rings, int slices)
    {
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshHemiSphere(radius, rings, slices);
    }

    /// <summary>
    /// Generate cylinder mesh
    /// </summary>
    public Mesh GenMeshCylinder(float radius, float height, int slices)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshCylinder(radius, height, slices);
    }

    /// <summary>
    /// Generate cone/pyramid mesh
    /// </summary>
    public Mesh GenMeshCone(float radius, float height, int slices)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshCone(radius, height, slices);
    }

    /// <summary>
    /// Generate torus mesh
    /// </summary>
    public Mesh GenMeshTorus(float radius, float size, int radSeg, int sides)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshTorus(radius, size, radSeg, sides);
    }

    /// <summary>
    /// Generate trefoil knot mesh
    /// </summary>
    public Mesh GenMeshKnot(float radius, float size, int radSeg, int sides)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshKnot(radius, size, radSeg, sides);
    }

    /// <summary>
    /// Generate heightmap mesh from image data
    /// </summary>
    public Mesh GenMeshHeightmap(Image heightmap, Vector3 size)
    {
        /*|  Image => Image  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GenMeshHeightmap(heightmap, size);
    }

    /// <summary>
    /// Generate cubes-based map mesh from image data
    /// </summary>
    public Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize)
    {
        /*|  Image => Image  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GenMeshCubicmap(cubicmap, cubeSize);
    }

    /// <summary>
    /// Load materials from model file
    /// </summary>
    public Material[] LoadMaterials(string fileName, int* materialCount)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.LoadMaterials(fileNameLocal.AsPtr(), materialCount));
    }

    /// <summary>
    /// Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)
    /// </summary>
    public Material LoadMaterialDefault()
    {
        return Raylib.LoadMaterialDefault();
    }

    /// <summary>
    /// Unload material from GPU memory (VRAM)
    /// </summary>
    public void UnloadMaterial(Material material)
    {
        /*|  Material => Material  |*/
        Raylib.UnloadMaterial(material);
    }

    /// <summary>
    /// Set texture for a material map type (MATERIAL_MAP_DIFFUSE, MATERIAL_MAP_SPECULAR...)
    /// </summary>
    public void SetMaterialTexture(Material* material, int mapType, Texture2D texture)
    {
        /*|  Material * => Material*  |*/
        /*|  int => int  |*/
        /*|  Texture2D => Texture2D  |*/
        Raylib.SetMaterialTexture(material, mapType, texture);
    }

    /// <summary>
    /// Set material for a mesh
    /// </summary>
    public void SetModelMeshMaterial(Model* model, int meshId, int materialId)
    {
        /*|  Model * => Model*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetModelMeshMaterial(model, meshId, materialId);
    }

    /// <summary>
    /// Load model animations from file
    /// </summary>
    public ModelAnimation[] LoadModelAnimations(string fileName, out uint animCount)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  unsigned int * => out uint  |*/
        return Helpers.PrtToArray(Raylib.LoadModelAnimations(fileNameLocal.AsPtr(), animCount));
    }

    /// <summary>
    /// Update model animation pose
    /// </summary>
    public void UpdateModelAnimation(Model model, ModelAnimation anim, int frame)
    {
        /*|  Model => Model  |*/
        /*|  ModelAnimation => ModelAnimation  |*/
        /*|  int => int  |*/
        Raylib.UpdateModelAnimation(model, anim, frame);
    }

    /// <summary>
    /// Unload animation data
    /// </summary>
    public void UnloadModelAnimation(ModelAnimation anim)
    {
        /*|  ModelAnimation => ModelAnimation  |*/
        Raylib.UnloadModelAnimation(anim);
    }

    /// <summary>
    /// Unload animation array data
    /// </summary>
    public void UnloadModelAnimations(ModelAnimation* animations, uint count)
    {
        /*|  ModelAnimation* => ModelAnimation*  |*/
        /*|  unsigned int => uint  |*/
        Raylib.UnloadModelAnimations(animations, count);
    }

    /// <summary>
    /// Check model animation skeleton match
    /// </summary>
    public bool IsModelAnimationValid(Model model, ModelAnimation anim)
    {
        /*|  Model => Model  |*/
        /*|  ModelAnimation => ModelAnimation  |*/
        return Raylib.IsModelAnimationValid(model, anim);
    }

    /// <summary>
    /// Check collision between two spheres
    /// </summary>
    public bool CheckCollisionSpheres(Vector3 center1, float radius1, Vector3 center2, float radius2)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        return Raylib.CheckCollisionSpheres(center1, radius1, center2, radius2);
    }

    /// <summary>
    /// Check collision between two bounding boxes
    /// </summary>
    public bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2)
    {
        /*|  BoundingBox => BoundingBox  |*/
        /*|  BoundingBox => BoundingBox  |*/
        return Raylib.CheckCollisionBoxes(box1, box2);
    }

    /// <summary>
    /// Check collision between box and sphere
    /// </summary>
    public bool CheckCollisionBoxSphere(BoundingBox box, Vector3 center, float radius)
    {
        /*|  BoundingBox => BoundingBox  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        return Raylib.CheckCollisionBoxSphere(box, center, radius);
    }

    /// <summary>
    /// Get collision info between ray and sphere
    /// </summary>
    public RayCollision GetRayCollisionSphere(Ray ray, Vector3 center, float radius)
    {
        /*|  Ray => Ray  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        return Raylib.GetRayCollisionSphere(ray, center, radius);
    }

    /// <summary>
    /// Get collision info between ray and box
    /// </summary>
    public RayCollision GetRayCollisionBox(Ray ray, BoundingBox box)
    {
        /*|  Ray => Ray  |*/
        /*|  BoundingBox => BoundingBox  |*/
        return Raylib.GetRayCollisionBox(ray, box);
    }

    /// <summary>
    /// Get collision info between ray and model
    /// </summary>
    public RayCollision GetRayCollisionModel(Ray ray, Model model)
    {
        /*|  Ray => Ray  |*/
        /*|  Model => Model  |*/
        return Raylib.GetRayCollisionModel(ray, model);
    }

    /// <summary>
    /// Get collision info between ray and mesh
    /// </summary>
    public RayCollision GetRayCollisionMesh(Ray ray, Mesh mesh, Matrix transform)
    {
        /*|  Ray => Ray  |*/
        /*|  Mesh => Mesh  |*/
        /*|  Matrix => Matrix  |*/
        return Raylib.GetRayCollisionMesh(ray, mesh, transform);
    }

    /// <summary>
    /// Get collision info between ray and triangle
    /// </summary>
    public RayCollision GetRayCollisionTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        /*|  Ray => Ray  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GetRayCollisionTriangle(ray, p1, p2, p3);
    }

    /// <summary>
    /// Get collision info between ray and quad
    /// </summary>
    public RayCollision GetRayCollisionQuad(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        /*|  Ray => Ray  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GetRayCollisionQuad(ray, p1, p2, p3, p4);
    }

}
#pragma warning restore
