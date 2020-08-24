using System;
using System.Diagnostics.Contracts;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

namespace BonEngineSharp.Assets
{
    /// <summary>
    /// Effect asset type.
    /// This asset is used to render sprites and text with special effects.
    /// </summary>
    public class EffectAsset : IAsset
    {
        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public EffectAsset(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get asset type.
        /// </summary>
        public override AssetType AssetType => AssetType.Effect;

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~EffectAsset()
        {
            Dispose();
        }

		/// <summary>
		/// Return if this effect asset is properly loaded / valid.
		/// </summary>
		public override bool IsValid => _handle != IntPtr.Zero && _BonEngineBind.BON_Effect_IsValid(_handle);

		/// <summary>
		/// Return if this effect uses textures.
		/// </summary>
		public bool UseTextures => _handle != IntPtr.Zero && _BonEngineBind.BON_Effect_UseTextures(_handle);

		/// <summary>
		/// Return if this effect uses vertex color.
		/// </summary>
		public bool UseVertexColor => _handle != IntPtr.Zero && _BonEngineBind.BON_Effect_UseVertexColor(_handle);

		/// <summary>
		/// Set float uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="val">Value to set.</param>
		public void SetUniform(string name, float val)
		{
			_BonEngineBind.BON_Effect_SetUniformFloat(_handle, name, val);
		}

		/// <summary>
		/// Set vector2 uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="x">X value.</param>
		/// <param name="y">Y value.</param>
		public void SetUniform(string name, float x, float y)
		{
			_BonEngineBind.BON_Effect_SetUniformVector2(_handle, name, x, y);
		}

		/// <summary>
		/// Set vector3 uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="x">X value.</param>
		/// <param name="y">Y value.</param>
		/// <param name="z">Z value.</param>
		public void SetUniform(string name, float x, float y, float z)
		{
			_BonEngineBind.BON_Effect_SetUniformVector3(_handle, name, x, y, z);
		}

		/// <summary>
		/// Set vector4 uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="x">X value.</param>
		/// <param name="y">Y value.</param>
		/// <param name="z">Z value.</param>
		/// <param name="w">W value.</param>
		public void SetUniform(string name, float x, float y, float z, float w)
		{
			_BonEngineBind.BON_Effect_SetUniformVector4(_handle, name, x, y, z, w);
		}

		/// <summary>
		/// Set int uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="val">Value to set.</param>
		public void SetUniform(string name, int val)
		{
			_BonEngineBind.BON_Effect_SetUniformInt(_handle, name, val);
		}

		/// <summary>
		/// Set vector2 uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="x">X value.</param>
		/// <param name="y">Y value.</param>
		public void SetUniform(string name, int x, int y)
		{
			_BonEngineBind.BON_Effect_SetUniformVector2i(_handle, name, x, y);
		}

		/// <summary>
		/// Set vector3 uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="x">X value.</param>
		/// <param name="y">Y value.</param>
		/// <param name="z">Z value.</param>
		public void SetUniform(string name, int x, int y, int z)
		{
			_BonEngineBind.BON_Effect_SetUniformVector3i(_handle, name, x, y, z);
		}

		/// <summary>
		/// Set vector4 uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="x">X value.</param>
		/// <param name="y">Y value.</param>
		/// <param name="z">Z value.</param>
		/// <param name="w">W value.</param>
		public void SetUniform(string name, int x, int y, int z, int w)
		{
			_BonEngineBind.BON_Effect_SetUniformVector4i(_handle, name, x, y, z, w);
		}

		/// <summary>
		/// Set color uniform (either vector3 or vector4, if using alpha).
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="color">Color to set.</param>
		/// <param name="includeAlpha">If true, will also set alpha value (vector4). If false, will only set RGB (vector3).</param>
		public void SetUniform(string name, Color color, bool includeAlpha)
		{
			if (includeAlpha)
			{
				SetUniform(name, color.R, color.G, color.B, color.A);
			}
			else
			{
				SetUniform(name, color.R, color.G, color.B);
			}
		}

		/// <summary>
		/// Set matrix uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="transpose">Specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
		/// <param name="values">Matrix values.</param>
		public void SetUniformMatrix2(string name, bool transpose, float[] values)
		{
			Contract.Requires(values.Length == 2);
			_BonEngineBind.BON_Effect_SetUniformMatrix2(_handle, name, 2, transpose, values);
		}

		/// <summary>
		/// Set matrix uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="transpose">Specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
		/// <param name="values">Matrix values.</param>
		public void SetUniformMatrix3(string name, bool transpose, float[] values)
		{
			Contract.Requires(values.Length == 3);
			_BonEngineBind.BON_Effect_SetUniformMatrix3(_handle, name, 3, transpose, values);
		}

		/// <summary>
		/// Set matrix uniform.
		/// </summary>
		/// <param name="name">Uniform name, as appear in shaders.</param>
		/// <param name="transpose">Specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
		/// <param name="values">Matrix values.</param>
		public void SetUniformMatrix4(string name, bool transpose, float[] values)
		{
			Contract.Requires(values.Length == 4);
			_BonEngineBind.BON_Effect_SetUniformMatrix4(_handle, name, 4, transpose, values);
		}
	}
}
