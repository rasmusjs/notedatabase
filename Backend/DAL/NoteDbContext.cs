using Microsoft.EntityFrameworkCore;
using lars_notedatabase.Models;

// The ORM (Object-Relational Mapper) for the application
// This is the communication between the application and the database, defining data structures and relationships.
namespace lars_notedatabase.DAL;

public class NoteDbContext : DbContext
{
    public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
    {
    }


    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Instrument> Instruments { get; set; } = null!;
    public DbSet<Contributor> Contributors { get; set; } = null!;
    public DbSet<OrchestralSet> OrchestralSets { get; set; } = null!;
    public DbSet<FileAttachment> FileAttachments { get; set; } = null!;

    public DbSet<ContributorRole> ContributorRoles { get; set; } = null!;

    public DbSet<Link> Links { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuring the many-to-many relationship between OrchestralSet's and Instruments's
        modelBuilder.Entity<OrchestralSet>()
            .HasMany(os => os.Instruments)
            .WithMany(i => i.OrchestralSets)
            .UsingEntity<Dictionary<string, object>>(
                "OrchestralSetInstrument",
                j => j
                    .HasOne<Instrument>()
                    .WithMany()
                    .HasForeignKey("InstrumentId")
                    .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                    .HasConstraintName("FK_OrchestralSetInstrument_InstrumentId"),
                j => j
                    .HasOne<OrchestralSet>()
                    .WithMany()
                    .HasForeignKey("OrchestralSetId")
                    .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                    .HasConstraintName("FK_OrchestralSetInstrument_OrchestralSetId"),
                j =>
                {
                    j.HasKey("OrchestralSetId", "InstrumentId");
                    // Additional configuration if needed
                });

        // Configuring the many-to-one relationship between OrchestralSet and Country
        modelBuilder.Entity<OrchestralSet>()
            .HasOne(os => os.Country)    // Each OrchestralSet has one Country
            .WithMany(c => c.OrchestralSets) // Each Country can have many OrchestralSets
            .HasForeignKey(os => os.CountryId); // Foreign key in OrchestralSet is CountryId


        //modelBuilder.Entity<OrchestralSet>().HasMany(cr => cr.ContributorRole).WithOne(c => c.OrchestralSet).HasForeignKey(cr => ContributorRole.Con);

        //modelBuilder.Entity<OrchestralSet>().HasMany(c => c.ContributorRole);


        /*modelBuilder.Entity<ContributorRole>().HasOne<OrchestralSet>().WithMany(c => c.ContributorRole)
            .HasForeignKey("OrchestralSetId");*/

        /*modelBuilder.Entity<OrchestralSet>()
            .HasMany(os => os.ContributorRole)*/
        /*
        modelBuilder.Entity<ContributorRole>()(
             j => j
                 .HasOne<Contributor>()
                 .WithMany()
                 .HasForeignKey("ContributorId")
                 .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                 .HasConstraintName("FK_ContributorRole_ContributorId"),
             j => j
                 .HasOne<OrchestralSet>()
                 .WithMany()
                 .HasForeignKey("OrchestralSetId")
                 .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                 .HasConstraintName("FK_ContributorRole_OrchestralSetId"),
             j =>
             {
                 j.HasKey("ContributorId", "RoleId");
                 // Additional configuration if needed
             });
             */

        /*modelBuilder.Entity<OrchestralSet>()
            .HasMany(os => os.ContributorRole).WithOne(Contributor)
            .UsingEntity<ContributorRole>(
                j => j
                    .HasOne<Contributor>()
                    .WithMany()
                    .HasForeignKey("ContributorId")
                    .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                    .HasConstraintName("FK_ContributorRole_ContributorId"),
                j => j
                    .HasOne<ContributorRole.ContributorRoles>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                    .HasConstraintName("FK_ContributorRole_RoleId"),
                j =>
                {
                    j.HasKey("ContributorId", "RoleId");
                    // Additional configuration if needed
                });*/


        /*modelBuilder.Entity<OrchestralSet>()
            .HasMany(os => os.ContributorRole)
            .WithMany(c => c.OrchestralSets)
            .UsingEntity<ContributorRole>(
                j => j
                    .HasOne<Contributor>()
                    .WithMany()
                    .HasForeignKey("ContributorId")
                    .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                    .HasConstraintName("FK_ContributorRole_ContributorId"),
                j => j
                    .HasOne<ContributorRole.ContributorRoles>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade) // Adjust cascade behavior as needed
                    .HasConstraintName("FK_ContributorRole_RoleId"),
                j =>
                {
                    j.HasKey("ContributorId", "RoleId");
                    // Additional configuration if needed
                });*/
    }


    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrchestralSet>().HasMany<Instrument>(o => o.Instruments).WithMany(i => i.OrchestralSets)
            .UsingEntity(j => j.ToTable("OrchestralSetInstrument"));


        base.OnModelCreating(modelBuilder);
    }*/


    /*public DbSet<Category> Categories { get; set; } = null!;
public DbSet<Tag> Tags { get; set; } = null!;
public DbSet<Post> Posts { get; set; } = null!;
public DbSet<Comment> Comments { get; set; } = null!;

    // Configuring the relationships and schemas for the entities in the database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
    // Configuring the many to many relationship between tags and posts
    // Source: https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many
    // Link Posts and Tags using the help table PostTag
    modelBuilder.Entity<Post>()
        .HasMany(p => p.Tags)
        .WithMany(t => t.Posts)
        .UsingEntity(j => j.ToTable("PostTag"));

    // Configuring the one-to-many relationship between Posts and Categories
    modelBuilder.Entity<Post>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);

    // Configuring the one-to-many relationship between User and Posts
    modelBuilder.Entity<Post>().HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.SetNull);
    // If the user is deleted, the posts will not be deleted. User will show up a anonymous


    // Configuring the self-referencing relationship for Comments (For replies to comments)
    modelBuilder.Entity<Comment>()
        .HasMany(c => c.CommentReplies)
        .WithOne(c => c.ParentComment)
        .HasForeignKey(c => c.ParentCommentId);

    // Configuring the one-to-many relationship between User and Comments
    modelBuilder.Entity<Comment>().HasOne(p => p.User).WithMany(u => u.Comments).HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.SetNull);
    // If the user is deleted, the posts will not be deleted. User will show up a anonymous

    // Configuring the many-to-many relationship between User and Comments, for liked comments

    modelBuilder.Entity<ApplicationUser>().HasMany(u => u.LikedComments).WithMany(c => c.UserLikes)
        .UsingEntity(j => j.ToTable("UserLikedComments"));

    // Configuring the many-to-many relationship between User and Comments, for saved comments

    modelBuilder.Entity<ApplicationUser>().HasMany(u => u.SavedComments).WithMany(c => c.SavedByUsers)
        .UsingEntity(j => j.ToTable("UserSavedComments"));



    // Configuring the many-to-many relationship between User and Posts, for liked posts
    modelBuilder.Entity<ApplicationUser>().HasMany(u => u.LikedPosts).WithMany(p => p.UserLikes)
        .UsingEntity(j => j.ToTable("UserLikedPosts"));

    // Configuring the many-to-many relationship between User and Posts, for saved posts
    modelBuilder.Entity<ApplicationUser>().HasMany(u => u.SavedPosts).WithMany(p => p.SavedByUsers)
        .UsingEntity(j => j.ToTable("UserSavedPosts"));
        */

    //Fixes
    //Unhandled exception. System.InvalidOperationException: The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.
    //Source: https://stackoverflow.com/questions/39576176/is-base-onmodelcreatingmodelbuilder-necessary
    // }


    // Enable Lazy Loading for loading data when it is needed
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
}