using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace Base.WebApp.Helpers;


/// <summary>
/// Class Handles Number Inputs.
/// </summary>
public class FloatingPointModelBinder : IModelBinder
{
    /// <summary>
    /// Defines Logger Connection.
    /// </summary>
    private readonly ILogger<FloatingPointModelBinder>? _logger;
    
    /// <summary>
    /// Defines Type Of Float.
    /// </summary>
    private readonly Type _floatType;

    
    /// <summary>
    /// Basic Constructor For Number Input Handler.
    /// </summary>
    /// <param name="loggerFactory">Defines Logger Connection.</param>
    /// <param name="floatType">Defines Type Of Float.</param>
    public FloatingPointModelBinder(ILoggerFactory? loggerFactory, Type floatType)
    {
        _logger = loggerFactory?.CreateLogger<FloatingPointModelBinder>();
        _floatType = floatType;
    }

    
    /// <summary>
    /// Method Process Binding.
    /// </summary>
    /// <param name="bindingContext">Defines Binding Context.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        var value = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        // Remove unnecessary commas and spaces
        //value = value.Replace(",", string.Empty).Trim();

        _logger?.LogDebug($"Floating point number: {value}");
        value = value.Trim();

        
        value = value.Replace(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
            
        value = value.Replace(",", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        value = value.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        if (_floatType == typeof(decimal))
        {
            if (!decimal.TryParse(value, out var resultValue))
            {
                bindingContext.ModelState.TryAddModelError(
                    bindingContext.ModelName,
                    $"Could not parse decimal {value}.");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(resultValue);
        }
        else if (_floatType == typeof(float))
        {
            if (!float.TryParse(value, out var resultValue))
            {
                bindingContext.ModelState.TryAddModelError(
                    bindingContext.ModelName,
                    $"Could not parse float {value}.");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(resultValue);
        }
        else if (_floatType == typeof(double))
        {
            if (!double.TryParse(value, out var resultValue))
            {
                bindingContext.ModelState.TryAddModelError(
                    bindingContext.ModelName,
                    $"Could not parse double {value}.");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(resultValue);
        }

        return Task.CompletedTask;
    }
}
