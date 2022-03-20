// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

public unsafe partial class RlGlS
{
    /// <summary> Choose the current matrix to be transformed </summary>
    public static void rlMatrixMode(int mode)
    {
        RlGl.rlMatrixMode(mode);
    }

    /// <summary> Push the current matrix to stack </summary>
    public static void rlPushMatrix()
    {
        RlGl.rlPushMatrix();
    }

    /// <summary> Pop lattest inserted matrix from stack </summary>
    public static void rlPopMatrix()
    {
        RlGl.rlPopMatrix();
    }

    /// <summary> Reset current matrix to identity matrix </summary>
    public static void rlLoadIdentity()
    {
        RlGl.rlLoadIdentity();
    }

    /// <summary> Multiply the current matrix by a translation matrix </summary>
    public static void rlTranslatef(float x, float y, float z)
    {
        RlGl.rlTranslatef(x, y, z);
    }

    /// <summary> Multiply the current matrix by a rotation matrix </summary>
    public static void rlRotatef(float angle, float x, float y, float z)
    {
        RlGl.rlRotatef(angle, x, y, z);
    }

    /// <summary> Multiply the current matrix by a scaling matrix </summary>
    public static void rlScalef(float x, float y, float z)
    {
        RlGl.rlScalef(x, y, z);
    }

    /// <summary> Multiply the current matrix by another matrix </summary>
    public static void rlMultMatrixf(float* matf)
    {
        RlGl.rlMultMatrixf(matf);
    }

    /// <summary>  </summary>
    public static void rlFrustum(double left, double right, double bottom, double top, double znear, double zfar)
    {
        RlGl.rlFrustum(left, right, bottom, top, znear, zfar);
    }

    /// <summary>  </summary>
    public static void rlOrtho(double left, double right, double bottom, double top, double znear, double zfar)
    {
        RlGl.rlOrtho(left, right, bottom, top, znear, zfar);
    }

    /// <summary> Set the viewport area </summary>
    public static void rlViewport(int x, int y, int width, int height)
    {
        RlGl.rlViewport(x, y, width, height);
    }

    /// <summary> Initialize drawing mode (how to organize vertex) </summary>
    public static void rlBegin(int mode)
    {
        RlGl.rlBegin(mode);
    }

    /// <summary> Finish vertex providing </summary>
    public static void rlEnd()
    {
        RlGl.rlEnd();
    }

    /// <summary> Define one vertex (position) - 2 int </summary>
    public static void rlVertex2i(int x, int y)
    {
        RlGl.rlVertex2i(x, y);
    }

    /// <summary> Define one vertex (position) - 2 float </summary>
    public static void rlVertex2f(float x, float y)
    {
        RlGl.rlVertex2f(x, y);
    }

    /// <summary> Define one vertex (position) - 3 float </summary>
    public static void rlVertex3f(float x, float y, float z)
    {
        RlGl.rlVertex3f(x, y, z);
    }

    /// <summary> Define one vertex (texture coordinate) - 2 float </summary>
    public static void rlTexCoord2f(float x, float y)
    {
        RlGl.rlTexCoord2f(x, y);
    }

    /// <summary> Define one vertex (normal) - 3 float </summary>
    public static void rlNormal3f(float x, float y, float z)
    {
        RlGl.rlNormal3f(x, y, z);
    }

    /// <summary> Define one vertex (color) - 4 byte </summary>
    public static void rlColor4ub(byte r, byte g, byte b, byte a)
    {
        RlGl.rlColor4ub(r, g, b, a);
    }

    /// <summary> Define one vertex (color) - 3 float </summary>
    public static void rlColor3f(float x, float y, float z)
    {
        RlGl.rlColor3f(x, y, z);
    }

    /// <summary> Define one vertex (color) - 4 float </summary>
    public static void rlColor4f(float x, float y, float z, float w)
    {
        RlGl.rlColor4f(x, y, z, w);
    }

    /// <summary> Enable vertex array (VAO, if supported) </summary>
    public static bool rlEnableVertexArray(uint vaoId)
    {
        return RlGl.rlEnableVertexArray(vaoId);
    }

    /// <summary> Disable vertex array (VAO, if supported) </summary>
    public static void rlDisableVertexArray()
    {
        RlGl.rlDisableVertexArray();
    }

    /// <summary> Enable vertex buffer (VBO) </summary>
    public static void rlEnableVertexBuffer(uint id)
    {
        RlGl.rlEnableVertexBuffer(id);
    }

    /// <summary> Disable vertex buffer (VBO) </summary>
    public static void rlDisableVertexBuffer()
    {
        RlGl.rlDisableVertexBuffer();
    }

    /// <summary> Enable vertex buffer element (VBO element) </summary>
    public static void rlEnableVertexBufferElement(uint id)
    {
        RlGl.rlEnableVertexBufferElement(id);
    }

    /// <summary> Disable vertex buffer element (VBO element) </summary>
    public static void rlDisableVertexBufferElement()
    {
        RlGl.rlDisableVertexBufferElement();
    }

    /// <summary> Enable vertex attribute index </summary>
    public static void rlEnableVertexAttribute(uint index)
    {
        RlGl.rlEnableVertexAttribute(index);
    }

    /// <summary> Disable vertex attribute index </summary>
    public static void rlDisableVertexAttribute(uint index)
    {
        RlGl.rlDisableVertexAttribute(index);
    }

    /// <summary> Enable attribute state pointer </summary>
    public static void rlEnableStatePointer(int vertexAttribType, IntPtr buffer)
    {
        var buffer_ = (void*)buffer;
        RlGl.rlEnableStatePointer(vertexAttribType, buffer_);
    }

    /// <summary> Disable attribute state pointer </summary>
    public static void rlDisableStatePointer(int vertexAttribType)
    {
        RlGl.rlDisableStatePointer(vertexAttribType);
    }

    /// <summary> Select and active a texture slot </summary>
    public static void rlActiveTextureSlot(int slot)
    {
        RlGl.rlActiveTextureSlot(slot);
    }

    /// <summary> Enable texture </summary>
    public static void rlEnableTexture(uint id)
    {
        RlGl.rlEnableTexture(id);
    }

    /// <summary> Disable texture </summary>
    public static void rlDisableTexture()
    {
        RlGl.rlDisableTexture();
    }

    /// <summary> Enable texture cubemap </summary>
    public static void rlEnableTextureCubemap(uint id)
    {
        RlGl.rlEnableTextureCubemap(id);
    }

    /// <summary> Disable texture cubemap </summary>
    public static void rlDisableTextureCubemap()
    {
        RlGl.rlDisableTextureCubemap();
    }

    /// <summary> Set texture parameters (filter, wrap) </summary>
    public static void rlTextureParameters(uint id, int param, int value)
    {
        RlGl.rlTextureParameters(id, param, value);
    }

    /// <summary> Enable shader program </summary>
    public static void rlEnableShader(uint id)
    {
        RlGl.rlEnableShader(id);
    }

    /// <summary> Disable shader program </summary>
    public static void rlDisableShader()
    {
        RlGl.rlDisableShader();
    }

    /// <summary> Enable render texture (fbo) </summary>
    public static void rlEnableFramebuffer(uint id)
    {
        RlGl.rlEnableFramebuffer(id);
    }

    /// <summary> Disable render texture (fbo), return to default framebuffer </summary>
    public static void rlDisableFramebuffer()
    {
        RlGl.rlDisableFramebuffer();
    }

    /// <summary> Activate multiple draw color buffers </summary>
    public static void rlActiveDrawBuffers(int count)
    {
        RlGl.rlActiveDrawBuffers(count);
    }

    /// <summary> Enable color blending </summary>
    public static void rlEnableColorBlend()
    {
        RlGl.rlEnableColorBlend();
    }

    /// <summary> Disable color blending </summary>
    public static void rlDisableColorBlend()
    {
        RlGl.rlDisableColorBlend();
    }

    /// <summary> Enable depth test </summary>
    public static void rlEnableDepthTest()
    {
        RlGl.rlEnableDepthTest();
    }

    /// <summary> Disable depth test </summary>
    public static void rlDisableDepthTest()
    {
        RlGl.rlDisableDepthTest();
    }

    /// <summary> Enable depth write </summary>
    public static void rlEnableDepthMask()
    {
        RlGl.rlEnableDepthMask();
    }

    /// <summary> Disable depth write </summary>
    public static void rlDisableDepthMask()
    {
        RlGl.rlDisableDepthMask();
    }

    /// <summary> Enable backface culling </summary>
    public static void rlEnableBackfaceCulling()
    {
        RlGl.rlEnableBackfaceCulling();
    }

    /// <summary> Disable backface culling </summary>
    public static void rlDisableBackfaceCulling()
    {
        RlGl.rlDisableBackfaceCulling();
    }

    /// <summary> Enable scissor test </summary>
    public static void rlEnableScissorTest()
    {
        RlGl.rlEnableScissorTest();
    }

    /// <summary> Disable scissor test </summary>
    public static void rlDisableScissorTest()
    {
        RlGl.rlDisableScissorTest();
    }

    /// <summary> Scissor test </summary>
    public static void rlScissor(int x, int y, int width, int height)
    {
        RlGl.rlScissor(x, y, width, height);
    }

    /// <summary> Enable wire mode </summary>
    public static void rlEnableWireMode()
    {
        RlGl.rlEnableWireMode();
    }

    /// <summary> Disable wire mode </summary>
    public static void rlDisableWireMode()
    {
        RlGl.rlDisableWireMode();
    }

    /// <summary> Set the line drawing width </summary>
    public static void rlSetLineWidth(float width)
    {
        RlGl.rlSetLineWidth(width);
    }

    /// <summary> Get the line drawing width </summary>
    public static float rlGetLineWidth()
    {
        return RlGl.rlGetLineWidth();
    }

    /// <summary> Enable line aliasing </summary>
    public static void rlEnableSmoothLines()
    {
        RlGl.rlEnableSmoothLines();
    }

    /// <summary> Disable line aliasing </summary>
    public static void rlDisableSmoothLines()
    {
        RlGl.rlDisableSmoothLines();
    }

    /// <summary> Enable stereo rendering </summary>
    public static void rlEnableStereoRender()
    {
        RlGl.rlEnableStereoRender();
    }

    /// <summary> Disable stereo rendering </summary>
    public static void rlDisableStereoRender()
    {
        RlGl.rlDisableStereoRender();
    }

    /// <summary> Check if stereo render is enabled </summary>
    public static bool rlIsStereoRenderEnabled()
    {
        return RlGl.rlIsStereoRenderEnabled();
    }

    /// <summary> Clear color buffer with color </summary>
    public static void rlClearColor(byte r, byte g, byte b, byte a)
    {
        RlGl.rlClearColor(r, g, b, a);
    }

    /// <summary> Clear used screen buffers (color and depth) </summary>
    public static void rlClearScreenBuffers()
    {
        RlGl.rlClearScreenBuffers();
    }

    /// <summary> Check and log OpenGL error codes </summary>
    public static void rlCheckErrors()
    {
        RlGl.rlCheckErrors();
    }

    /// <summary> Set blending mode </summary>
    public static void rlSetBlendMode(int mode)
    {
        RlGl.rlSetBlendMode(mode);
    }

    /// <summary> Set blending mode factor and equation (using OpenGL factors) </summary>
    public static void rlSetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation)
    {
        RlGl.rlSetBlendFactors(glSrcFactor, glDstFactor, glEquation);
    }

    /// <summary> Initialize rlgl (buffers, shaders, textures, states) </summary>
    public static void rlglInit(int width, int height)
    {
        RlGl.rlglInit(width, height);
    }

    /// <summary> De-inititialize rlgl (buffers, shaders, textures) </summary>
    public static void rlglClose()
    {
        RlGl.rlglClose();
    }

    /// <summary> Load OpenGL extensions (loader function required) </summary>
    public static void rlLoadExtensions(IntPtr loader)
    {
        var loader_ = (void*)loader;
        RlGl.rlLoadExtensions(loader_);
    }

    /// <summary> Get current OpenGL version </summary>
    public static int rlGetVersion()
    {
        return RlGl.rlGetVersion();
    }

    /// <summary> Get default framebuffer width </summary>
    public static int rlGetFramebufferWidth()
    {
        return RlGl.rlGetFramebufferWidth();
    }

    /// <summary> Get default framebuffer height </summary>
    public static int rlGetFramebufferHeight()
    {
        return RlGl.rlGetFramebufferHeight();
    }

    /// <summary> Get default texture id </summary>
    public static uint rlGetTextureIdDefault()
    {
        return RlGl.rlGetTextureIdDefault();
    }

    /// <summary> Get default shader id </summary>
    public static uint rlGetShaderIdDefault()
    {
        return RlGl.rlGetShaderIdDefault();
    }

    /// <summary> Get default shader locations </summary>
    public static int* rlGetShaderLocsDefault()
    {
        return RlGl.rlGetShaderLocsDefault();
    }

    /// <summary> Load a render batch system </summary>
    public static RlRenderBatch rlLoadRenderBatch(int numBuffers, int bufferElements)
    {
        return RlGl.rlLoadRenderBatch(numBuffers, bufferElements);
    }

    /// <summary> Unload render batch system </summary>
    public static void rlUnloadRenderBatch(RlRenderBatch batch)
    {
        RlGl.rlUnloadRenderBatch(batch);
    }

    /// <summary> Draw render batch data (Update->Draw->Reset) </summary>
    public static void rlDrawRenderBatch(RlRenderBatch* batch)
    {
        RlGl.rlDrawRenderBatch(batch);
    }

    /// <summary> Set the active render batch for rlgl (NULL for default internal) </summary>
    public static void rlSetRenderBatchActive(RlRenderBatch* batch)
    {
        RlGl.rlSetRenderBatchActive(batch);
    }

    /// <summary> Update and draw internal render batch </summary>
    public static void rlDrawRenderBatchActive()
    {
        RlGl.rlDrawRenderBatchActive();
    }

    /// <summary> Check internal buffer overflow for a given number of vertex </summary>
    public static bool rlCheckRenderBatchLimit(int vCount)
    {
        return RlGl.rlCheckRenderBatchLimit(vCount);
    }

    /// <summary> Set current texture for render batch and check buffers limits </summary>
    public static void rlSetTexture(uint id)
    {
        RlGl.rlSetTexture(id);
    }

    /// <summary> Load vertex array (vao) if supported </summary>
    public static uint rlLoadVertexArray()
    {
        return RlGl.rlLoadVertexArray();
    }

    /// <summary> Load a vertex buffer attribute </summary>
    public static uint rlLoadVertexBuffer(IntPtr buffer, int size, bool dynamic)
    {
        var buffer_ = (void*)buffer;
        return RlGl.rlLoadVertexBuffer(buffer_, size, dynamic);
    }

    /// <summary> Load a new attributes element buffer </summary>
    public static uint rlLoadVertexBufferElement(IntPtr buffer, int size, bool dynamic)
    {
        var buffer_ = (void*)buffer;
        return RlGl.rlLoadVertexBufferElement(buffer_, size, dynamic);
    }

    /// <summary> Update GPU buffer with new data </summary>
    public static void rlUpdateVertexBuffer(uint bufferId, IntPtr data, int dataSize, int offset)
    {
        var data_ = (void*)data;
        RlGl.rlUpdateVertexBuffer(bufferId, data_, dataSize, offset);
    }

    /// <summary> Update vertex buffer elements with new data </summary>
    public static void rlUpdateVertexBufferElements(uint id, IntPtr data, int dataSize, int offset)
    {
        var data_ = (void*)data;
        RlGl.rlUpdateVertexBufferElements(id, data_, dataSize, offset);
    }

    /// <summary>  </summary>
    public static void rlUnloadVertexArray(uint vaoId)
    {
        RlGl.rlUnloadVertexArray(vaoId);
    }

    /// <summary>  </summary>
    public static void rlUnloadVertexBuffer(uint vboId)
    {
        RlGl.rlUnloadVertexBuffer(vboId);
    }

    /// <summary>  </summary>
    public static void rlSetVertexAttribute(uint index, int compSize, int type, bool normalized, int stride, IntPtr pointer)
    {
        var pointer_ = (void*)pointer;
        RlGl.rlSetVertexAttribute(index, compSize, type, normalized, stride, pointer_);
    }

    /// <summary>  </summary>
    public static void rlSetVertexAttributeDivisor(uint index, int divisor)
    {
        RlGl.rlSetVertexAttributeDivisor(index, divisor);
    }

    /// <summary> Set vertex attribute default value </summary>
    public static void rlSetVertexAttributeDefault(int locIndex, IntPtr value, int attribType, int count)
    {
        var value_ = (void*)value;
        RlGl.rlSetVertexAttributeDefault(locIndex, value_, attribType, count);
    }

    /// <summary>  </summary>
    public static void rlDrawVertexArray(int offset, int count)
    {
        RlGl.rlDrawVertexArray(offset, count);
    }

    /// <summary>  </summary>
    public static void rlDrawVertexArrayElements(int offset, int count, IntPtr buffer)
    {
        var buffer_ = (void*)buffer;
        RlGl.rlDrawVertexArrayElements(offset, count, buffer_);
    }

    /// <summary>  </summary>
    public static void rlDrawVertexArrayInstanced(int offset, int count, int instances)
    {
        RlGl.rlDrawVertexArrayInstanced(offset, count, instances);
    }

    /// <summary>  </summary>
    public static void rlDrawVertexArrayElementsInstanced(int offset, int count, IntPtr buffer, int instances)
    {
        var buffer_ = (void*)buffer;
        RlGl.rlDrawVertexArrayElementsInstanced(offset, count, buffer_, instances);
    }

    /// <summary> Load texture in GPU </summary>
    public static uint rlLoadTexture(IntPtr data, int width, int height, int format, int mipmapCount)
    {
        var data_ = (void*)data;
        return RlGl.rlLoadTexture(data_, width, height, format, mipmapCount);
    }

    /// <summary> Load depth texture/renderbuffer (to be attached to fbo) </summary>
    public static uint rlLoadTextureDepth(int width, int height, bool useRenderBuffer)
    {
        return RlGl.rlLoadTextureDepth(width, height, useRenderBuffer);
    }

    /// <summary> Load texture cubemap </summary>
    public static uint rlLoadTextureCubemap(IntPtr data, int size, int format)
    {
        var data_ = (void*)data;
        return RlGl.rlLoadTextureCubemap(data_, size, format);
    }

    /// <summary> Update GPU texture with new data </summary>
    public static void rlUpdateTexture(uint id, int offsetX, int offsetY, int width, int height, int format, IntPtr data)
    {
        var data_ = (void*)data;
        RlGl.rlUpdateTexture(id, offsetX, offsetY, width, height, format, data_);
    }

    /// <summary> Get OpenGL internal formats </summary>
    public static void rlGetGlTextureFormats(int format, int* glInternalFormat, int* glFormat, int* glType)
    {
        RlGl.rlGetGlTextureFormats(format, glInternalFormat, glFormat, glType);
    }

    /// <summary> Get name string for pixel format </summary>
    public static string rlGetPixelFormatName(uint format)
    {
        return Helpers.Utf8ToString(RlGl.rlGetPixelFormatName(format));
    }

    /// <summary> Unload texture from GPU memory </summary>
    public static void rlUnloadTexture(uint id)
    {
        RlGl.rlUnloadTexture(id);
    }

    /// <summary> Generate mipmap data for selected texture </summary>
    public static void rlGenTextureMipmaps(uint id, int width, int height, int format, int* mipmaps)
    {
        RlGl.rlGenTextureMipmaps(id, width, height, format, mipmaps);
    }

    /// <summary> Read texture pixel data </summary>
    public static IntPtr rlReadTexturePixels(uint id, int width, int height, int format)
    {
        return (IntPtr)RlGl.rlReadTexturePixels(id, width, height, format);
    }

    //  /// <summary> Read screen pixel data (color buffer) </summary>
    //  public static byte[] rlReadScreenPixels(int width, int height)
    //  {
    //      return Helpers.PrtToArray(RlGl.rlReadScreenPixels(width, height));
    //  }

    /// <summary> Load an empty framebuffer </summary>
    public static uint rlLoadFramebuffer(int width, int height)
    {
        return RlGl.rlLoadFramebuffer(width, height);
    }

    /// <summary> Attach texture/renderbuffer to a framebuffer </summary>
    public static void rlFramebufferAttach(uint fboId, uint texId, int attachType, int texType, int mipLevel)
    {
        RlGl.rlFramebufferAttach(fboId, texId, attachType, texType, mipLevel);
    }

    /// <summary> Verify framebuffer is complete </summary>
    public static bool rlFramebufferComplete(uint id)
    {
        return RlGl.rlFramebufferComplete(id);
    }

    /// <summary> Delete framebuffer from GPU </summary>
    public static void rlUnloadFramebuffer(uint id)
    {
        RlGl.rlUnloadFramebuffer(id);
    }

    /// <summary> Load shader from code strings </summary>
    public static uint rlLoadShaderCode(string vsCode, string fsCode)
    {
        using var vsCode_ = vsCode.MarshalUtf8();
        using var fsCode_ = fsCode.MarshalUtf8();
        return RlGl.rlLoadShaderCode(vsCode_.AsPtr(), fsCode_.AsPtr());
    }

    /// <summary> Compile custom shader and return shader id (type: RL_VERTEX_SHADER, RL_FRAGMENT_SHADER, RL_COMPUTE_SHADER) </summary>
    public static uint rlCompileShader(string shaderCode, int type)
    {
        using var shaderCode_ = shaderCode.MarshalUtf8();
        return RlGl.rlCompileShader(shaderCode_.AsPtr(), type);
    }

    /// <summary> Load custom shader program </summary>
    public static uint rlLoadShaderProgram(uint vShaderId, uint fShaderId)
    {
        return RlGl.rlLoadShaderProgram(vShaderId, fShaderId);
    }

    /// <summary> Unload shader program </summary>
    public static void rlUnloadShaderProgram(uint id)
    {
        RlGl.rlUnloadShaderProgram(id);
    }

    /// <summary> Get shader location uniform </summary>
    public static int rlGetLocationUniform(uint shaderId, string uniformName)
    {
        using var uniformName_ = uniformName.MarshalUtf8();
        return RlGl.rlGetLocationUniform(shaderId, uniformName_.AsPtr());
    }

    /// <summary> Get shader location attribute </summary>
    public static int rlGetLocationAttrib(uint shaderId, string attribName)
    {
        using var attribName_ = attribName.MarshalUtf8();
        return RlGl.rlGetLocationAttrib(shaderId, attribName_.AsPtr());
    }

    /// <summary> Set shader value uniform </summary>
    public static void rlSetUniform(int locIndex, IntPtr value, int uniformType, int count)
    {
        var value_ = (void*)value;
        RlGl.rlSetUniform(locIndex, value_, uniformType, count);
    }

    /// <summary> Set shader value matrix </summary>
    public static void rlSetUniformMatrix(int locIndex, Matrix4x4 mat)
    {
        RlGl.rlSetUniformMatrix(locIndex, mat);
    }

    /// <summary> Set shader value sampler </summary>
    public static void rlSetUniformSampler(int locIndex, uint textureId)
    {
        RlGl.rlSetUniformSampler(locIndex, textureId);
    }

    /// <summary> Set shader currently active (id and locations) </summary>
    public static void rlSetShader(uint id, int* locs)
    {
        RlGl.rlSetShader(id, locs);
    }

    /// <summary> Load compute shader program </summary>
    public static uint rlLoadComputeShaderProgram(uint shaderId)
    {
        return RlGl.rlLoadComputeShaderProgram(shaderId);
    }

    /// <summary> Dispatch compute shader (equivalent to *draw* for graphics pilepine) </summary>
    public static void rlComputeShaderDispatch(uint groupX, uint groupY, uint groupZ)
    {
        RlGl.rlComputeShaderDispatch(groupX, groupY, groupZ);
    }

    /// <summary> Load shader storage buffer object (SSBO) </summary>
    public static uint rlLoadShaderBuffer(ulong size, IntPtr data, int usageHint)
    {
        var data_ = (void*)data;
        return RlGl.rlLoadShaderBuffer(size, data_, usageHint);
    }

    /// <summary> Unload shader storage buffer object (SSBO) </summary>
    public static void rlUnloadShaderBuffer(uint ssboId)
    {
        RlGl.rlUnloadShaderBuffer(ssboId);
    }

    /// <summary> Update SSBO buffer data </summary>
    public static void rlUpdateShaderBufferElements(uint id, IntPtr data, ulong dataSize, ulong offset)
    {
        var data_ = (void*)data;
        RlGl.rlUpdateShaderBufferElements(id, data_, dataSize, offset);
    }

    /// <summary> Get SSBO buffer size </summary>
    public static ulong rlGetShaderBufferSize(uint id)
    {
        return RlGl.rlGetShaderBufferSize(id);
    }

    /// <summary> Bind SSBO buffer </summary>
    public static void rlReadShaderBufferElements(uint id, IntPtr dest, ulong count, ulong offset)
    {
        var dest_ = (void*)dest;
        RlGl.rlReadShaderBufferElements(id, dest_, count, offset);
    }

    /// <summary> Copy SSBO buffer data </summary>
    public static void rlBindShaderBuffer(uint id, uint index)
    {
        RlGl.rlBindShaderBuffer(id, index);
    }

    /// <summary> Copy SSBO buffer data </summary>
    public static void rlCopyBuffersElements(uint destId, uint srcId, ulong destOffset, ulong srcOffset, ulong count)
    {
        RlGl.rlCopyBuffersElements(destId, srcId, destOffset, srcOffset, count);
    }

    /// <summary> Bind image texture </summary>
    public static void rlBindImageTexture(uint id, uint index, uint format, int @readonly)
    {
        RlGl.rlBindImageTexture(id, index, format, @readonly);
    }

    /// <summary> Get internal modelview matrix </summary>
    public static Matrix4x4 rlGetMatrixModelview()
    {
        return RlGl.rlGetMatrixModelview();
    }

    /// <summary> Get internal projection matrix </summary>
    public static Matrix4x4 rlGetMatrixProjection()
    {
        return RlGl.rlGetMatrixProjection();
    }

    /// <summary> Get internal accumulated transform matrix </summary>
    public static Matrix4x4 rlGetMatrixTransform()
    {
        return RlGl.rlGetMatrixTransform();
    }

    /// <summary> Get internal projection matrix for stereo render (selected eye) </summary>
    public static Matrix4x4 rlGetMatrixProjectionStereo(int eye)
    {
        return RlGl.rlGetMatrixProjectionStereo(eye);
    }

    /// <summary> Get internal view offset matrix for stereo render (selected eye) </summary>
    public static Matrix4x4 rlGetMatrixViewOffsetStereo(int eye)
    {
        return RlGl.rlGetMatrixViewOffsetStereo(eye);
    }

    /// <summary> Set a custom projection matrix (replaces internal projection matrix) </summary>
    public static void rlSetMatrixProjection(Matrix4x4 proj)
    {
        RlGl.rlSetMatrixProjection(proj);
    }

    /// <summary> Set a custom modelview matrix (replaces internal modelview matrix) </summary>
    public static void rlSetMatrixModelview(Matrix4x4 view)
    {
        RlGl.rlSetMatrixModelview(view);
    }

    /// <summary> Set eyes projection matrices for stereo rendering </summary>
    public static void rlSetMatrixProjectionStereo(Matrix4x4 right, Matrix4x4 left)
    {
        RlGl.rlSetMatrixProjectionStereo(right, left);
    }

    /// <summary> Set eyes view offsets matrices for stereo rendering </summary>
    public static void rlSetMatrixViewOffsetStereo(Matrix4x4 right, Matrix4x4 left)
    {
        RlGl.rlSetMatrixViewOffsetStereo(right, left);
    }

    /// <summary> Load and draw a cube </summary>
    public static void rlLoadDrawCube()
    {
        RlGl.rlLoadDrawCube();
    }

    /// <summary> Load and draw a quad </summary>
    public static void rlLoadDrawQuad()
    {
        RlGl.rlLoadDrawQuad();
    }

}

#pragma warning restore
