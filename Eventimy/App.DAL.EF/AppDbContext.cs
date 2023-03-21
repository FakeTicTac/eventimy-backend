using App.Domain;
using App.Domain.Identity;
using Base.DAL.EF.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace App.DAL.EF;


/// <summary>
/// Database Layer Implementation: Database Creation from Models.
/// </summary>
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    /// <summary>
    /// Entity Set for Chat MediaFile Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<ChatMediaFile> ChatMediaFiles { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Chat Messages Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<ChatMessage> ChatMessages { get; set; } = default!;

    /// <summary>
    /// Entity Set for Chat Participants Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<ChatParticipant> ChatParticipants { get; set; } = default!;

    /// <summary>
    /// Entity Set for Chat Polls Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<ChatPoll> ChatPolls { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Chats Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Chat> Chats { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Cities Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<City> Cities { get; set; } = default!;

    /// <summary>
    /// Entity Set for Countries Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Country> Countries { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Event Category Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<EventCategory> EventCategories { get; set; } = default!;

    /// <summary>
    /// Entity Set for Event Media File Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<EventMediaFile> EventMediaFiles { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Event Reaction Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<EventReaction> EventReactions { get; set; } = default!;

    /// <summary>
    /// Entity Set for Event Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Event> Events { get; set; } = default!;

    /// <summary>
    /// Entity Set for Media File Types Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<MediaFileType> MediaFileTypes { get; set; } = default!;

    /// <summary>
    /// Entity Set for Performer Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Performer> Performers { get; set; } = default!;

    /// <summary>
    /// Entity Set for Performer Type Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<PerformerType> PerformerTypes { get; set; } = default!;

    /// <summary>
    /// Entity Set for Poll Answers Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<PollAnswer> PollAnswers { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Poll Options Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<PollOption> PollOptions { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for Reaction Type Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<ReactionType> ReactionTypes { get; set; } = default!;

    /// <summary>
    /// Entity Set for Subscription Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<Subscription> Subscriptions { get; set; } = default!;

    /// <summary>
    /// Entity Set for User Event Rating Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<UserEventRating> UserEventRatings { get; set; } = default!;
    
    /// <summary>
    /// Entity Set for User In Event Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<UserInEvent> UserInEvents { get; set; } = default!;


    // Identity Related Only
    
    
    /// <summary>
    /// Entity Set for Refresh Tokens Creation, Reading, Updating, and Deleting.
    /// </summary>
    public DbSet<RefreshToken> RefreshTokens { get; set; } = default!;
    

    /// <summary>
    /// Initializes a New Instance of AppDbContext.
    /// </summary>
    /// <param name="options">The Option To Be Used by a DbContext.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    /// <summary>
    /// Method Defines Models Configurations.
    /// </summary>
    /// <param name="builder">Define API for Model Configuration.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove The Cascade Delete For Every Entity Relationship
        DbContextHelperProvider.RemoveCascadeDelete(builder);
        
        
        // Application Event Related Cascade Deletes.
        
        builder.Entity<Event>()
            .HasMany(x => x.EventMediaFiles)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Event>()
            .HasMany(x => x.EventReactions)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Event>()
            .HasMany(x => x.Performers)
            .WithOne(x => x.Event)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // Application Chat Related Cascade Deletes.

        builder.Entity<Chat>()
            .HasMany(x => x.ChatMediaFiles)
            .WithOne(x => x.Chat)
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Chat>()
            .HasMany(x => x.ChatMessages)
            .WithOne(x => x.Chat)
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Chat>()
            .HasMany(x => x.ChatPolls)
            .WithOne(x => x.Chat)
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<Chat>()
            .HasMany(x => x.ChatParticipants)
            .WithOne(x => x.Chat)
            .HasForeignKey(x => x.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ChatMessage>()
            .HasMany(x => x.ChatMediaFiles)
            .WithOne(x => x.ChatMessage)
            .HasForeignKey(x => x.ChatMessageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ChatPoll>()
            .HasMany(x => x.PollOptions)
            .WithOne(x => x.ChatPoll)
            .HasForeignKey(x => x.ChatPollId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<PollOption>()
            .HasMany(x => x.PollAnswers)
            .WithOne(x => x.PollOption)
            .HasForeignKey(x => x.PollOptionId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }

    /// <summary>
    /// Method Fixes DataTime Type To Match UTC Zone and Saves All Changes To Database.
    /// </summary>
    /// <returns>The Number of State Entries Written to Database.</returns>
    public override int SaveChanges()
    {
        // Fix DateTime Type To Match UTC
        FixDatetimeUtc(this);

        // Handle Metadata Insertion and Change In Database.
        DbContextHelperProvider.SaveChangesMetadataUpdate(ChangeTracker);
        
        return base.SaveChanges();
    }

    /// <summary>
    /// Method Fixes DataTime Type To Match UTC Zone and Saves All Changes To Database.
    /// </summary>
    /// <param name="cancellationToken">Notification That Operations Should Be Stopped.</param>
    /// <returns>The Number of State Entries Written to Database.</returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        // Fix DateTime Type To Match UTC
        FixDatetimeUtc(this);
        
        // Handle Metadata Insertion and Change In Database.
        DbContextHelperProvider.SaveChangesMetadataUpdate(ChangeTracker);
        
        return base.SaveChangesAsync(cancellationToken);
    }
    

    // Custom Methods.


    /// <summary>
    /// Method Fixes DataTime Type To Match UTC Zone.
    /// </summary>
    /// <param name="context">Database Connection Definition.</param>
    // ReSharper disable once SuggestBaseTypeForParameter
    private static void FixDatetimeUtc(AppDbContext context)
    {
        var dateProperties = context.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?))
            .Select(z => new
            {
                ParentName = z.DeclaringEntityType.Name,
                PropertyName = z.Name
            });

        var editedEntitiesInTheDbContextGraph = context.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified)
            .Select(x => x.Entity);
        

        foreach (var entity in editedEntitiesInTheDbContextGraph)
        {
            // ReSharper disable once PossibleMultipleEnumeration
            var entityFields = dateProperties
                .Where(d => d.ParentName == entity.GetType().FullName);

            foreach (var property in entityFields)
            {
                var prop = entity.GetType().GetProperty(property.PropertyName);

                if (prop == null) continue;

                if (prop.GetValue(entity) is not DateTime originalValue) continue;

                prop.SetValue(entity, DateTime.SpecifyKind(originalValue, DateTimeKind.Utc));
            }
        }
    }
}
