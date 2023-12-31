﻿using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Helpers;

namespace  OnScreenSizeMarkup.Maui.Extensions;

#pragma warning disable IDE0040 // Add accessibility modifiers
internal static class ValueConversionExtensions
#pragma warning restore IDE0040 // Add accessibility modifiers
{
#pragma warning disable IDE0040
	private static Dictionary<Type, TypeConverter> converter = new Dictionary<Type, TypeConverter>();
#pragma warning restore IDE0040

	/// <summary>
   /// Attempts to convert <paramref name="value"/> to <paramref name="toType"/>.
   /// </summary>
   /// <param name="value">A XAML user-defined Value for current <see cref="ScreenCategories"/> a device fits in.</param>
   /// <param name="toType"></param>
   /// <param name="bindableProperty"></param>
   /// <returns></returns>
    public static object ConvertTo(this object value, Type toType, BindableProperty bindableProperty)
    {
	    if (Manager.Current.IsLogEnabled)
	    {
			LogHelpers.WriteLine($"Attempting To Convert \"{(value == null ? "null" : value)}\" of type:{(value == null ? "null" : value.GetType())} to Type:{(toType == null ? "null" : toType)} on bindable Property of type:{(bindableProperty == null ? "null" : bindableProperty.ReturnType)}", LogLevels.Verbose);
	    }

	    if (toType == null)
	    {
		    return null!;
	    }

		if (value!.GetType() == toType)
		{
			return value;
		}

		object returnValue;
        if (ValueConversionExtensions.converter.TryGetValue(toType, out var converter))
        {
            returnValue = converter.ConvertFromInvariantString((string)value!)!;
            return returnValue;
        }

        if (toType.IsEnum)
        {
            returnValue = Enum.Parse(toType, (string)value!);
            return returnValue;
        }

        if (toType == typeof(RowDefinitionCollection))
        {
            converter = (TypeConverter)new RowDefinitionCollectionTypeConverter();
            ValueConversionExtensions.converter.Add(toType, converter);
            var value1 = converter.ConvertFromInvariantString((string)value!);
            return value1!;
        }
        
        
        if (toType == typeof(GridLength))
        {
	        converter = (TypeConverter)new GridLengthTypeConverter();
	        ValueConversionExtensions.converter.Add(toType, converter);
	        var value1 = converter.ConvertFromInvariantString((string)value!);
	        return value1!;
        }

        if (toType == typeof(ColumnDefinitionCollection))
        {
            converter = (TypeConverter)new ColumnDefinitionCollectionTypeConverter();
            ValueConversionExtensions.converter.Add(toType, converter);
            var value1 = converter.ConvertFromInvariantString((string)value!);
            return value1!;
        }

        
        if (toType == typeof(CornerRadius))
        {
	        converter = (TypeConverter)new Microsoft.Maui.Converters.CornerRadiusTypeConverter();
	        ValueConversionExtensions.converter.Add(toType, converter);
	        var value1 = converter.ConvertFromInvariantString((string)value!);
	        return value1!;
        }
        
        if (toType == typeof(Thickness))
        {
			
	        converter = (TypeConverter)new Microsoft.Maui.Converters.ThicknessTypeConverter();
	        ValueConversionExtensions.converter.Add(toType, converter);
	        var value1 = converter.ConvertFromInvariantString((string)value!);
	        return value1!;
        }

        
        if (toType.Namespace != null && toType.Namespace.StartsWith("Microsoft.Maui."))
        {
            var typeConverter = toType.GetCustomAttribute<TypeConverterAttribute>(true);

            if (typeConverter != null && typeConverter.ConverterTypeName != null)
            {
                var converterType = Type.GetType(typeConverter.ConverterTypeName);

                converter = (TypeConverter)Activator.CreateInstance(converterType!)!;

                ValueConversionExtensions.converter.Add(toType, converter);
                return converter.ConvertFromInvariantString((string)value!)!;
            }
        }


        if (bindableProperty != null && toType == typeof(System.Double) && bindableProperty.PropertyName.Equals("FontSize", StringComparison.InvariantCultureIgnoreCase))
        {
            returnValue = new FontSizeConverter().ConvertFromInvariantString((string)value!)!;
            return returnValue;
        }


        returnValue = Convert.ChangeType(value, toType, CultureInfo.InvariantCulture)!;
        return returnValue;
    }


}