using Base.Domain.Identity;


// ReSharper disable CollectionNeverUpdated.Global


namespace App.Domain.Identity;


/// <summary>
/// Application Identity Role Implementation. Defines Specific Entity Rows for Identity Role.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class AppRole : BaseRole
{
    /// <summary>
    /// Defines Application Role Display Name. 
    /// </summary>
    public string? DisplayName { get; set; }
}