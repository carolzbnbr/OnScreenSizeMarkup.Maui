namespace OnScreenSizeMarkup.Maui.Helpers;

/// <summary>
/// Provides methods to manipulate sizes based on the physical screen size of the device.
/// </summary>
public interface IScreenSizeHelpers
{
	/// <summary>
	/// Multiplies the provided <paramref name="baseValue"/> by a factor corresponding to the physical screen size of the device.
	/// </summary>
	/// <param name="baseValue">The base size to be multiplied.</param>
	/// <param name="miniFactor">Factor for Mini sized screens.</param>
	/// <param name="extraSmallFactor">Factor for ExtraSmall sized screens.</param>
	/// <param name="smallFactor">Factor for Small sized screens.</param>
	/// <param name="smallPlusFactor">Factor for SmallPlus sized screens.</param>
	/// <param name="mediumFactor">Factor for Medium sized screens.</param>
	/// <param name="mediumPlusFactor">Factor for MediumPlus sized screens.</param>
	/// <param name="largeFactor">Factor for Large sized screens.</param>
	/// <param name="largePlusFactor">Factor for LargePlus sized screens.</param>
	/// <param name="extraLargeFactor">Factor for ExtraLarge sized screens.</param>
	/// <param name="extraExtraLargeFactor">Factor for ExtraExtraLarge sized screens.</param>
	/// <param name="jumboFactor">Factor for Jumbo sized screens.</param>
	/// <param name="superJumboFactor">Factor for SuperJumbo sized screens.</param>
	/// <param name="giantFactor">Factor for Giant sized screens.</param>
	/// <returns>The result of the multiplication based on the screen size.</returns>
	IConvertible GetScreenSizeScaled(IConvertible baseValue,
		double miniFactor = default!,
		double extraSmallFactor = default!,
		double smallFactor = default!,
		double smallPlusFactor = default!,
		double mediumFactor = default!,
		double mediumPlusFactor = default!,
		double largeFactor = default!,
		double largePlusFactor = default!,
		double extraLargeFactor = default!,
		double extraExtraLargeFactor = default!,
		double jumboFactor = default!,
		double superJumboFactor = default!,
		double giantFactor = default!);

	/// <summary>
	/// Selects and returns one of the provided values based on the device's physical screen size.
	/// </summary>
	/// <typeparam name="T">Type of the value to be returned.</typeparam>
	/// <param name="defaultSize">Default value.</param>
	/// <param name="mini">Value for Mini sized screens.</param>
	/// <param name="extraSmall">Value for ExtraSmall sized screens.</param>
	/// <param name="small">Value for Small sized screens.</param>
	/// <param name="smallPlus">Value for SmallPlus sized screens.</param>
	/// <param name="medium">Value for Medium sized screens.</param>
	/// <param name="mediumPlus">Value for MediumPlus sized screens.</param>
	/// <param name="large">Value for Large sized screens.</param>
	/// <param name="largePlus">Value for LargePlus sized screens.</param>
	/// <param name="extraLarge">Value for ExtraLarge sized screens.</param>
	/// <param name="extraExtraLarge">Value for ExtraExtraLarge sized screens.</param>
	/// <param name="jumbo">Value for Jumbo sized screens.</param>
	/// <param name="superJumbo">Value for SuperJumbo sized screens.</param>
	/// <param name="giant">Value for Giant sized screens.</param>
	/// <returns>The value corresponding to the screen size.</returns>
	/// <exception cref="ArgumentException">Thrown if required parameters are not provided.</exception>
	T GetScreenSizeValue<T>(T defaultSize = default!,
		T mini = default!,
		T extraSmall = default!,
		T small = default!,
		T smallPlus = default!,
		T medium = default!,
		T mediumPlus = default!,
		T large = default!,
		T largePlus = default!,
		T extraLarge = default!,
		T extraExtraLarge = default!,
		T jumbo = default!,
		T superJumbo = default!,
		T giant = default!);
}