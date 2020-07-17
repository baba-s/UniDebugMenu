namespace Kogane.Internal
{
	/// <summary>
	/// 選択中の bool 値を管理するクラス
	/// </summary>
	internal sealed class SelectableBool : Selectable<bool>
	{
		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SelectableBool() : base()
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SelectableBool( bool value ) : base()
		{
			SetValueWithoutCallback( value );
		}

		/// <summary>
		/// 論理否定を実行します
		/// </summary>
		public void Not()
		{
			Value = !Value;
		}

		/// <summary>
		/// true になります
		/// </summary>
		public void True()
		{
			Value = true;
		}

		/// <summary>
		/// false になります
		/// </summary>
		public void False()
		{
			Value = false;
		}
	}
}