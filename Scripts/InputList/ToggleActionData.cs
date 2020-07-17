using System;

namespace Kogane
{
	/// <summary>
	/// チェックボックスで使用するデータを管理するクラス
	/// </summary>
	public sealed class ToggleActionData
	{
		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		public Func<bool>           Getter { get; }
		public Action<bool, Action> Setter { get; }

		//==============================================================================
		// 関数
		//==============================================================================
		public ToggleActionData
		(
			Func<bool>           getter,
			Action<bool, Action> setter
		)
		{
			Getter = getter;
			Setter = setter;
		}

		public ToggleActionData
		(
			Func<bool>   getter,
			Action<bool> setter
		)
		{
			Getter = getter;
			Setter = ( isOn, onEnded ) =>
			{
				setter?.Invoke( isOn );
				onEnded?.Invoke();
			};
		}
	}
}