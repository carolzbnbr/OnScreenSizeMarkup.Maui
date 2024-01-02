using OnScreenSizeMarkup.Maui.Providers;

namespace OnScreenSizeMarkup.Maui.Helpers;

/// <summary>
/// Provides methods to manipulate sizes based on the physical screen size of the device.
/// </summary>
public class OnScreenSizeHelpers : IScreenSizeHelpers
{
	private readonly IScreenCategoryProvider screenCategoryProvider;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="screenCategoryProvider"></param>
	public OnScreenSizeHelpers(IScreenCategoryProvider screenCategoryProvider)
	{
		this.screenCategoryProvider = screenCategoryProvider;
	}

	private static IScreenSizeHelpers? instance = null!;

	/// <summary>
	/// Provides access to this instance.
	/// This should only be used if the component has not been registered with MAUI's dependency injection using <see cref="ConfigureServices.AddOnScreenSize"/>.
	/// </summary>
	public static IScreenSizeHelpers Instance
	{
		get
		{
			if (instance == null)
			{
				instance = UniversalFactory.CreateScreenSizeHelpers();
			}

			return instance;
		}
	}
	
	/// <inheritdoc />
	public IConvertible GetScreenSizeScaled(IConvertible baseValue,
		double miniFactor = default(double)!,
		double extraSmallFactor = default(double)!,
		double smallFactor = default(double)!,
		double smallPlusFactor = default(double)!,
		double mediumFactor = default(double)!,
		double mediumPlusFactor = default(double)!,
		double largeFactor = default(double)!,
		double largePlusFactor = default(double)!,
		double extraLargeFactor = default(double)!,
		double extraExtraLargeFactor = default(double)!,
		double jumboFactor = default(double)!,
		double superJumboFactor = default(double)!,
		double giantFactor = default(double)!)
	{
		double factorValue = default(double); // Default value
		var screenSize = screenCategoryProvider.GetCategory();

		switch (screenSize)
		{
			case ScreenCategories.Mini:
				factorValue = miniFactor;
				break;
			case ScreenCategories.ExtraSmall:
				factorValue = extraSmallFactor;
				break;
			case ScreenCategories.Small:
				factorValue = smallFactor;
				break;
			case ScreenCategories.SmallPlus:
				factorValue = smallPlusFactor;
				break;
			case ScreenCategories.Medium:
				factorValue = mediumFactor;
				break;
			case ScreenCategories.MediumPlus:
				factorValue = mediumPlusFactor;
				break;
			case ScreenCategories.Large:
				factorValue = largeFactor;
				break;
			case ScreenCategories.LargePlus:
				factorValue = largePlusFactor;
				break;
			case ScreenCategories.ExtraLarge:
				factorValue = extraLargeFactor;
				break;
			case ScreenCategories.ExtraExtraLarge:
				factorValue = extraExtraLargeFactor;
				break;
			case ScreenCategories.Jumbo:
				factorValue = jumboFactor;
				break;
			case ScreenCategories.SuperJumbo:
				factorValue = superJumboFactor;
				break;
			case ScreenCategories.Giant:
				factorValue = giantFactor;
				break;
			case ScreenCategories.NotSet:
				factorValue = 1;
				break;
		}

		var retValue = ProportionalSizeConverter.Multiply(typeof(double), baseValue, factorValue);
		return retValue;
	}

	/// <inheritdoc />
	public T GetScreenSizeValue<T>(T defaultSize = default!,
		T mini = default(T)!,
		T extraSmall = default(T)!,
		T small = default(T)!,
		T smallPlus = default(T)!,
		T medium = default(T)!,
		T mediumPlus = default(T)!,
		T large = default(T)!,
		T largePlus = default(T)!,
		T extraLarge = default(T)!,
		T extraExtraLarge = default(T)!,
		T jumbo = default(T)!,
		T superJumbo = default(T)!,
		T giant = default(T)!)
	{
		var screenSize = screenCategoryProvider.GetCategory();

		switch (screenSize)
		{
			case ScreenCategories.Mini:
				return mini;
			case ScreenCategories.ExtraSmall:
				return extraSmall;
			case ScreenCategories.Small:
				return small;
			case ScreenCategories.SmallPlus:
				return smallPlus;
			case ScreenCategories.Medium:
				return medium;
			case ScreenCategories.MediumPlus:
				return mediumPlus;
			case ScreenCategories.Large:
				return large;
			case ScreenCategories.LargePlus:
				return largePlus;
			case ScreenCategories.ExtraLarge:
				return extraLarge;
			case ScreenCategories.ExtraExtraLarge:
				return extraExtraLarge;
			case ScreenCategories.Jumbo:
				return jumbo;
			case ScreenCategories.SuperJumbo:
				return superJumbo;
			case ScreenCategories.Giant:
				return giant;
		}
		
		if (EqualityComparer<T>.Default.Equals(defaultSize, default(T)))
		{
			throw new ArgumentException($"{nameof(OnScreenSizeExtension)} markup requires a {nameof(defaultSize)} set.");
		}
		
		return defaultSize;
	}
}