using System;

namespace Kogane
{
	/// <summary>
	/// InputField のバリデーションタイプ
	/// </summary>
	public enum InputValidateType
	{
		NONE,
		INTEGER,
	}

	/// <summary>
	/// 入力欄付きのボタンのデータを管理するクラス
	/// </summary>
	public sealed class InputActionData
	{
		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		public InputValidateType      ValidateType { get; }
		public Action<string, Action> OnClick      { get; }

		//==============================================================================
		// 関数
		//==============================================================================
		public InputActionData
		(
			InputValidateType      validateType,
			Action<string, Action> onClick
		)
		{
			ValidateType = validateType;
			OnClick      = onClick;
		}

		public InputActionData
		(
			Action<string, Action> onClick
		) : this( InputValidateType.NONE, onClick )
		{
		}

		public InputActionData
		(
			InputValidateType validateType,
			Action<string>    onClick
		)
		{
			ValidateType = validateType;
			OnClick = ( str, onEnded ) =>
			{
				onClick?.Invoke( str );
				onEnded?.Invoke();
			};
		}

		public InputActionData
		(
			Action<string> onClick
		) : this( InputValidateType.NONE, onClick )
		{
		}
	}
}