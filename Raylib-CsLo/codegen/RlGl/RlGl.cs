// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

using System.Runtime.InteropServices;
using System.Numerics;

public unsafe partial class RlGl
{
    /// <summary>
    /// Choose the current matrix to be transformed
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlMatrixMode(int mode);

    /// <summary>
    /// Push the current matrix to stack
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlPushMatrix();

    /// <summary>
    /// Pop lattest inserted matrix from stack
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlPopMatrix();

    /// <summary>
    /// Reset current matrix to identity matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlLoadIdentity();

    /// <summary>
    /// Multiply the current matrix by a translation matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlTranslatef(float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by a rotation matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlRotatef(float angle, float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by a scaling matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlScalef(float x, float y, float z);

    /// <summary>
    /// Multiply the current matrix by another matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlMultMatrixf(float* matf);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlFrustum(double left, double right, double bottom, double top, double znear, double zfar);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlOrtho(double left, double right, double bottom, double top, double znear, double zfar);

    /// <summary>
    /// Set the viewport area
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlViewport(int x, int y, int width, int height);

    /// <summary>
    /// Initialize drawing mode (how to organize vertex)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlBegin(int mode);

    /// <summary>
    /// Finish vertex providing
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnd();

    /// <summary>
    /// Define one vertex (position) - 2 int
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlVertex2i(int x, int y);

    /// <summary>
    /// Define one vertex (position) - 2 float
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlVertex2f(float x, float y);

    /// <summary>
    /// Define one vertex (position) - 3 float
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlVertex3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (texture coordinate) - 2 float
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlTexCoord2f(float x, float y);

    /// <summary>
    /// Define one vertex (normal) - 3 float
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlNormal3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (color) - 4 byte
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlColor4ub(byte r, byte g, byte b, byte a);

    /// <summary>
    /// Define one vertex (color) - 3 float
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlColor3f(float x, float y, float z);

    /// <summary>
    /// Define one vertex (color) - 4 float
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlColor4f(float x, float y, float z, float w);

    /// <summary>
    /// Enable vertex array (VAO, if supported)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool rlEnableVertexArray(uint vaoId);

    /// <summary>
    /// Disable vertex array (VAO, if supported)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableVertexArray();

    /// <summary>
    /// Enable vertex buffer (VBO)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableVertexBuffer(uint id);

    /// <summary>
    /// Disable vertex buffer (VBO)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableVertexBuffer();

    /// <summary>
    /// Enable vertex buffer element (VBO element)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableVertexBufferElement(uint id);

    /// <summary>
    /// Disable vertex buffer element (VBO element)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableVertexBufferElement();

    /// <summary>
    /// Enable vertex attribute index
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableVertexAttribute(uint index);

    /// <summary>
    /// Disable vertex attribute index
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableVertexAttribute(uint index);

    /// <summary>
    /// Enable attribute state pointer
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableStatePointer(int vertexAttribType, void* buffer);

    /// <summary>
    /// Disable attribute state pointer
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableStatePointer(int vertexAttribType);

    /// <summary>
    /// Select and active a texture slot
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlActiveTextureSlot(int slot);

    /// <summary>
    /// Enable texture
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableTexture(uint id);

    /// <summary>
    /// Disable texture
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableTexture();

    /// <summary>
    /// Enable texture cubemap
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableTextureCubemap(uint id);

    /// <summary>
    /// Disable texture cubemap
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableTextureCubemap();

    /// <summary>
    /// Set texture parameters (filter, wrap)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlTextureParameters(uint id, int param, int value);

    /// <summary>
    /// Enable shader program
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableShader(uint id);

    /// <summary>
    /// Disable shader program
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableShader();

    /// <summary>
    /// Enable render texture (fbo)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableFramebuffer(uint id);

    /// <summary>
    /// Disable render texture (fbo), return to default framebuffer
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableFramebuffer();

    /// <summary>
    /// Activate multiple draw color buffers
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlActiveDrawBuffers(int count);

    /// <summary>
    /// Enable color blending
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableColorBlend();

    /// <summary>
    /// Disable color blending
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableColorBlend();

    /// <summary>
    /// Enable depth test
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableDepthTest();

    /// <summary>
    /// Disable depth test
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableDepthTest();

    /// <summary>
    /// Enable depth write
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableDepthMask();

    /// <summary>
    /// Disable depth write
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableDepthMask();

    /// <summary>
    /// Enable backface culling
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableBackfaceCulling();

    /// <summary>
    /// Disable backface culling
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableBackfaceCulling();

    /// <summary>
    /// Enable scissor test
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableScissorTest();

    /// <summary>
    /// Disable scissor test
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableScissorTest();

    /// <summary>
    /// Scissor test
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlScissor(int x, int y, int width, int height);

    /// <summary>
    /// Enable wire mode
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableWireMode();

    /// <summary>
    /// Disable wire mode
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableWireMode();

    /// <summary>
    /// Set the line drawing width
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetLineWidth(float width);

    /// <summary>
    /// Get the line drawing width
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float rlGetLineWidth();

    /// <summary>
    /// Enable line aliasing
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableSmoothLines();

    /// <summary>
    /// Disable line aliasing
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableSmoothLines();

    /// <summary>
    /// Enable stereo rendering
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlEnableStereoRender();

    /// <summary>
    /// Disable stereo rendering
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDisableStereoRender();

    /// <summary>
    /// Check if stereo render is enabled
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool rlIsStereoRenderEnabled();

    /// <summary>
    /// Clear color buffer with color
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlClearColor(byte r, byte g, byte b, byte a);

    /// <summary>
    /// Clear used screen buffers (color and depth)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlClearScreenBuffers();

    /// <summary>
    /// Check and log OpenGL error codes
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlCheckErrors();

    /// <summary>
    /// Set blending mode
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetBlendMode(int mode);

    /// <summary>
    /// Set blending mode factor and equation (using OpenGL factors)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation);

    /// <summary>
    /// Initialize rlgl (buffers, shaders, textures, states)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlglInit(int width, int height);

    /// <summary>
    /// De-inititialize rlgl (buffers, shaders, textures)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlglClose();

    /// <summary>
    /// Load OpenGL extensions (loader function required)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlLoadExtensions(void* loader);

    /// <summary>
    /// Get current OpenGL version
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int rlGetVersion();

    /// <summary>
    /// Get default framebuffer width
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int rlGetFramebufferWidth();

    /// <summary>
    /// Get default framebuffer height
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int rlGetFramebufferHeight();

    /// <summary>
    /// Get default texture id
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlGetTextureIdDefault();

    /// <summary>
    /// Get default shader id
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlGetShaderIdDefault();

    /// <summary>
    /// Get default shader locations
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int* rlGetShaderLocsDefault();

    /// <summary>
    /// Load a render batch system
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern rlRenderBatch rlLoadRenderBatch(int numBuffers, int bufferElements);

    /// <summary>
    /// Unload render batch system
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUnloadRenderBatch(rlRenderBatch batch);

    /// <summary>
    /// Draw render batch data (Update->Draw->Reset)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDrawRenderBatch(rlRenderBatch* batch);

    /// <summary>
    /// Set the active render batch for rlgl (NULL for default internal)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetRenderBatchActive(rlRenderBatch* batch);

    /// <summary>
    /// Update and draw internal render batch
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDrawRenderBatchActive();

    /// <summary>
    /// Check internal buffer overflow for a given number of vertex
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool rlCheckRenderBatchLimit(int vCount);

    /// <summary>
    /// Set current texture for render batch and check buffers limits
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetTexture(uint id);

    /// <summary>
    /// Load vertex array (vao) if supported
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadVertexArray();

    /// <summary>
    /// Load a vertex buffer attribute
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadVertexBuffer(void* buffer, int size, bool dynamic);

    /// <summary>
    /// Load a new attributes element buffer
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadVertexBufferElement(void* buffer, int size, bool dynamic);

    /// <summary>
    /// Update GPU buffer with new data
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUpdateVertexBuffer(uint bufferId, void* data, int dataSize, int offset);

    /// <summary>
    /// Update vertex buffer elements with new data
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUpdateVertexBufferElements(uint id, void* data, int dataSize, int offset);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUnloadVertexArray(uint vaoId);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUnloadVertexBuffer(uint vboId);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetVertexAttribute(uint index, int compSize, int type, bool normalized, int stride, void* pointer);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetVertexAttributeDivisor(uint index, int divisor);

    /// <summary>
    /// Set vertex attribute default value
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetVertexAttributeDefault(int locIndex, void* value, int attribType, int count);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDrawVertexArray(int offset, int count);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDrawVertexArrayElements(int offset, int count, void* buffer);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDrawVertexArrayInstanced(int offset, int count, int instances);

    /// <summary>
    /// 
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlDrawVertexArrayElementsInstanced(int offset, int count, void* buffer, int instances);

    /// <summary>
    /// Load texture in GPU
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadTexture(void* data, int width, int height, int format, int mipmapCount);

    /// <summary>
    /// Load depth texture/renderbuffer (to be attached to fbo)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadTextureDepth(int width, int height, bool useRenderBuffer);

    /// <summary>
    /// Load texture cubemap
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadTextureCubemap(void* data, int size, int format);

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUpdateTexture(uint id, int offsetX, int offsetY, int width, int height, int format, void* data);

    /// <summary>
    /// Get OpenGL internal formats
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlGetGlTextureFormats(int format, int* glInternalFormat, int* glFormat, int* glType);

    /// <summary>
    /// Get name string for pixel format
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern sbyte* rlGetPixelFormatName(uint format);

    /// <summary>
    /// Unload texture from GPU memory
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUnloadTexture(uint id);

    /// <summary>
    /// Generate mipmap data for selected texture
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlGenTextureMipmaps(uint id, int width, int height, int format, int* mipmaps);

    /// <summary>
    /// Read texture pixel data
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void* rlReadTexturePixels(uint id, int width, int height, int format);

    /// <summary>
    /// Read screen pixel data (color buffer)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern byte* rlReadScreenPixels(int width, int height);

    /// <summary>
    /// Load an empty framebuffer
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadFramebuffer(int width, int height);

    /// <summary>
    /// Attach texture/renderbuffer to a framebuffer
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlFramebufferAttach(uint fboId, uint texId, int attachType, int texType, int mipLevel);

    /// <summary>
    /// Verify framebuffer is complete
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool rlFramebufferComplete(uint id);

    /// <summary>
    /// Delete framebuffer from GPU
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUnloadFramebuffer(uint id);

    /// <summary>
    /// Load shader from code strings
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadShaderCode(sbyte* vsCode, sbyte* fsCode);

    /// <summary>
    /// Compile custom shader and return shader id (type: RL_VERTEX_SHADER, RL_FRAGMENT_SHADER, RL_COMPUTE_SHADER)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlCompileShader(sbyte* shaderCode, int type);

    /// <summary>
    /// Load custom shader program
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadShaderProgram(uint vShaderId, uint fShaderId);

    /// <summary>
    /// Unload shader program
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUnloadShaderProgram(uint id);

    /// <summary>
    /// Get shader location uniform
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int rlGetLocationUniform(uint shaderId, sbyte* uniformName);

    /// <summary>
    /// Get shader location attribute
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int rlGetLocationAttrib(uint shaderId, sbyte* attribName);

    /// <summary>
    /// Set shader value uniform
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetUniform(int locIndex, void* value, int uniformType, int count);

    /// <summary>
    /// Set shader value matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetUniformMatrix(int locIndex, Matrix4x4 mat);

    /// <summary>
    /// Set shader value sampler
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetUniformSampler(int locIndex, uint textureId);

    /// <summary>
    /// Set shader currently active (id and locations)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetShader(uint id, int* locs);

    /// <summary>
    /// Load compute shader program
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadComputeShaderProgram(uint shaderId);

    /// <summary>
    /// Dispatch compute shader (equivalent to *draw* for graphics pilepine)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlComputeShaderDispatch(uint groupX, uint groupY, uint groupZ);

    /// <summary>
    /// Load shader storage buffer object (SSBO)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern uint rlLoadShaderBuffer(ulong size, void* data, int usageHint);

    /// <summary>
    /// Unload shader storage buffer object (SSBO)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUnloadShaderBuffer(uint ssboId);

    /// <summary>
    /// Update SSBO buffer data
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlUpdateShaderBufferElements(uint id, void* data, ulong dataSize, ulong offset);

    /// <summary>
    /// Get SSBO buffer size
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ulong rlGetShaderBufferSize(uint id);

    /// <summary>
    /// Bind SSBO buffer
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlReadShaderBufferElements(uint id, void* dest, ulong count, ulong offset);

    /// <summary>
    /// Copy SSBO buffer data
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlBindShaderBuffer(uint id, uint index);

    /// <summary>
    /// Copy SSBO buffer data
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlCopyBuffersElements(uint destId, uint srcId, ulong destOffset, ulong srcOffset, ulong count);

    /// <summary>
    /// Bind image texture
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlBindImageTexture(uint id, uint index, uint format, int @readonly);

    /// <summary>
    /// Get internal modelview matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 rlGetMatrixModelview();

    /// <summary>
    /// Get internal projection matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 rlGetMatrixProjection();

    /// <summary>
    /// Get internal accumulated transform matrix
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 rlGetMatrixTransform();

    /// <summary>
    /// Get internal projection matrix for stereo render (selected eye)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 rlGetMatrixProjectionStereo(int eye);

    /// <summary>
    /// Get internal view offset matrix for stereo render (selected eye)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern Matrix4x4 rlGetMatrixViewOffsetStereo(int eye);

    /// <summary>
    /// Set a custom projection matrix (replaces internal projection matrix)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetMatrixProjection(Matrix4x4 proj);

    /// <summary>
    /// Set a custom modelview matrix (replaces internal modelview matrix)
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetMatrixModelview(Matrix4x4 view);

    /// <summary>
    /// Set eyes projection matrices for stereo rendering
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetMatrixProjectionStereo(Matrix4x4 right, Matrix4x4 left);

    /// <summary>
    /// Set eyes view offsets matrices for stereo rendering
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlSetMatrixViewOffsetStereo(Matrix4x4 right, Matrix4x4 left);

    /// <summary>
    /// Load and draw a cube
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlLoadDrawCube();

    /// <summary>
    /// Load and draw a quad
    /// </summary>
    [DllImport("rlgl", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void rlLoadDrawQuad();

}

#pragma warning restore
