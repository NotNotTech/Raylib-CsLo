//# raylib 4.0 bindings.   Lgpl Licensed.  Source here: https://github.com/NotNotTech/Raylib-CsLo
//# Find Raylib+docs here:   https://github.com/raysan5/raylib/blob/master/src/raylib.h
//# This file, and it's containing folder are automatically generated.  Do not Modify.
using System;
using System.Numerics;
using System.Runtime.InteropServices;
using static Raylib_CsLo.rlShaderLocationIndex;

namespace Raylib_CsLo
{
    public static unsafe partial class RlGl
    {
        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlMatrixMode(int mode);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlPushMatrix();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlPopMatrix();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlLoadIdentity();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlTranslatef(float x, float y, float z);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlRotatef(float angle, float x, float y, float z);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlScalef(float x, float y, float z);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlMultMatrixf(float* matf);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlFrustum(double left, double right, double bottom, double top, double znear, double zfar);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlOrtho(double left, double right, double bottom, double top, double znear, double zfar);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlViewport(int x, int y, int width, int height);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlBegin(int mode);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnd();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlVertex2i(int x, int y);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlVertex2f(float x, float y);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlVertex3f(float x, float y, float z);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlTexCoord2f(float x, float y);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlNormal3f(float x, float y, float z);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlColor4ub([NativeTypeName("unsigned char")] byte r, [NativeTypeName("unsigned char")] byte g, [NativeTypeName("unsigned char")] byte b, [NativeTypeName("unsigned char")] byte a);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlColor3f(float x, float y, float z);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlColor4f(float x, float y, float z, float w);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Boolean rlEnableVertexArray([NativeTypeName("unsigned int")] uint vaoId);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableVertexArray();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableVertexBuffer([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableVertexBuffer();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableVertexBufferElement([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableVertexBufferElement();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableVertexAttribute([NativeTypeName("unsigned int")] uint index);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableVertexAttribute([NativeTypeName("unsigned int")] uint index);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlActiveTextureSlot(int slot);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableTexture([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableTexture();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableTextureCubemap([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableTextureCubemap();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlTextureParameters([NativeTypeName("unsigned int")] uint id, int param1, int value);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableShader([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableShader();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableFramebuffer([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableFramebuffer();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlActiveDrawBuffers(int count);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableColorBlend();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableColorBlend();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableDepthTest();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableDepthTest();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableDepthMask();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableDepthMask();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableBackfaceCulling();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableBackfaceCulling();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableScissorTest();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableScissorTest();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlScissor(int x, int y, int width, int height);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableWireMode();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableWireMode();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetLineWidth(float width);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float rlGetLineWidth();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableSmoothLines();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableSmoothLines();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlEnableStereoRender();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDisableStereoRender();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Boolean rlIsStereoRenderEnabled();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlClearColor([NativeTypeName("unsigned char")] byte r, [NativeTypeName("unsigned char")] byte g, [NativeTypeName("unsigned char")] byte b, [NativeTypeName("unsigned char")] byte a);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlClearScreenBuffers();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlCheckErrors();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetBlendMode(int mode);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetBlendFactors(int glSrcFactor, int glDstFactor, int glEquation);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlglInit(int width, int height);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlglClose();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlLoadExtensions(void* loader);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int rlGetVersion();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int rlGetFramebufferWidth();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int rlGetFramebufferHeight();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlGetTextureIdDefault();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlGetShaderIdDefault();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int* rlGetShaderLocsDefault();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern rlRenderBatch rlLoadRenderBatch(int numBuffers, int bufferElements);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUnloadRenderBatch(rlRenderBatch batch);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDrawRenderBatch(rlRenderBatch* batch);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetRenderBatchActive(rlRenderBatch* batch);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDrawRenderBatchActive();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Boolean rlCheckRenderBatchLimit(int vCount);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetTexture([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadVertexArray();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadVertexBuffer(void* buffer, int size, Boolean dynamic);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadVertexBufferElement(void* buffer, int size, Boolean dynamic);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUpdateVertexBuffer([NativeTypeName("unsigned int")] uint bufferId, void* data, int dataSize, int offset);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUnloadVertexArray([NativeTypeName("unsigned int")] uint vaoId);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUnloadVertexBuffer([NativeTypeName("unsigned int")] uint vboId);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetVertexAttribute([NativeTypeName("unsigned int")] uint index, int compSize, int type, Boolean normalized, int stride, void* pointer);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetVertexAttributeDivisor([NativeTypeName("unsigned int")] uint index, int divisor);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetVertexAttributeDefault(int locIndex, [NativeTypeName("const void *")] void* value, int attribType, int count);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDrawVertexArray(int offset, int count);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDrawVertexArrayElements(int offset, int count, void* buffer);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDrawVertexArrayInstanced(int offset, int count, int instances);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlDrawVertexArrayElementsInstanced(int offset, int count, void* buffer, int instances);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadTexture(void* data, int width, int height, int format, int mipmapCount);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadTextureDepth(int width, int height, Boolean useRenderBuffer);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadTextureCubemap(void* data, int size, int format);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUpdateTexture([NativeTypeName("unsigned int")] uint id, int offsetX, int offsetY, int width, int height, int format, [NativeTypeName("const void *")] void* data);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlGetGlTextureFormats(int format, int* glInternalFormat, int* glFormat, int* glType);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern sbyte* rlGetPixelFormatName([NativeTypeName("unsigned int")] uint format);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUnloadTexture([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlGenTextureMipmaps([NativeTypeName("unsigned int")] uint id, int width, int height, int format, int* mipmaps);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* rlReadTexturePixels([NativeTypeName("unsigned int")] uint id, int width, int height, int format);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned char *")]
        public static extern byte* rlReadScreenPixels(int width, int height);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadFramebuffer(int width, int height);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlFramebufferAttach([NativeTypeName("unsigned int")] uint fboId, [NativeTypeName("unsigned int")] uint texId, int attachType, int texType, int mipLevel);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Boolean rlFramebufferComplete([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUnloadFramebuffer([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadShaderCode([NativeTypeName("const char *")] sbyte* vsCode, [NativeTypeName("const char *")] sbyte* fsCode);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlCompileShader([NativeTypeName("const char *")] sbyte* shaderCode, int type);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadShaderProgram([NativeTypeName("unsigned int")] uint vShaderId, [NativeTypeName("unsigned int")] uint fShaderId);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUnloadShaderProgram([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int rlGetLocationUniform([NativeTypeName("unsigned int")] uint shaderId, [NativeTypeName("const char *")] sbyte* uniformName);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int rlGetLocationAttrib([NativeTypeName("unsigned int")] uint shaderId, [NativeTypeName("const char *")] sbyte* attribName);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetUniform(int locIndex, [NativeTypeName("const void *")] void* value, int uniformType, int count);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetUniformMatrix(int locIndex, [NativeTypeName("Matrix")] Matrix4x4 mat);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetUniformSampler(int locIndex, [NativeTypeName("unsigned int")] uint textureId);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetShader([NativeTypeName("unsigned int")] uint id, int* locs);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadComputeShaderProgram([NativeTypeName("unsigned int")] uint shaderId);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlComputeShaderDispatch([NativeTypeName("unsigned int")] uint groupX, [NativeTypeName("unsigned int")] uint groupY, [NativeTypeName("unsigned int")] uint groupZ);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned int")]
        public static extern uint rlLoadShaderBuffer([NativeTypeName("unsigned long long")] ulong size, [NativeTypeName("const void *")] void* data, int usageHint);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUnloadShaderBuffer([NativeTypeName("unsigned int")] uint ssboId);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlUpdateShaderBufferElements([NativeTypeName("unsigned int")] uint id, [NativeTypeName("const void *")] void* data, [NativeTypeName("unsigned long long")] ulong dataSize, [NativeTypeName("unsigned long long")] ulong offset);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("unsigned long long")]
        public static extern ulong rlGetShaderBufferSize([NativeTypeName("unsigned int")] uint id);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlReadShaderBufferElements([NativeTypeName("unsigned int")] uint id, void* dest, [NativeTypeName("unsigned long long")] ulong count, [NativeTypeName("unsigned long long")] ulong offset);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlBindShaderBuffer([NativeTypeName("unsigned int")] uint id, [NativeTypeName("unsigned int")] uint index);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlCopyBuffersElements([NativeTypeName("unsigned int")] uint destId, [NativeTypeName("unsigned int")] uint srcId, [NativeTypeName("unsigned long long")] ulong destOffset, [NativeTypeName("unsigned long long")] ulong srcOffset, [NativeTypeName("unsigned long long")] ulong count);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlBindImageTexture([NativeTypeName("unsigned int")] uint id, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("unsigned int")] uint format, int @readonly);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Matrix")]
        public static extern Matrix4x4 rlGetMatrixModelview();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Matrix")]
        public static extern Matrix4x4 rlGetMatrixProjection();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Matrix")]
        public static extern Matrix4x4 rlGetMatrixTransform();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Matrix")]
        public static extern Matrix4x4 rlGetMatrixProjectionStereo(int eye);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("Matrix")]
        public static extern Matrix4x4 rlGetMatrixViewOffsetStereo(int eye);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetMatrixProjection([NativeTypeName("Matrix")] Matrix4x4 proj);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetMatrixModelview([NativeTypeName("Matrix")] Matrix4x4 view);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetMatrixProjectionStereo([NativeTypeName("Matrix")] Matrix4x4 right, [NativeTypeName("Matrix")] Matrix4x4 left);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlSetMatrixViewOffsetStereo([NativeTypeName("Matrix")] Matrix4x4 right, [NativeTypeName("Matrix")] Matrix4x4 left);

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlLoadDrawCube();

        [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void rlLoadDrawQuad();

        [NativeTypeName("#define RLGL_VERSION \"4.0\"")]
        public static ReadOnlySpan<byte> RLGL_VERSION => new byte[] { 0x34, 0x2E, 0x30, 0x00 };

        [NativeTypeName("#define RL_DEFAULT_BATCH_BUFFER_ELEMENTS 8192")]
        public const int RL_DEFAULT_BATCH_BUFFER_ELEMENTS = 8192;

        [NativeTypeName("#define RL_DEFAULT_BATCH_BUFFERS 1")]
        public const int RL_DEFAULT_BATCH_BUFFERS = 1;

        [NativeTypeName("#define RL_DEFAULT_BATCH_DRAWCALLS 256")]
        public const int RL_DEFAULT_BATCH_DRAWCALLS = 256;

        [NativeTypeName("#define RL_DEFAULT_BATCH_MAX_TEXTURE_UNITS 4")]
        public const int RL_DEFAULT_BATCH_MAX_TEXTURE_UNITS = 4;

        [NativeTypeName("#define RL_MAX_MATRIX_STACK_SIZE 32")]
        public const int RL_MAX_MATRIX_STACK_SIZE = 32;

        [NativeTypeName("#define RL_MAX_SHADER_LOCATIONS 32")]
        public const int RL_MAX_SHADER_LOCATIONS = 32;

        [NativeTypeName("#define RL_CULL_DISTANCE_NEAR 0.01")]
        public const double RL_CULL_DISTANCE_NEAR = 0.01;

        [NativeTypeName("#define RL_CULL_DISTANCE_FAR 1000.0")]
        public const double RL_CULL_DISTANCE_FAR = 1000.0;

        [NativeTypeName("#define RL_TEXTURE_WRAP_S 0x2802")]
        public const int RL_TEXTURE_WRAP_S = 0x2802;

        [NativeTypeName("#define RL_TEXTURE_WRAP_T 0x2803")]
        public const int RL_TEXTURE_WRAP_T = 0x2803;

        [NativeTypeName("#define RL_TEXTURE_MAG_FILTER 0x2800")]
        public const int RL_TEXTURE_MAG_FILTER = 0x2800;

        [NativeTypeName("#define RL_TEXTURE_MIN_FILTER 0x2801")]
        public const int RL_TEXTURE_MIN_FILTER = 0x2801;

        [NativeTypeName("#define RL_TEXTURE_FILTER_NEAREST 0x2600")]
        public const int RL_TEXTURE_FILTER_NEAREST = 0x2600;

        [NativeTypeName("#define RL_TEXTURE_FILTER_LINEAR 0x2601")]
        public const int RL_TEXTURE_FILTER_LINEAR = 0x2601;

        [NativeTypeName("#define RL_TEXTURE_FILTER_MIP_NEAREST 0x2700")]
        public const int RL_TEXTURE_FILTER_MIP_NEAREST = 0x2700;

        [NativeTypeName("#define RL_TEXTURE_FILTER_NEAREST_MIP_LINEAR 0x2702")]
        public const int RL_TEXTURE_FILTER_NEAREST_MIP_LINEAR = 0x2702;

        [NativeTypeName("#define RL_TEXTURE_FILTER_LINEAR_MIP_NEAREST 0x2701")]
        public const int RL_TEXTURE_FILTER_LINEAR_MIP_NEAREST = 0x2701;

        [NativeTypeName("#define RL_TEXTURE_FILTER_MIP_LINEAR 0x2703")]
        public const int RL_TEXTURE_FILTER_MIP_LINEAR = 0x2703;

        [NativeTypeName("#define RL_TEXTURE_FILTER_ANISOTROPIC 0x3000")]
        public const int RL_TEXTURE_FILTER_ANISOTROPIC = 0x3000;

        [NativeTypeName("#define RL_TEXTURE_WRAP_REPEAT 0x2901")]
        public const int RL_TEXTURE_WRAP_REPEAT = 0x2901;

        [NativeTypeName("#define RL_TEXTURE_WRAP_CLAMP 0x812F")]
        public const int RL_TEXTURE_WRAP_CLAMP = 0x812F;

        [NativeTypeName("#define RL_TEXTURE_WRAP_MIRROR_REPEAT 0x8370")]
        public const int RL_TEXTURE_WRAP_MIRROR_REPEAT = 0x8370;

        [NativeTypeName("#define RL_TEXTURE_WRAP_MIRROR_CLAMP 0x8742")]
        public const int RL_TEXTURE_WRAP_MIRROR_CLAMP = 0x8742;

        [NativeTypeName("#define RL_MODELVIEW 0x1700")]
        public const int RL_MODELVIEW = 0x1700;

        [NativeTypeName("#define RL_PROJECTION 0x1701")]
        public const int RL_PROJECTION = 0x1701;

        [NativeTypeName("#define RL_TEXTURE 0x1702")]
        public const int RL_TEXTURE = 0x1702;

        [NativeTypeName("#define RL_LINES 0x0001")]
        public const int RL_LINES = 0x0001;

        [NativeTypeName("#define RL_TRIANGLES 0x0004")]
        public const int RL_TRIANGLES = 0x0004;

        [NativeTypeName("#define RL_QUADS 0x0007")]
        public const int RL_QUADS = 0x0007;

        [NativeTypeName("#define RL_UNSIGNED_BYTE 0x1401")]
        public const int RL_UNSIGNED_BYTE = 0x1401;

        [NativeTypeName("#define RL_FLOAT 0x1406")]
        public const int RL_FLOAT = 0x1406;

        [NativeTypeName("#define RL_STREAM_DRAW 0x88E0")]
        public const int RL_STREAM_DRAW = 0x88E0;

        [NativeTypeName("#define RL_STREAM_READ 0x88E1")]
        public const int RL_STREAM_READ = 0x88E1;

        [NativeTypeName("#define RL_STREAM_COPY 0x88E2")]
        public const int RL_STREAM_COPY = 0x88E2;

        [NativeTypeName("#define RL_STATIC_DRAW 0x88E4")]
        public const int RL_STATIC_DRAW = 0x88E4;

        [NativeTypeName("#define RL_STATIC_READ 0x88E5")]
        public const int RL_STATIC_READ = 0x88E5;

        [NativeTypeName("#define RL_STATIC_COPY 0x88E6")]
        public const int RL_STATIC_COPY = 0x88E6;

        [NativeTypeName("#define RL_DYNAMIC_DRAW 0x88E8")]
        public const int RL_DYNAMIC_DRAW = 0x88E8;

        [NativeTypeName("#define RL_DYNAMIC_READ 0x88E9")]
        public const int RL_DYNAMIC_READ = 0x88E9;

        [NativeTypeName("#define RL_DYNAMIC_COPY 0x88EA")]
        public const int RL_DYNAMIC_COPY = 0x88EA;

        [NativeTypeName("#define RL_FRAGMENT_SHADER 0x8B30")]
        public const int RL_FRAGMENT_SHADER = 0x8B30;

        [NativeTypeName("#define RL_VERTEX_SHADER 0x8B31")]
        public const int RL_VERTEX_SHADER = 0x8B31;

        [NativeTypeName("#define RL_COMPUTE_SHADER 0x91B9")]
        public const int RL_COMPUTE_SHADER = 0x91B9;

        [NativeTypeName("#define RL_SHADER_LOC_MAP_DIFFUSE RL_SHADER_LOC_MAP_ALBEDO")]
        public const rlShaderLocationIndex RL_SHADER_LOC_MAP_DIFFUSE = RL_SHADER_LOC_MAP_ALBEDO;

        [NativeTypeName("#define RL_SHADER_LOC_MAP_SPECULAR RL_SHADER_LOC_MAP_METALNESS")]
        public const rlShaderLocationIndex RL_SHADER_LOC_MAP_SPECULAR = RL_SHADER_LOC_MAP_METALNESS;
    }
}
