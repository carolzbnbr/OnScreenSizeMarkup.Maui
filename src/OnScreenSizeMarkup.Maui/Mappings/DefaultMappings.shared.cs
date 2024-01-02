using System.Collections.Generic;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Extensions;

namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Contains predefined lists of screen size mappings for use with the <see cref="OnScreenSizeExtension"/>.
/// This class serves as a central repository for different sets of size mappings, 
/// facilitating the categorization of device screen sizes for various UI and layout adaptations.
/// It includes both comprehensive and legacy mapping lists to accommodate a wide range of application requirements.
/// The comprehensive list ('MobileMappings') covers an extensive range of categories from 'Mini' to 'Giant',
/// suitable for modern applications requiring detailed screen size differentiation.
/// The legacy list ('MobileMappingsLegacy') provides compatibility with older standards, focusing on basic categories 
/// like Small, Medium, Large, and ExtraLarge, ideal for applications that need to maintain consistency with 
/// previous versions or require a simpler level of differentiation.
/// Additionally, developers have the flexibility to create their own custom mapping configurations 
/// to suit specific requirements or to adapt to new device trends. This feature allows for enhanced 
/// customization and future-proofing of applications as new devices enter the market.
/// Utilizing these mappings, developers can easily implement responsive designs that cater to a diverse array of 
/// mobile device screen sizes, ensuring optimal user experience across different devices.
/// </summary>
public static class DefaultMappings
{
	/// <summary>
	/// Provides a collection of mappings for categorizing mobile devices based on screen sizes 
	/// using a simplified, legacy categorization approach. This property is designed for backward compatibility 
	/// with systems that were built before the expansion of the <see cref="ScreenCategories"/> enum.
	/// 'MobileMappingsLegacy' focuses on the primary categories: Small, Medium, Large, and ExtraLarge, 
	/// reflecting the earlier, simpler classification system. It is ideal for applications that need to maintain 
	/// consistency with previous versions or for those that require only a basic level of screen size differentiation.
	/// This ensures seamless integration and functionality with systems that have not yet adopted the newer, 
	/// more granular screen size categories such as 'Mini', 'SmallPlus', 'MediumPlus', and others beyond 'ExtraLarge'.
	/// </summary>
	public static List<SizeMappingInfo> MobileMappingsLegacy { get;   } = new List<SizeMappingInfo>
	{
		new SizeMappingInfo(0.0, ScreenCategories.Mini, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(3.9, ScreenCategories.ExtraSmall, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(4.9, ScreenCategories.Small, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0.01, ScreenCategories.SmallPlus, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(6.2, ScreenCategories.Medium, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0.02, ScreenCategories.MediumPlus, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(7.9, ScreenCategories.Large, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0.03, ScreenCategories.LargePlus, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(200.0, ScreenCategories.ExtraLarge, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0.04, ScreenCategories.ExtraExtraLarge, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0.05, ScreenCategories.Jumbo, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0.06, ScreenCategories.SuperJumbo, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0.07, ScreenCategories.Giant, ScreenSizeCompareModes.SmallerOrEqualsTo),
	};
	
	/// <summary>
	/// Provides a comprehensive collection of mappings for categorizing mobile devices based on their screen sizes. 
	/// This property includes a wide range of categories from 'Mini' to 'Giant', encompassing the diverse spectrum of 
	/// mobile device screen sizes available in the market. Each mapping associates a specific diagonal screen size 
	/// (measured in inches) with a corresponding screen size category. 
	/// This allows for precise and flexible categorization, facilitating the development of responsive layouts and 
	/// user interfaces that adapt to various screen sizes.
	/// The mappings are defined using the <see cref="SizeMappingInfo"/> class, which includes the diagonal size, 
	/// the category, and the comparison mode for each mapping. This approach offers a nuanced understanding of device 
	/// screen sizes, ensuring that user interfaces can be optimized for the best possible user experience across 
	/// different devices.
	/// Note: Some categories like 'ExtraExtraLarge', 'Jumbo', 'SuperJumbo', and 'Giant' currently have placeholder 
	/// values and may require further refinement to accurately represent the evolving landscape of mobile device sizes.
	/// </summary>
	public static List<SizeMappingInfo> MobileMappings { get; } = new List<SizeMappingInfo>
	{
		new SizeMappingInfo(3.9, ScreenCategories.Mini, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(4.9, ScreenCategories.ExtraSmall, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(5.5, ScreenCategories.Small, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(6.1, ScreenCategories.SmallPlus, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(7.9, ScreenCategories.Medium, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(8.4, ScreenCategories.MediumPlus, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(10.1, ScreenCategories.Large, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(11.9, ScreenCategories.LargePlus, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(12.9, ScreenCategories.ExtraLarge, ScreenSizeCompareModes.SmallerOrEqualsTo),
		// The following categories might need further consideration
		new SizeMappingInfo(0, ScreenCategories.ExtraExtraLarge, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0, ScreenCategories.Jumbo, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0, ScreenCategories.SuperJumbo, ScreenSizeCompareModes.SmallerOrEqualsTo),
		new SizeMappingInfo(0, ScreenCategories.Giant, ScreenSizeCompareModes.SmallerOrEqualsTo),
	};

}