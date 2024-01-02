using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using OnScreenSizeMarkup.Maui.Providers;

namespace OnScreenSizeMarkup.Maui;

/// <summary>
/// Markup extension that allows specifying values to be applied based on the physical screen size of the device, 
/// corresponding to a range of screen size categories such as Mini, ExtraSmall, Small, SmallPlus, Medium, MediumPlus, 
/// Large, LargePlus, ExtraLarge, ExtraExtraLarge, Jumbo, SuperJumbo, Giant, or Default.
/// </summary>
[SuppressMessage("Style", "IDE0040:Adicionar modificadores de acessibilidade")]
[SuppressMessage("ReSharper", "UseStringInterpolation")]
public class OnScreenSizeExtension : IMarkupExtension<object>
{
	private static readonly object defaultNull = new();

	private static readonly IScreenCategoryProvider screenCategoryProvider;
	private static readonly IScreenSizeHelpers screenSizeHelpers;

	static OnScreenSizeExtension()
	{
		screenCategoryProvider = UniversalFactory.CreateScreenCategoryProvider();
		screenSizeHelpers = UniversalFactory.CreateScreenSizeHelpers();
	}

	private Dictionary<ScreenCategories, object> categoryPropertyValues = new()
	{
		{ ScreenCategories.Mini, defaultNull },
		{ ScreenCategories.ExtraSmall, defaultNull },
		{ ScreenCategories.Small, defaultNull },
		{ ScreenCategories.SmallPlus, defaultNull },
		{ ScreenCategories.Medium, defaultNull },
		{ ScreenCategories.MediumPlus, defaultNull },
		{ ScreenCategories.Large, defaultNull },
		{ ScreenCategories.LargePlus, defaultNull },
		{ ScreenCategories.ExtraLarge, defaultNull },
		{ ScreenCategories.ExtraExtraLarge, defaultNull },
		{ ScreenCategories.Jumbo, defaultNull },
		{ ScreenCategories.SuperJumbo, defaultNull },
		{ ScreenCategories.Giant, defaultNull }
	};

	/// <summary>
	/// Xaml internal usage
	/// </summary>
	public OnScreenSizeExtension()
	{
		Base = default!;
		Default = defaultNull;
		FallbackType = null!;
	}


	/// <summary>
	/// Gets or sets the fallback <see cref="System.Type"/> to be used when determining the return system type. 
	/// This property is particularly useful when the markup extension is applied outside a XAML page, such as in an App.cs or style file. 
	/// It ensures that the return type can be correctly inferred even when the conventional methods of determining it fail. 
	/// By providing the fallback type explicitly, you can avoid potential issues related to type inference, thereby enhancing the robustness of your code.
	/// </summary>
	public Type? FallbackType { get; set; }

	/// <summary>
	/// The base value that serves as a reference point for scaling according to the physical screen size of the device. 
	/// If this property is specified, it will be multiplied by a specific factor that corresponds to one of the following properties:
	/// <see cref="ExtraSmall"/>, <see cref="Small"/>, <see cref="Medium"/>, <see cref="Large"/>, or <see cref="ExtraLarge"/>, 
	/// depending on the device's categorized screen size. If this property is not specified, the aforementioned properties will be used
	/// directly to return the values defined in them, depending on the determined categorization. The usage of this property aids in 
	/// providing a consistent and responsive layout across different devices.
	/// </summary>
	public object? Base { get; set; }

	/// <summary>
	/// Represents the default value used when one of the <see cref="ExtraSmall"/>, <see cref="Small"/>, <see cref="Medium"/>, <see cref="Large"/>, or <see cref="ExtraLarge"/> properties is undefined. This default value is applied if the library detects that the device's physical size corresponds to the missing property.
	/// </summary>
	/// <remarks>
	/// If <see cref="Base"/> is defined, this value must correspond to a scale factor. It allows scaling the <see cref="Base"/>'s value based on the scale factor defined here.
	/// </remarks>
	public object Default { get; set; }


	/// <summary>
	/// Specifies the value for devices with an ExtraSmall screen size. It's applied when the device's physical screen size falls into the ExtraSmall category.
	/// </summary>
	/// <remarks>
	/// If the <see cref="Base"/> property is defined, this value will act as a scale factor. It's used to multiply the <see cref="Base"/> value, allowing you to control the scaling based on the device's physical size when categorized as ExtraSmall.
	/// </remarks>
	public object ExtraSmall
	{
		get => categoryPropertyValues[ScreenCategories.ExtraSmall]!;
		set => categoryPropertyValues[ScreenCategories.ExtraSmall] = value;
	}

	/// <summary>
	/// Specifies the value for devices with a Mini screen size.
	/// </summary>
	public object Mini
	{
		get => categoryPropertyValues[ScreenCategories.Mini]!;
		set => categoryPropertyValues[ScreenCategories.Mini] = value;
	}

	/// <summary>
	/// Specifies the value for devices with a SmallPlus screen size.
	/// </summary>
	public object SmallPlus
	{
		get => categoryPropertyValues[ScreenCategories.SmallPlus]!;
		set => categoryPropertyValues[ScreenCategories.SmallPlus] = value;
	}

	/// <summary>
	/// Specifies the value for devices with a MediumPlus screen size.
	/// </summary>
	public object MediumPlus
	{
		get => categoryPropertyValues[ScreenCategories.MediumPlus]!;
		set => categoryPropertyValues[ScreenCategories.MediumPlus] = value;
	}

	/// <summary>
	/// Specifies the value for devices with a LargePlus screen size.
	/// </summary>
	public object LargePlus
	{
		get => categoryPropertyValues[ScreenCategories.LargePlus]!;
		set => categoryPropertyValues[ScreenCategories.LargePlus] = value;
	}

	/// <summary>
	/// Specifies the value for devices with an ExtraExtraLarge screen size.
	/// </summary>
	public object ExtraExtraLarge
	{
		get => categoryPropertyValues[ScreenCategories.ExtraExtraLarge]!;
		set => categoryPropertyValues[ScreenCategories.ExtraExtraLarge] = value;
	}

	/// <summary>
	/// Specifies the value for devices with a Jumbo screen size.
	/// </summary>
	public object Jumbo
	{
		get => categoryPropertyValues[ScreenCategories.Jumbo]!;
		set => categoryPropertyValues[ScreenCategories.Jumbo] = value;
	}

	/// <summary>
	/// Specifies the value for devices with a SuperJumbo screen size.
	/// </summary>
	public object SuperJumbo
	{
		get => categoryPropertyValues[ScreenCategories.SuperJumbo]!;
		set => categoryPropertyValues[ScreenCategories.SuperJumbo] = value;
	}

	/// <summary>
	/// Specifies the value for devices with a Giant screen size.
	/// </summary>
	public object Giant
	{
		get => categoryPropertyValues[ScreenCategories.Giant]!;
		set => categoryPropertyValues[ScreenCategories.Giant] = value;
	}

	/// <summary>
	/// Specifies the value for devices with an Small screen size. It's applied when the device's physical screen size falls into the Small category.
	/// </summary>
	/// <remarks>
	/// If the <see cref="Base"/> property is defined, this value will act as a scale factor. It's used to multiply the <see cref="Base"/> value, allowing you to control the scaling based on the device's physical size when categorized as Small.
	/// </remarks>
	public object Small
	{
		get => categoryPropertyValues[ScreenCategories.Small]!;
		set => categoryPropertyValues[ScreenCategories.Small] = value;
	}

	/// <summary>
	/// Specifies the value for devices with an Medium screen size. It's applied when the device's physical screen size falls into the Medium category.
	/// </summary>
	/// <remarks>
	/// If the <see cref="Base"/> property is defined, this value will act as a scale factor. It's used to multiply the <see cref="Base"/> value, allowing you to control the scaling based on the device's physical size when categorized as Medium.
	/// </remarks>
	public object Medium
	{
		get => categoryPropertyValues[ScreenCategories.Medium]!;
		set => categoryPropertyValues[ScreenCategories.Medium] = value;
	}

	/// <summary>
	/// Specifies the value for devices with an Large screen size. It's applied when the device's physical screen size falls into the Large category.
	/// </summary>
	/// <remarks>
	/// If the <see cref="Base"/> property is defined, this value will act as a scale factor. It's used to multiply the <see cref="Base"/> value, allowing you to control the scaling based on the device's physical size when categorized as Large.
	/// </remarks>
	public object Large
	{
		get => categoryPropertyValues[ScreenCategories.Large]!;
		set => categoryPropertyValues[ScreenCategories.Large] = value;
	}

	/// <summary>
	/// Specifies the value for devices with an ExtraLarge screen size. It's applied when the device's physical screen size falls into the ExtraLarge category.
	/// </summary>
	/// <remarks>
	/// If the <see cref="Base"/> property is defined, this value will act as a scale factor. It's used to multiply the <see cref="Base"/> value, allowing you to control the scaling based on the device's physical size when categorized as ExtraLarge.
	/// </remarks>
	public object ExtraLarge
	{
		get => categoryPropertyValues[ScreenCategories.ExtraLarge]!;
		set => categoryPropertyValues[ScreenCategories.ExtraLarge] = value;
	}


	/// <summary>
	/// Xaml internal usage
	/// </summary>
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		if (Base is not null)
		{
			var result = GetScaledValue(serviceProvider);
			return result;
		}
		else
		{
			var value = GetValueForScreenCategory(serviceProvider);

			return value;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="serviceProvider"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentException"></exception>
	private object GetValueForScreenCategory(IServiceProvider serviceProvider)
	{
		var bp = GetBindableProperty(serviceProvider, out var propertyType);

		// Resolve StaticResource if needed
		var value = ResolveStaticResource(serviceProvider,
			ExtractValueBasedOnScreenCategory(screenCategoryProvider.GetCategory()));

		return value!.ConvertTo(propertyType, bp!);
	}


	/// <summary>
	/// Calculates the scaled <see cref="Base"/>'s value depending on the screen size category, by multiplying the <see cref="Base"/> by the value 
	/// corresponding to the current screen category. If a specific size category is not set, the Default value is used.
	/// </summary>
	private object GetScaledValue(IServiceProvider serviceProvider)
	{
		ValidateBaseSizeDependentProperties();

		var result = screenSizeHelpers.GetScreenSizeScaled(
			(IConvertible)Base!,
			ConvertToDouble(Mini),
			ConvertToDouble(ExtraSmall),
			ConvertToDouble(Small),
			ConvertToDouble(SmallPlus),
			ConvertToDouble(Medium),
			ConvertToDouble(MediumPlus),
			ConvertToDouble(Large),
			ConvertToDouble(LargePlus),
			ConvertToDouble(ExtraLarge),
			ConvertToDouble(ExtraExtraLarge),
			ConvertToDouble(Jumbo));

		var bp = GetBindableProperty(serviceProvider, out var propertyType);

		return result!.ConvertTo(propertyType, bp!);
	}

	private double ConvertToDouble(object value)
	{
		if (value == defaultNull)
		{
			return double.Parse((string)Default, CultureInfo.InvariantCulture);
		}

		return (double)value!.ConvertTo(typeof(double), null!);
	}

	private Type DeterminePropertyType(BindableProperty? bp, PropertyInfo? pi)
	{
		return bp?.ReturnType ?? pi?.PropertyType ?? FallbackType ?? throw new InvalidOperationException(
			$"Could not infer the return type for the property that you are applying the markup to. Please ensure that the property has a valid return type and that it is accessible. In some cases, you may need to set the \"{nameof(FallbackType)}\" property explicitly to specify the return type of the property. If you continue to experience this issue, please review your code and try again.");
	}


	private BindableProperty? GetBindableProperty(IServiceProvider serviceProvider, out Type propertyType)
	{
		if (serviceProvider == null)
		{
			throw new ArgumentException($"Service provided for OnScreenSize is null");
		}

		var valueProvider = serviceProvider?.GetService<IProvideValueTarget>() ??
		                    throw new ArgumentException($"Service provided for OnScreenSize is null");

		BindableProperty bp;
		PropertyInfo pi = null!;

		if (valueProvider.TargetObject is Setter setter)
		{
			bp = setter.Property;
		}
		else
		{
			bp = (valueProvider.TargetProperty as BindableProperty)!;
			pi = (valueProvider.TargetProperty as PropertyInfo)!;
		}

		LogHelpers.WriteLine(
			$"Providing Value using propertyType:\"{bp?.ReturnType ?? pi?.PropertyType ?? null}\" and BindableProperty:{bp ?? null}",
			LogLevels.Verbose);

		propertyType = DeterminePropertyType(bp, pi);
		return bp;
	}


	/// <summary>
	/// Extracts a value based on the current screen category, taking into account the different size categories.
	/// </summary>
	/// <param name="category">The screen category used to determine the appropriate value.</param>
	/// <returns>The value corresponding to the specified screen category.</returns>
	/// <exception cref="ArgumentException">Thrown when the specified category does not have an associated value.</exception>
	/// <exception cref="XamlParseException">Thrown when the specified category does not have an associated value.</exception>
#pragma warning disable IDE0040
	private object ExtractValueBasedOnScreenCategory(ScreenCategories category)
#pragma warning restore IDE0040
	{
		if (category != ScreenCategories.NotSet)
		{
			if (categoryPropertyValues[category] != defaultNull)
			{
				return categoryPropertyValues[category]!;
			}
		}

		if (Default == defaultNull)
		{
			throw new XamlParseException(string.Format(
				"{0} requires property {0}.{1} defined to use as fallback as property {0}.{2} was not set.",
				nameof(OnScreenSizeExtension), nameof(Default), category.ToString()));
		}

		return Default;
	}

	private static object ResolveStaticResource(IServiceProvider serviceProvider, object value)
	{
		if (value is StaticResourceExtension staticResource)
		{
			var resolvedValue = staticResource.ProvideValue(serviceProvider);
			if (resolvedValue is string stringValue)
			{
				return stringValue;
			}

			return resolvedValue;
		}
		else if (value is DynamicResourceExtension dynamicResource)
		{
			var resolvedValue = dynamicResource.ProvideValue(serviceProvider);
			if (resolvedValue is string stringValue)
			{
				return stringValue;
			}

			return resolvedValue;
		}

		return value;
	}


	/// <summary>
	/// Validates the properties ExtraSmall, Small, Medium, Large, and ExtraLarge to ensure they are of type int or double
	/// when the BaseSize property is provided. Throws an exception if the validation fails.
	/// </summary>
	/// <exception cref="ArgumentException">Thrown when one of the properties is not of the expected type and BaseSize is provided.</exception>
	private void ValidateBaseSizeDependentProperties()
	{
		if (Base is null)
		{
			throw new ArgumentException($"The property {nameof(Base)} must be defined for scaled size to work.");
		}


		if (Base is not IConvertible)
		{
			throw new ArgumentException(
				$"The property {nameof(Base)} must be a primitive number such as int, double, int64, short, decimal, and etc.");
		}


		var propertiesToCheck = new Dictionary<string, object>
		{
			{ nameof(ExtraSmall), ExtraSmall },
			{ nameof(Small), Small },
			{ nameof(Medium), Medium },
			{ nameof(Large), Large },
			{ nameof(ExtraLarge), ExtraLarge }
		};

		var defaultHasExpectedType = Default is int || Default is double || (Default is string defaultString &&
		                                                                     (int.TryParse(defaultString, out _) ||
		                                                                      double.TryParse(defaultString, out _)));
		var anyPropertyFilled = propertiesToCheck.Any(entry => entry.Value != defaultNull);
		if (!anyPropertyFilled && !defaultHasExpectedType)
		{
			throw new ArgumentException(
				$"The property {nameof(Default)} must be of type int or double when {nameof(Base)} is provided and no other properties are provided. Current type of property {nameof(Default)} is \"{Default.GetType().FullName}\" ");
		}

		foreach (var entry in propertiesToCheck)
		{
			// Só validar a propriedade se ela foi preenchida (diferente de defaultNull)
			if (entry.Value != defaultNull && !(entry.Value is int || entry.Value is double))
			{
				if (entry.Value is string stringValue && (float.TryParse(stringValue, out _) ||
				                                          double.TryParse(stringValue, out _) ||
				                                          int.TryParse(stringValue, out _)))
				{
					continue; // O valor é uma string representando um número, então continuamos o loop.
				}

				throw new ArgumentException(
					$"The property {entry.Key} must be of type int or double or a string representing those types when {nameof(Base)} is provided and the property has been filled.");
			}
		}
	}
}