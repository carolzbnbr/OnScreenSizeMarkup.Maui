namespace OnScreenSizeMarkup.Maui.Categories;

/// <summary>
/// Categories that a smartphone or tablet screen size fits in.
/// </summary>
public enum ScreenCategories
{
	/// <summary>
	/// Represents the smallest screens, typically for compact smartphones or wearable devices.
	/// </summary>
	Mini = 1,

	/// <summary>
	/// Extra Small sized screens, common in smaller, more portable smartphones.
	/// </summary>
	ExtraSmall = 2,

	/// <summary>
	/// Small sized screens, typical for budget or older smartphones.
	/// </summary>
	Small = 3,

	/// <summary>
	/// A size slightly larger than 'Small', found in newer smartphone models offering more screen space.
	/// </summary>
	SmallPlus = 4,

	/// <summary>
	/// Medium size screens, common in mid-range smartphones and smaller tablets.
	/// </summary>
	Medium = 5,

	/// <summary>
	/// Slightly larger than 'Medium', bridging the gap between smartphones and tablets.
	/// </summary>
	MediumPlus = 6,

	/// <summary>
	/// Large sized screens, typical for high-end smartphones and mid-sized tablets.
	/// </summary>
	Large = 7,

	/// <summary>
	/// Slightly larger than 'Large', for larger tablets that offer extensive screen real estate.
	/// </summary>
	LargePlus = 8,

	/// <summary>
	/// Extra Large sized screens, common in premium large tablets and hybrids.
	/// </summary>
	ExtraLarge = 9,

	/// <summary>
	/// Larger than 'Extra Large', typically found in tablets designed for professional use or media consumption.
	/// </summary>
	ExtraExtraLarge = 10,

	/// <summary>
	/// Very large tablet screens, often used for specialized applications or as laptop replacements.
	/// </summary>
	Jumbo = 11,

	/// <summary>
	/// Extremely large screens, surpassing traditional tablet sizes, possibly for specialized industrial or commercial use.
	/// </summary>
	SuperJumbo = 12,

	/// <summary>
	/// The largest category, for exceptionally large devices that are more akin to touch-enabled monitors.
	/// </summary>
	Giant = 13,

	/// <summary>
	/// Represents an unset or undefined screen size category.
	/// </summary>
	NotSet = 0
}